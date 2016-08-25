using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;

namespace SendRight {
    public partial class ThisAddIn {
		public static bool enabled = true;

		private void ThisAddIn_Startup(object sender, System.EventArgs e) {
			this.Application.ItemSend += Application_ItemSend;
			this.Application.Startup += Application_Startup;
			this.Application.Inspectors.NewInspector += Inspectors_NewInspector;
		}

		private void Inspectors_NewInspector(Outlook.Inspector Inspector) {
			if (!enabled) return;

			Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
			if (mailItem == null) return;
			if (mailItem.Body != null) return;
			var settings = Settings.getInstance();
			if (!settings.getPromotion().enabled) return;

			try {
				Utils.runSoon(1, () => {
					string text = settings.getPromotion().text.Replace("\r\n", "\n").Replace("\n", "<br/>");
					mailItem.HTMLBody = mailItem.HTMLBody.Replace("</body>", $"{text}</body>");
				});
			}
			catch (Exception ex) {

			}
		}

		private void Application_Startup() {
			var settings = Settings.getInstance();
			Outlook.Accounts accounts = this.Application.ActiveExplorer().Session.Accounts;

			bool emptyControlledDomains = false;
			if (settings.getControlledDomains().getArrControlledDomains().Length == 0) {
				emptyControlledDomains = true;
			}

			if (emptyControlledDomains) {
				List<string> lstDomains = new List<string>();
				foreach (Outlook.Account account in accounts) {
					string address = account.CurrentUser.Address;
					string domain = Utils.getDomain(address);
					if (lstDomains.Contains(domain)) continue;
					string domainLC = domain.ToLower();
					if (domainLC.Contains("gmail") || domainLC.Contains("hotmail") || domainLC.Contains("zoho")) continue;
					lstDomains.Add(domain);
				}

				if (lstDomains.Count > 0) {
					settings.getControlledDomains().addControlledDomain().arrDomains = lstDomains.ToArray();
					settings.persist();
					(new FormSettings(true)).ShowDialog();
				}
			}

			//(new FormSettings(true)).ShowDialog();
		}

		private void Application_ItemSend(object Item, ref bool Cancel) {
			Cancel = false;
			if (!enabled) return;


			Outlook.MailItem mailItem = Item as Outlook.MailItem;
			if (mailItem == null) return;

			Outlook.Recipients recipients = mailItem.Recipients as Outlook.Recipients;
			if (recipients == null) return;

			string senderEmail = mailItem.SenderEmailAddress;

			List<string> lstTO = new List<string>();
			List<string> lstCC = new List<string>();
			List<string> lstBCC = new List<string>();
			List<string> lstAll = new List<string>();
			List<string> lstIssues = new List<string>();
			List<Tuple<string, string, string>> lstRisks = new List<Tuple<string, string, string>>(); // (1) Hihglight, (2) violating addresses, (3) detailed explanation

			foreach (Outlook.Recipient recipient in recipients) {
				string name = recipient.Name;
				string email = recipient.Address;
				int type = recipient.Type;
				if (type == 2) {
					lstCC.Add(email);
				}
				else if (type == 3) {
					lstBCC.Add(email);
				}
				else {
					// should be "1" but just to be on the safe side - in any case that it's not explicitly CC or BCC - consider as TO.
					lstTO.Add(email);
				}
				lstAll.Add(email);
			}

			Settings settings = Settings.getInstance();

			settings.getStats().numReviewed++;
			settings.persist();

			List<Settings.IControlledDomain> lstControlledDomainsToAddException = new List<Settings.IControlledDomain>();
			foreach (var controlledDomain in settings.getControlledDomains().getArrControlledDomains()) {
				Rules rules = new Rules(controlledDomain, lstTO.ToArray(), lstCC.ToArray(), lstBCC.ToArray(), senderEmail);

				string[] arrViolatingAddresses = null;
				int num = 0;
				bool mayAddException = false;

				if (rules.testViolatesOnCC(ref arrViolatingAddresses)) {
					lstRisks.Add(new Tuple<string, string, string>("Potentially wrong domains in CC or BCC", string.Join(", ", arrViolatingAddresses), "There is at least one controlled domain in the TO line, and one or more non-controlled domains in CC and/or BCC."));
					mayAddException = true;
				}

				if (rules.testViolatesOnMixedTO(ref arrViolatingAddresses)) {
					lstRisks.Add(new Tuple<string, string, string>("Potentially wrong domains in TO", string.Join(", ", arrViolatingAddresses), "There is at least one controlled domain in the TO line, along with one or more non-controlled domains."));
					mayAddException = true;
				}

				if (rules.testViolatesOnMultipleDomains(ref arrViolatingAddresses)) {
					lstRisks.Add(new Tuple<string, string, string>("Potentially wrong domains mix", string.Join(", ", arrViolatingAddresses), "The TO line has no controlled domains, but the recipients include two or more DIFFERENT domains."));
					mayAddException = true;
				}

				if (rules.testViolatesOnProtectedAddresses(ref arrViolatingAddresses)) {
					lstRisks.Add(new Tuple<string, string, string>("Emailing one or more protected addresses", string.Join(", ", arrViolatingAddresses), "One or more of the recipient addresses are configured as protected addresses. Be sure to carefully review the email before sending."));
				}

				if (rules.testViolatesOnSendFromNonAccountEmail()) {
					lstRisks.Add(new Tuple<string, string, string>("Sending out of a non-approved address", senderEmail, "The FROM address for this email is not in the approved list. Make sure that you are sending from this address on purpose."));
				}

				if (rules.testViolatesOnTooManyRecipients(ref num)) {
					lstRisks.Add(new Tuple<string, string, string>("Many recipients", num.ToString(), "The number of recipients exceeds the defined threshold. Please carefully review the email before sending."));
				}

				if (mayAddException) {
					lstControlledDomainsToAddException.Add(controlledDomain);
				}
			}

			if (lstRisks.Count > 0) {
				settings.getStats().numIntervenes++;
				settings.persist();

				if ((new FormRisks(lstRisks)).ShowDialog() == DialogResult.Cancel) {
					Cancel = true;
					settings.getStats().numSendCancelled++;
					settings.persist();
					return;
				}

				if (lstControlledDomainsToAddException.Count > 0) {
					// add exception
					foreach (var controlledDomain in lstControlledDomainsToAddException) {
						var exception = controlledDomain.getExceptions().addException();
						exception.arrTO = lstTO.ToArray();
						exception.arrCC = lstCC.ToArray();
						exception.arrBCC = lstBCC.ToArray();
					}
					settings.persist();
				}
			}


			//Cancel = true;
			//MessageBox.Show("Cancelling send for debugging purposes...");
		}

		#region VSTO generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InternalStartup() {
			this.Startup += new System.EventHandler(ThisAddIn_Startup);
		}

		#endregion
	}
}
