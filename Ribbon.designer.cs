namespace SendRight {
	partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Ribbon()
			: base(Globals.Factory.GetRibbonFactory()) {
			InitializeComponent();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher ribbonDialogLauncherImpl1 = this.Factory.CreateRibbonDialogLauncher();
			this.tab1 = this.Factory.CreateRibbonTab();
			this.group1 = this.Factory.CreateRibbonGroup();
			this.btnStartStop = this.Factory.CreateRibbonButton();
			this.btnSettings = this.Factory.CreateRibbonButton();
			this.tab1.SuspendLayout();
			this.group1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tab1
			// 
			this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
			this.tab1.Groups.Add(this.group1);
			this.tab1.Label = "SendRight";
			this.tab1.Name = "tab1";
			// 
			// group1
			// 
			this.group1.DialogLauncher = ribbonDialogLauncherImpl1;
			this.group1.Items.Add(this.btnStartStop);
			this.group1.Items.Add(this.btnSettings);
			this.group1.Name = "group1";
			// 
			// btnStartStop
			// 
			this.btnStartStop.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnStartStop.Image = global::SendRight.Properties.Resources.emailIconEnabled2;
			this.btnStartStop.Label = "Enabled";
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.ShowImage = true;
			this.btnStartStop.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStartStop_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
			this.btnSettings.Image = global::SendRight.Properties.Resources.settingsIcon2;
			this.btnSettings.Label = "Settings";
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.ShowImage = true;
			this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
			// 
			// Ribbon
			// 
			this.Name = "Ribbon";
			this.RibbonType = "Microsoft.Outlook.Explorer";
			this.Tabs.Add(this.tab1);
			this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
			this.tab1.ResumeLayout(false);
			this.tab1.PerformLayout();
			this.group1.ResumeLayout(false);
			this.group1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
		internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStartStop;
		internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
	}

	partial class ThisRibbonCollection {
		internal Ribbon Ribbon {
			get { return this.GetRibbon<Ribbon>(); }
		}
	}
}
