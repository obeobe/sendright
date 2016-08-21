using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace SendRight {
	class Rules {
		private Settings settings;
		private Settings.IControlledDomain controlledDomain;
		private string[] arrTO;
		private string[] arrCC;
		private string[] arrBCC;
		private string[] arrAll;
		private string senderAddress;

		// normalized and consolidated (multiple controlled domains are changed into a single controlled domain (e.g. [ "Mycompany.COM", "MyCompany.biz" ] ==> [ "mycompany.com" ]))
		private string[] arrNormalizedTO;
		private string[] arrNormalizedCC;
		private string[] arrNormalizedBCC;
		private string[] arrNormalizedAll;

		public Rules(Settings.IControlledDomain controlledDomain, string[] arrTO, string[] arrCC, string[] arrBCC, string senderAddress) {
			this.settings = Settings.getInstance();
			this.controlledDomain = controlledDomain;
			this.arrTO = arrTO;
			this.arrCC = arrCC;
			this.arrBCC = arrBCC;
			this.senderAddress = senderAddress;

			this.arrAll = arrTO.Concat(arrCC).Concat(arrBCC).ToArray();
			this.normalizeRecipients();
		}

		private string[] consolidate(string[] arr) {
			string[] arrControlledDomains = this.controlledDomain.arrDomains.toLower().ToArray();
			if (arrControlledDomains.Length <= 1) return arr;
			string[] arrConsolidated = arr
				.Select(s => (arrControlledDomains.Contains(s) ? arrControlledDomains[0] : s))
				.Distinct()
				.ToArray()
			;
			return arrConsolidated;
		}

		private void normalizeRecipients() {
			this.arrNormalizedTO = this.consolidate(this.arrTO.toLower().ToArray());
			this.arrNormalizedCC = this.consolidate(this.arrCC.toLower().ToArray());
			this.arrNormalizedBCC = this.consolidate(this.arrBCC.toLower().ToArray());
			this.arrNormalizedAll = this.consolidate(this.arrAll.toLower().ToArray());
		}

		private bool hasControlledDomainInRecipients(string[] arrRecipients) {
			string[] arrDomains = this.controlledDomain.arrDomains;
			return arrRecipients.Any(recipient => {
				return arrDomains.Any(domain => {
					return this.testAddressMatchesPattern(recipient, $"@{domain}");
                });
			});
		}

		private bool isAtControlledDomain(string address) {
			return this.controlledDomain.arrDomains.Any(pattern => this.testAddressMatchesPattern(address, $"@{pattern}"));
		}

		private string[] getNotAtControlledDomains(string[] arrRecipients) {
			string[] arrNonControlled = arrRecipients.Where(recipient => !this.isAtControlledDomain(recipient)).ToArray();
			return arrNonControlled;
		}

		private bool testAddressMatchesPattern(string testee, string pattern) {
			if (testee.isEmpty()) return false;
			if (pattern.isEmpty()) return false;

			if (pattern[0] == '@') {
				if (testee.EndsWith(pattern)) return true;
				return false;
			}

			if (pattern[pattern.Length - 1] == '@') {
				if (testee.StartsWith(pattern)) return true;
				return false;
			}

			if (testee.Equals(pattern)) return true;

			return false;
		}

		private string denormalizeAddress(string normalizedAddress) {
			if (!this.arrNormalizedAll.Contains(normalizedAddress)) return normalizedAddress;
			string denormalized = null;
			try {
				denormalized = this.arrAll.Where(address => address.ToLower().Equals(normalizedAddress)).First();
			}
			catch (Exception ex) {
				int a = 2;
			}
			return denormalized;
		}

		private string[] denormalizeAddresses(string[] arrNormalizedAddresses) {
			return arrNormalizedAddresses.Distinct().Select(address => this.denormalizeAddress(address)).ToArray();
		}

		public bool testViolatesOnProtectedAddresses(ref string[] arrViolatingAddresses) {
			if (!this.settings.getRules().getOnProtectedAddresses().enabled) return false;
			List<string> lst = new List<string>();
			string[] arrProtectedAddresses = this.settings.getRules().getOnProtectedAddresses().arrProtectedAddresses;
			if (arrProtectedAddresses.Length == 0) return false;
			foreach (string pattern in arrProtectedAddresses) {
				foreach (string recipient in this.arrNormalizedAll) {
					if (this.testAddressMatchesPattern(recipient, pattern)) {
						lst.Add(recipient);
					}
				}
			}

			if (lst.Count == 0) return false;

			arrViolatingAddresses = lst.ToArray();
			return true;
		}

		public bool testViolatesOnTooManyRecipients(ref int numRecipients) {
			if (!this.settings.getRules().getOnTooManyRecipients().enabled) return false;
			int threshold = this.settings.getRules().getOnTooManyRecipients().recipientsThreshold;
			if (arrAll.Length < threshold) return false;

			numRecipients = arrAll.Length;
			return true;
		}

		private bool isCoveredByException() {
			var arrExceptions = this.controlledDomain.getExceptions().getArrExceptions();
			for (int i = 0; i < arrExceptions.Length; i++) {
				var exception = arrExceptions[i];
				if (exception.isContained(this.arrAll)) {
					return true;
				}
			}
			return false;
		}

		public bool testViolatesOnMultipleDomains(ref string[] arrViolatingAddresses) {
			if (!this.settings.getRules().getOnMultipleDomains().enabled) return false;
			if (this.hasControlledDomainInRecipients(this.arrTO)) return false; // only apply when there is NO controlled domain in the TO line. if there is - testViolatesOnMixedTO() will detect it
			if (this.isCoveredByException()) return false;
			string[] arrNonControlled = this.arrNormalizedAll.Where(recipient => !this.isAtControlledDomain(recipient)).ToArray();
			if (arrNonControlled.Length <= 1) return false;
			arrViolatingAddresses = arrNonControlled.Distinct().ToArray();
			return true;
		}

		public bool testViolatesOnCC(ref string[] arrViolatingAddresses) {
			if (!this.settings.getRules().getOnCC().enabled) return false;
			if (!this.hasControlledDomainInRecipients(this.arrTO)) return false;
			if (this.isCoveredByException()) return false;
			string[] arrNonControlledCC = this.getNotAtControlledDomains(this.arrNormalizedCC);
			string[] arrNonControlledBCC = this.getNotAtControlledDomains(this.arrNormalizedBCC);
			if (arrNonControlledCC.Length == 0 && arrNonControlledBCC.Length == 0) return false;
			arrViolatingAddresses = this.denormalizeAddresses(arrNonControlledCC.Concat(arrNonControlledBCC).ToArray()).Distinct().ToArray();
			return true;
		}

		public bool testViolatesOnMixedTO(ref string[] arrViolatingAddresses) {
			if (!this.settings.getRules().getOnMixedTO().enabled) return false;
			if (!this.hasControlledDomainInRecipients(this.arrTO)) return false;
			if (this.isCoveredByException()) return false;
			string[] arrNonControlledTO = this.getNotAtControlledDomains(this.arrNormalizedTO);
			if (arrNonControlledTO.Length == 0) return false;
			arrViolatingAddresses = this.denormalizeAddresses(arrNonControlledTO).Distinct().ToArray();
			return true;
		}

		public bool testViolatesOnSendFromNonAccountEmail() {
			if (!this.settings.getRules().getOnSendFromNonAccountEmail().enabled) return false;
			if (this.settings.getRules().getOnSendFromNonAccountEmail().arrAllowedFromAddresses.Contains(this.senderAddress)) return false;
			return true;
		}
	}
}
