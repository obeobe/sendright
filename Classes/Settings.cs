using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SendRight {
	class Settings {
		private XDocument xDoc;

		private Settings() { }

		#region Interfaces
		public interface IControlledDomains {
			IControlledDomain[] getArrControlledDomains();
			IControlledDomain addControlledDomain();
		}

		public interface IControlledDomain {
			string[] arrDomains { get; set; }
			IExceptions getExceptions();
			void remove();
			string ToString();
		}

		public interface IExceptions {
			IException[] getArrExceptions();
			IException addException();
		}

		public interface IException {
			string[] arrTO { get; set; }
			string[] arrCC { get; set; }
			string[] arrBCC { get; set; }
			bool isContained(string[] arrTO, string[] arrCC, string[] arrBCC);
			bool isContained(string[] arrAll);
			void remove();
		}

		public interface IPromotion {
			bool enabled { get; set; }
			string text { get; set; }
		}

		public interface IRules {
			IRuleOnProtectedAddresses getOnProtectedAddresses();
			IRuleOnTooManyRecipients getOnTooManyRecipients();
			IRuleOnMultipleDomains getOnMultipleDomains();
			IRuleOnCC getOnCC();
			IRuleOnMixedTO getOnMixedTO();
			IRuleOnSendFromNonAccountEmail getOnSendFromNonAccountEmail();
		}

		public interface IRuleOnProtectedAddresses {
			bool enabled { get; set; }
			string[] arrProtectedAddresses { get; set; }
		}

		public interface IRuleOnTooManyRecipients {
			bool enabled { get; set; }
			int recipientsThreshold { get; set; }
		}

		public interface IRuleOnMultipleDomains {
			bool enabled { get; set; }
		}

		public interface IRuleOnCC {
			bool enabled { get; set; }
		}

		public interface IRuleOnMixedTO {
			bool enabled { get; set; }
		}

		public interface IRuleOnSendFromNonAccountEmail {
			bool enabled { get; set; }
			string[] arrAllowedFromAddresses { get; set; }
		}

		public interface IStats {
			int numReviewed { get; set; }
			int numIntervenes { get; set; }
			int numSendCancelled { get; set; }
			void reset();
		}
		#endregion

		class Wrapper {
			protected XElement xSelf;
			protected T init<T>(XElement xSelf) where T : Wrapper {
				this.xSelf = xSelf;
				return (T)this;
			}
			protected string getAsString(string attr) {
				return this.xSelf.Attribute(attr).Value;
			}
			protected string[] getAsArray(string attr) {
				string[] result = this.xSelf.Attribute(attr)?.Value.coalesce("").Split(",".ToCharArray()).Where(s => !s.Trim().isEmpty()).ToArray();
				if (result == null) result = new string[0] { };
				return result;
			}
			protected int getAsInt(string attr) {
				return this.xSelf.Attribute(attr).Value.toInt();
			}
			protected bool getAsBool(string attr) {
				return this.xSelf.Attribute(attr).Value.toBool();
			}
			protected void set(string attr, string value) {
				this.xSelf.Attribute(attr).Value = value;
			}
			protected void set(string attr, string[] value) {
				this.xSelf.addOrGetAttribute(attr, "").Value = string.Join(",", value
					.Select(s => {
						return s.Trim();
					})
					.Where(s => {
						return !s.isEmpty();
					})
				);
			}
			protected void set(string attr, int value) {
				this.xSelf.Attribute(attr).Value = value.ToString();
			}
			protected void set(string attr, bool value) {
				this.xSelf.Attribute(attr).Value = value.ToString();
			}
		}

		class ControlledDomains : Wrapper, IControlledDomains {
			public static IControlledDomains factory(XElement x) {
				return (new ControlledDomains()).init<ControlledDomains>(x);
			}

			public IControlledDomain[] getArrControlledDomains() {
				IControlledDomain[] arr = this.xSelf.Elements("controlledDomain").Select(x => ControlledDomain.factory(x)).ToArray();
				return arr;
			}

			public IControlledDomain addControlledDomain() {
				XElement x = new XElement("controlledDomain");
				this.xSelf.Add(x);
				return ControlledDomain.factory(x);
			}

			class ControlledDomain : Wrapper, IControlledDomain {
				public static IControlledDomain factory(XElement x) {
					return (new ControlledDomain()).init<ControlledDomain>(x);
				}

				public string[] arrDomains {
					get { return this.getAsArray("domains"); }
					set { this.set("domains", value); }
				}

				public IExceptions getExceptions() {
					if (this.xSelf.Element("exceptions") == null) {
						this.xSelf.Add(new XElement("exceptions"));
					}

					IExceptions exceptions = Exceptions.factory(this.xSelf.Element("exceptions"));
					return exceptions;
				}

				public void remove() {
					this.xSelf.Remove();
				}

				public override string ToString() {
					return string.Join(", ", this.arrDomains);
				}

				class Exceptions : Wrapper, IExceptions {
					public static IExceptions factory(XElement x) {
						return (new Exceptions()).init<Exceptions>(x);
					}

					public IException[] getArrExceptions() {
						IException[] arr = this.xSelf.Elements("exception").Select(x => Exception.factory(x)).ToArray();
						return arr;
					}

					public IException addException() {
						XElement x = new XElement("exception");
						this.xSelf.Add(x);
						return Exception.factory(x);
					}

					class Exception : Wrapper, IException {
						public static IException factory(XElement x) {
							return (new Exception()).init<Exception>(x);
						}

						private bool isContained(IEnumerable<string> ieSet, IEnumerable<string> ieSupposedSubSet) {
							if (ieSet.toLower().Distinct().Intersect(ieSupposedSubSet.toLower().Distinct()).Count() == ieSupposedSubSet.Distinct().Count()) {
								return true;
							}
							return false;
						}

						public string[] arrTO {
							get { return this.getAsArray("to"); }
							set { this.set("to", value); }
						}

						public string[] arrCC {
							get { return this.getAsArray("cc"); }
							set { this.set("cc", value); }
						}

						public string[] arrBCC {
							get { return this.getAsArray("bcc"); }
							set { this.set("bcc", value); }
						}

						public string[] getArrAll() {
							return this.arrTO.Concat(this.arrCC).Concat(this.arrBCC).ToArray();
						}

						public bool isContained(string[] arrAll) {
							return this.isContained(this.getArrAll(), arrAll);
						}

						public bool isContained(string[] arrTO, string[] arrCC, string[] arrBCC) {
							if (!this.isContained(this.arrTO, arrTO)) return false;
							if (!this.isContained(this.arrCC, arrCC)) return false;
							if (!this.isContained(this.arrBCC, arrBCC)) return false;
							return true;
						}

						public void remove() {
							this.xSelf.Remove();
						}

						public override string ToString() {
							List<string> lst = new List<string>();
							if (this.arrTO.Length > 0) {
								lst.Add("TO: " + string.Join(", ", this.arrTO));
							}
							if (this.arrCC.Length > 0) {
								lst.Add("CC: " + string.Join(", ", this.arrCC));
							}
							if (this.arrBCC.Length > 0) {
								lst.Add("BCC: " + string.Join(", ", this.arrBCC));
							}
							return string.Join(", ", lst);
						}
					}
				}
			}
		}

		class Promotion : Wrapper, IPromotion {
			public static IPromotion factory(XElement x) {
				return (new Promotion()).init<Promotion>(x);
			}

			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public string text {
				get { return this.xSelf.Value; }
				set { this.xSelf.Value = value; }
			}
		}

		class Rules : Wrapper, IRules {
			public static Rules factory(XElement x) {
				return (new Rules()).init<Rules>(x);
			}

			public IRuleOnCC getOnCC() {
				return RuleOnCC.factory(this.xSelf.Element("onCC"));
			}

			public IRuleOnMixedTO getOnMixedTO() {
				return RuleOnMixedTO.factory(this.xSelf.Element("onMixedTO"));
			}

			public IRuleOnMultipleDomains getOnMultipleDomains() {
				return RuleOnMultipleDomains.factory(this.xSelf.Element("onMultipleDomains"));
			}

			public IRuleOnProtectedAddresses getOnProtectedAddresses() {
				return RuleOnProtectedAddresses.factory(this.xSelf.Element("onProtectedAddresses"));
			}

			public IRuleOnTooManyRecipients getOnTooManyRecipients() {
				return RuleOnTooManyRecipients.factory(this.xSelf.Element("onTooManyRecipients"));
			}

			public IRuleOnSendFromNonAccountEmail getOnSendFromNonAccountEmail() {
				return RuleOnSendFromNonAccountEmail.factory(this.xSelf.Element("onSendFromNonAccountEmail"));
			}
		}

		class RuleOnProtectedAddresses : Wrapper, IRuleOnProtectedAddresses {
			public string[] arrProtectedAddresses {
				get { return this.getAsArray("protectedAddresses"); }
				set { this.set("protectedAddresses", value); }
			}

			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public static RuleOnProtectedAddresses factory(XElement x) {
				return (new RuleOnProtectedAddresses()).init<RuleOnProtectedAddresses>(x);
			}
		}

		class RuleOnTooManyRecipients : Wrapper, IRuleOnTooManyRecipients {
			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public int recipientsThreshold {
				get { return this.getAsInt("recipientsThreshold"); }
				set { this.set("recipientsThreshold", value); }
			}

			public static RuleOnTooManyRecipients factory(XElement x) {
				return (new RuleOnTooManyRecipients()).init<RuleOnTooManyRecipients>(x);
			}
		}

		class RuleOnMultipleDomains : Wrapper, IRuleOnMultipleDomains {
			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public static RuleOnMultipleDomains factory(XElement x) {
				return (new RuleOnMultipleDomains()).init<RuleOnMultipleDomains>(x);
			}
		}

		class RuleOnCC : Wrapper, IRuleOnCC {
			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public static RuleOnCC factory(XElement x) {
				return (new RuleOnCC()).init<RuleOnCC>(x);
			}
		}

		class RuleOnMixedTO : Wrapper, IRuleOnMixedTO {
			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public static RuleOnMixedTO factory(XElement x) {
				return (new RuleOnMixedTO()).init<RuleOnMixedTO>(x);
			}
		}

		class RuleOnSendFromNonAccountEmail : Wrapper, IRuleOnSendFromNonAccountEmail {
			public bool enabled {
				get { return this.getAsBool("enabled"); }
				set { this.set("enabled", value); }
			}

			public string[] arrAllowedFromAddresses {
				get { return this.getAsArray("allowedFromAddresses"); }
				set { this.set("allowedFromAddresses", value); }
			}

			public static RuleOnSendFromNonAccountEmail factory(XElement x) {
				return (new RuleOnSendFromNonAccountEmail()).init<RuleOnSendFromNonAccountEmail>(x);
			}
		}

		class Stats : Wrapper, IStats {
			public int numIntervenes {
				get { return this.getAsInt("numIntervenes"); }
				set { this.set("numIntervenes", value); }
			}

			public int numReviewed {
				get { return this.getAsInt("numReviewed"); }
				set { this.set("numReviewed", value); }
			}

			public int numSendCancelled {
				get { return this.getAsInt("numSendCancelled"); }
				set { this.set("numSendCancelled", value); }
			}

			public void reset() {
				this.numIntervenes = 0;
				this.numReviewed = 0;
				this.numSendCancelled = 0;
			}

			public static Stats factory(XElement x) {
				return (new Stats()).init<Stats>(x);
			}
		}

		private static Settings instance = null;

		public static Settings getInstance() {
			if (Settings.instance != null) return Settings.instance;
			Settings.instance = new Settings();
			Settings.instance.xDoc = Settings.loadSettings();
			return Settings.instance;
		}

		private static XDocument loadSettings() {
			string xml = Properties.Settings.Default.cfg;
			//if (xml.Length == 0) xml = "<allowedRecipientsSets />";
			if (false || xml.Length == 0) {
				xml = $@"
					<cfg>
						<controlledDomains>
							<!--
								<controlledDomain domains="">
									<exceptions>
										<exception to="""" cc="""" bcc="""" />
									</exceptions>
								</controlledDomain>
							-->
						</controlledDomains>
						<promotion enabled=""false"">
							This email was reviewed by SendRight. SendRight is free and open source. http://www.sendright.email/
						</promotion>
						<rules>
							<onProtectedAddresses enabled=""true"" protectedAddresses=""all@"" />
							<onTooManyRecipients enabled=""true"" recipientsThreshold=""10"" />
							<onMultipleDomains enabled=""true"" />
							<onCC enabled=""true"" />
							<onMixedTO enabled=""true"" />
							<onSendFromNonAccountEmail enabled=""false"" allowedFromAddresses="""" />
						</rules>
						<stats numReviewed=""0"" numIntervenes=""0"" numSendCancelled=""0"" />
					</cfg>
				";

				xml = string.Join("\r\n", xml.Replace("\r\n", "\n").Split("\n".ToCharArray()).Select(line => line.Trim()));
			}
			XDocument xDoc = XDocument.Parse(xml);
			//XElement xRoot = xDoc.Element("cfg");

			//return new Tuple<XDocument, XElement>(xDoc, xRoot);
			return xDoc;
		}

		private XElement getRoot() {
			return this.xDoc.Element("cfg");
		}

		public IControlledDomains getControlledDomains() {
			IControlledDomains controlledDomains = ControlledDomains.factory(this.getRoot().Element("controlledDomains"));
			return controlledDomains;
		}

		public IPromotion getPromotion() {
			IPromotion promotion = Promotion.factory(this.getRoot().Element("promotion"));
			return promotion;
		}

		public IRules getRules() {
			IRules rules = Rules.factory(this.getRoot().Element("rules"));
			return rules;
		}

		public IStats getStats() {
			IStats stats = Stats.factory(this.getRoot().Element("stats"));
			return stats;
		}

		public void persist() {
			string newCfg = this.xDoc.getXml();
			Properties.Settings.Default.cfg = newCfg;
			Properties.Settings.Default.Save();
		}

		public string getXml() {
			return this.xDoc.getXml();
		}

		public void setXml(string xml) {
			this.xDoc = XDocument.Parse(xml);
		}
	}
}
