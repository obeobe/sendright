using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace SendRight {
	public partial class Ribbon {
		private void Ribbon_Load(object sender, RibbonUIEventArgs e) {

		}

		private void btnStartStop_Click(object sender, RibbonControlEventArgs e) {
			ThisAddIn.enabled = !ThisAddIn.enabled;
			if (ThisAddIn.enabled) {
				btnStartStop.Label = "Enabled";
				this.btnStartStop.Image = global::SendRight.Properties.Resources.emailIconEnabled2;
			}
			else {
				btnStartStop.Label = "Disabled";
				this.btnStartStop.Image = global::SendRight.Properties.Resources.emailIconDisabled2;
			}
		}

		private void btnSettings_Click(object sender, RibbonControlEventArgs e) {
			FormSettings form = new FormSettings(false);
			form.ShowDialog();
		}
	}
}
