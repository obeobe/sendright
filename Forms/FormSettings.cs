using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace SendRight {
	public partial class FormSettings : Form {
		private bool _firstTime;

		public FormSettings(bool firstTime) {
			InitializeComponent();
			this._firstTime = firstTime;
		}

		private void btnClose_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void FormSettings_Load(object sender, EventArgs e) {
			this.updateFormFromSettings(Settings.getInstance(), true);
			if (this._firstTime) {
				tabs.SelectedTab = tabWelcome;
			}
			else {
				tabs.SelectedTab = tabControlledDomains;
			}
		}

		private bool updatingForm = false;
		private void updateFormFromSettings(Settings settings, bool reloadControlledDomains) {
			updatingForm = true;

			var arrControlledDomains = settings.getControlledDomains().getArrControlledDomains();

			if (reloadControlledDomains) {
				lstControlledDomains.Items.Clear();
			}

			if (lstControlledDomains.Items.Count == 0) {
				lstControlledDomains.Items.AddRange(arrControlledDomains);
			}

			if (reloadControlledDomains) {
				if (lstControlledDomains.Items.Count > 0) {
					lstControlledDomains.SelectedIndex = 0;
				}
			}

			chkPromote.Checked = settings.getPromotion().enabled;
			txtPromotion.Text = settings.getPromotion().text.Replace("\n", "\r\n");
			chkOnProtectedAddresses.Checked = settings.getRules().getOnProtectedAddresses().enabled;
			txtOnProtectedAddresses.Text = string.Join(", ", settings.getRules().getOnProtectedAddresses().arrProtectedAddresses);
			chkOnTooManyRecipients.Checked = settings.getRules().getOnTooManyRecipients().enabled;
			numOnTooManyRecipients.Value = settings.getRules().getOnTooManyRecipients().recipientsThreshold;
			chkOnMultipleDomains.Checked = settings.getRules().getOnMultipleDomains().enabled;
			chkOnCC.Checked = settings.getRules().getOnCC().enabled;
			chkOnMixedTO.Checked = settings.getRules().getOnMixedTO().enabled;
			chkOnSendFromNonAccountEmail.Checked = settings.getRules().getOnSendFromNonAccountEmail().enabled;
			txtAllowedFromAddresses.Text = string.Join(", ", settings.getRules().getOnSendFromNonAccountEmail().arrAllowedFromAddresses);

			lblStatsNumReviewed.Text = ((string)lblStatsNumReviewed.Tag).Replace("?", settings.getStats().numReviewed.ToString());
			lblStatsNumIntervenes.Text = ((string)lblStatsNumIntervenes.Tag).Replace("?", settings.getStats().numIntervenes.ToString());
			lblStatsNumSendCancelled.Text = ((string)lblStatsNumSendCancelled.Tag).Replace("?", settings.getStats().numSendCancelled.ToString());

			updatingForm = false;
		}

		private void updateSettingsRulesFromForm() {
			if (updatingForm) return;

			var rules = Settings.getInstance().getRules();
			rules.getOnProtectedAddresses().enabled = chkOnProtectedAddresses.Checked;
			if (chkOnProtectedAddresses.Checked) rules.getOnProtectedAddresses().arrProtectedAddresses = txtOnProtectedAddresses.Text.delimitedToArray();
			rules.getOnTooManyRecipients().enabled = chkOnTooManyRecipients.Checked;
			if (chkOnTooManyRecipients.Checked) rules.getOnTooManyRecipients().recipientsThreshold = (int)numOnTooManyRecipients.Value;
			rules.getOnMultipleDomains().enabled = chkOnMultipleDomains.Checked;
			rules.getOnCC().enabled = chkOnCC.Checked;
			rules.getOnMixedTO().enabled = chkOnMixedTO.Checked;
			rules.getOnSendFromNonAccountEmail().enabled = chkOnSendFromNonAccountEmail.Checked;
			if (chkOnSendFromNonAccountEmail.Checked) rules.getOnSendFromNonAccountEmail().arrAllowedFromAddresses = txtAllowedFromAddresses.Text.delimitedToArray();
			this.persist();
		}

		private void ruleModified(object sender, EventArgs e) {
			if (chkOnProtectedAddresses.Checked) txtOnProtectedAddresses.Enabled = true; else txtOnProtectedAddresses.Enabled = false;
			if (chkOnTooManyRecipients.Checked) numOnTooManyRecipients.Enabled = true; else numOnTooManyRecipients.Enabled = false;
			if (chkOnSendFromNonAccountEmail.Checked) txtAllowedFromAddresses.Enabled = true; else txtAllowedFromAddresses.Enabled = false;
			updateSettingsRulesFromForm();
		}

		private void btnNewControlledDomain_Click(object sender, EventArgs e) {
			var controlledDomain = Settings.getInstance().getControlledDomains().addControlledDomain();
			controlledDomain.arrDomains = new string[] { "mycompany.com" };
			this.persist();
			lstControlledDomains.Items.Add(controlledDomain);
			lstControlledDomains.SelectedIndex = lstControlledDomains.Items.Count - 1;
		}

		private void chkPromote_CheckedChanged(object sender, EventArgs e) {
			if (chkPromote.Checked) {
				txtPromotion.Enabled = true;
			}
			else {
				txtPromotion.Enabled = false;
			}
			Settings.getInstance().getPromotion().enabled = chkPromote.Checked;
			this.persist();
		}

		private Settings.IControlledDomain getCurrentControlledDomain() {
			if (this.lstControlledDomains.SelectedIndex == -1) return null;
			return (Settings.IControlledDomain)this.lstControlledDomains.SelectedItem;
		}

		private void btnDeleteControlledDomain_Click(object sender, EventArgs e) {
			var controlledDomain = this.getCurrentControlledDomain();
			if (controlledDomain == null) return;
			if (MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
			this.lstControlledDomains.Items.Remove(controlledDomain);
			controlledDomain.remove();
			this.persist();
		}

		private void lstControlledDomains_SelectedIndexChanged(object sender, EventArgs e) {
			var controlledDomain = this.getCurrentControlledDomain();
			if (controlledDomain == null) {
				btnDeleteControlledDomain.Enabled = false;
				panelControlledDomains.Hide();
			}
			else {
				btnDeleteControlledDomain.Enabled = true;
				panelControlledDomains.Show();
				txtControlledDomains.Text = string.Join(", ", controlledDomain.arrDomains);
				lstExceptions.Items.Clear();
				lstExceptions.Items.AddRange(controlledDomain.getExceptions().getArrExceptions());
				btnDeleteException.Enabled = false;
			}
		}

		private void txtControlledDomains_Validated(object sender, EventArgs e) {
			var controlledDomain = this.getCurrentControlledDomain();
			if (controlledDomain == null) return;
			controlledDomain.arrDomains = txtControlledDomains.Text.delimitedToArray();
			lstControlledDomains.Items[lstControlledDomains.SelectedIndex] = lstControlledDomains.SelectedItem;
			this.persist();
		}

		private void persist() {
			Settings.getInstance().persist();
		}

		private void lstExceptions_SelectedIndexChanged(object sender, EventArgs e) {
			if (lstExceptions.SelectedIndex == -1) {
				btnDeleteException.Enabled = false;
			}
			else {
				btnDeleteException.Enabled = true;
			}
		}

		private void btnDeleteException_Click(object sender, EventArgs e) {
			if (lstExceptions.SelectedIndex == -1) return;
			Settings.IException ex = (Settings.IException)lstExceptions.SelectedItem;
			lstExceptions.Items.Remove(ex);
			ex.remove();
			this.persist();
		}

		private void btnResetStats_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Are you sure you want to reset all accumulated statistics?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) return;
			Settings.getInstance().getStats().reset();
			this.persist();
			this.updateFormFromSettings(Settings.getInstance(), false);
		}

		private void txtPromotion_Validated(object sender, EventArgs e) {
			Settings.getInstance().getPromotion().text = txtPromotion.Text;
			this.persist();
		}

		private void linkConfigureRules_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			tabs.SelectedTab = tabRules;
		}

		private void linkEditControlledDomains_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			tabs.SelectedTab = tabControlledDomains;
		}

		private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			tabs.SelectedTab = tabAbout;
		}

		private void btnExport_Click(object sender, EventArgs e) {
			var sfd = new SaveFileDialog();
			sfd.CheckFileExists = false;
			sfd.CheckPathExists = true;
			sfd.Filter = "XML Files|*.xml";
			if (sfd.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			string xml = Settings.getInstance().getXml();
			File.WriteAllText(sfd.FileName, xml);
		}

		private void btnImport_Click(object sender, EventArgs e) {
			var ofd = new OpenFileDialog();
			ofd.CheckFileExists = true;
			ofd.Filter = "XML Files|*.xml";
			if (ofd.ShowDialog() == DialogResult.Cancel) {
				return;
			}

			if (MessageBox.Show("All settings (including exceptions and statistics) will be imported. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel) {
				return;
			}

			Settings settings = Settings.getInstance();

			string xml = File.ReadAllText(ofd.FileName);
			settings.setXml(xml);
			if (MessageBox.Show("Import succeeded. Reset statistics?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				settings.getStats().reset();
			}
			settings.persist();
			this.updateFormFromSettings(settings, true);
		}

		private void linkSendRight_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(linkSendRight.Text);
		}

		private void tabs_Selected(object sender, TabControlEventArgs e) {
			if (tabs.SelectedTab == tabWelcome) {
				picArrow.Enabled = true;
			}
			else {
				picArrow.Enabled = false;
			}
		}
	}
}
