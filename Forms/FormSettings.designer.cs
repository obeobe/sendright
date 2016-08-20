namespace SendRight {
	partial class FormSettings {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.label1 = new System.Windows.Forms.Label();
			this.lblNumPermittedRecipientsSets = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.toolTips = new System.Windows.Forms.ToolTip(this.components);
			this.txtControlledDomains = new System.Windows.Forms.TextBox();
			this.chkPromote = new System.Windows.Forms.CheckBox();
			this.txtAllowedFromAddresses = new System.Windows.Forms.TextBox();
			this.chkOnSendFromNonAccountEmail = new System.Windows.Forms.CheckBox();
			this.txtOnProtectedAddresses = new System.Windows.Forms.TextBox();
			this.chkOnProtectedAddresses = new System.Windows.Forms.CheckBox();
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabWelcome = new System.Windows.Forms.TabPage();
			this.linkAbout = new System.Windows.Forms.LinkLabel();
			this.linkEditControlledDomains = new System.Windows.Forms.LinkLabel();
			this.linkConfigureRules = new System.Windows.Forms.LinkLabel();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControlledDomains = new System.Windows.Forms.TabPage();
			this.btnDeleteControlledDomain = new System.Windows.Forms.Button();
			this.lstControlledDomains = new System.Windows.Forms.ListBox();
			this.panelControlledDomains = new System.Windows.Forms.Panel();
			this.btnDeleteException = new System.Windows.Forms.Button();
			this.lstExceptions = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnNewControlledDomain = new System.Windows.Forms.Button();
			this.tabRules = new System.Windows.Forms.TabPage();
			this.chkOnMixedTO = new System.Windows.Forms.CheckBox();
			this.chkOnCC = new System.Windows.Forms.CheckBox();
			this.chkOnMultipleDomains = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numOnTooManyRecipients = new System.Windows.Forms.NumericUpDown();
			this.chkOnTooManyRecipients = new System.Windows.Forms.CheckBox();
			this.tabStatistics = new System.Windows.Forms.TabPage();
			this.btnResetStats = new System.Windows.Forms.Button();
			this.btnStatsReset = new System.Windows.Forms.Button();
			this.lblStatsNumSendCancelled = new System.Windows.Forms.Label();
			this.lblStatsNumIntervenes = new System.Windows.Forms.Label();
			this.lblStatsNumReviewed = new System.Windows.Forms.Label();
			this.tabAbout = new System.Windows.Forms.TabPage();
			this.linkSendRight = new System.Windows.Forms.LinkLabel();
			this.label7 = new System.Windows.Forms.Label();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnImport = new System.Windows.Forms.Button();
			this.txtPromotion = new System.Windows.Forms.TextBox();
			this.picArrow = new System.Windows.Forms.PictureBox();
			this.tabs.SuspendLayout();
			this.tabWelcome.SuspendLayout();
			this.tabControlledDomains.SuspendLayout();
			this.panelControlledDomains.SuspendLayout();
			this.tabRules.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numOnTooManyRecipients)).BeginInit();
			this.tabStatistics.SuspendLayout();
			this.tabAbout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArrow)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(743, 303);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Number of permitted recipients sets:";
			this.label1.Visible = false;
			// 
			// lblNumPermittedRecipientsSets
			// 
			this.lblNumPermittedRecipientsSets.AutoSize = true;
			this.lblNumPermittedRecipientsSets.Location = new System.Drawing.Point(890, 283);
			this.lblNumPermittedRecipientsSets.Name = "lblNumPermittedRecipientsSets";
			this.lblNumPermittedRecipientsSets.Size = new System.Drawing.Size(13, 13);
			this.lblNumPermittedRecipientsSets.TabIndex = 1;
			this.lblNumPermittedRecipientsSets.Text = "?";
			this.lblNumPermittedRecipientsSets.Visible = false;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(655, 467);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtControlledDomains
			// 
			this.txtControlledDomains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtControlledDomains.Location = new System.Drawing.Point(114, 7);
			this.txtControlledDomains.Name = "txtControlledDomains";
			this.txtControlledDomains.Size = new System.Drawing.Size(562, 20);
			this.txtControlledDomains.TabIndex = 3;
			this.toolTips.SetToolTip(this.txtControlledDomains, resources.GetString("txtControlledDomains.ToolTip"));
			this.txtControlledDomains.Validated += new System.EventHandler(this.txtControlledDomains_Validated);
			// 
			// chkPromote
			// 
			this.chkPromote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkPromote.Location = new System.Drawing.Point(168, 333);
			this.chkPromote.Name = "chkPromote";
			this.chkPromote.Size = new System.Drawing.Size(539, 38);
			this.chkPromote.TabIndex = 1;
			this.chkPromote.Text = "Please help everybody avoid painful mistakes by adding the following recommendati" +
    "on text at the bottom of each new email :-)";
			this.toolTips.SetToolTip(this.chkPromote, resources.GetString("chkPromote.ToolTip"));
			this.chkPromote.UseVisualStyleBackColor = true;
			this.chkPromote.CheckedChanged += new System.EventHandler(this.chkPromote_CheckedChanged);
			// 
			// txtAllowedFromAddresses
			// 
			this.txtAllowedFromAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAllowedFromAddresses.Location = new System.Drawing.Point(335, 119);
			this.txtAllowedFromAddresses.Name = "txtAllowedFromAddresses";
			this.txtAllowedFromAddresses.Size = new System.Drawing.Size(350, 20);
			this.txtAllowedFromAddresses.TabIndex = 9;
			this.toolTips.SetToolTip(this.txtAllowedFromAddresses, resources.GetString("txtAllowedFromAddresses.ToolTip"));
			this.txtAllowedFromAddresses.Validated += new System.EventHandler(this.ruleModified);
			// 
			// chkOnSendFromNonAccountEmail
			// 
			this.chkOnSendFromNonAccountEmail.Checked = true;
			this.chkOnSendFromNonAccountEmail.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnSendFromNonAccountEmail.Location = new System.Drawing.Point(6, 121);
			this.chkOnSendFromNonAccountEmail.Name = "chkOnSendFromNonAccountEmail";
			this.chkOnSendFromNonAccountEmail.Size = new System.Drawing.Size(323, 17);
			this.chkOnSendFromNonAccountEmail.TabIndex = 8;
			this.chkOnSendFromNonAccountEmail.Text = "Warn when sending email from an address that is not in this list:";
			this.toolTips.SetToolTip(this.chkOnSendFromNonAccountEmail, resources.GetString("chkOnSendFromNonAccountEmail.ToolTip"));
			this.chkOnSendFromNonAccountEmail.UseVisualStyleBackColor = true;
			this.chkOnSendFromNonAccountEmail.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// txtOnProtectedAddresses
			// 
			this.txtOnProtectedAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOnProtectedAddresses.Location = new System.Drawing.Point(236, 4);
			this.txtOnProtectedAddresses.Name = "txtOnProtectedAddresses";
			this.txtOnProtectedAddresses.Size = new System.Drawing.Size(449, 20);
			this.txtOnProtectedAddresses.TabIndex = 1;
			this.txtOnProtectedAddresses.Text = "all@";
			this.toolTips.SetToolTip(this.txtOnProtectedAddresses, resources.GetString("txtOnProtectedAddresses.ToolTip"));
			this.txtOnProtectedAddresses.Validated += new System.EventHandler(this.ruleModified);
			// 
			// chkOnProtectedAddresses
			// 
			this.chkOnProtectedAddresses.AutoSize = true;
			this.chkOnProtectedAddresses.Checked = true;
			this.chkOnProtectedAddresses.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnProtectedAddresses.Location = new System.Drawing.Point(6, 6);
			this.chkOnProtectedAddresses.Name = "chkOnProtectedAddresses";
			this.chkOnProtectedAddresses.Size = new System.Drawing.Size(224, 17);
			this.chkOnProtectedAddresses.TabIndex = 0;
			this.chkOnProtectedAddresses.Text = "Warn when emailing protected addresses:";
			this.toolTips.SetToolTip(this.chkOnProtectedAddresses, resources.GetString("chkOnProtectedAddresses.ToolTip"));
			this.chkOnProtectedAddresses.UseVisualStyleBackColor = true;
			this.chkOnProtectedAddresses.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tabWelcome);
			this.tabs.Controls.Add(this.tabControlledDomains);
			this.tabs.Controls.Add(this.tabRules);
			this.tabs.Controls.Add(this.tabStatistics);
			this.tabs.Controls.Add(this.tabAbout);
			this.tabs.Location = new System.Drawing.Point(12, 12);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(699, 311);
			this.tabs.TabIndex = 8;
			this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
			// 
			// tabWelcome
			// 
			this.tabWelcome.Controls.Add(this.linkAbout);
			this.tabWelcome.Controls.Add(this.linkEditControlledDomains);
			this.tabWelcome.Controls.Add(this.linkConfigureRules);
			this.tabWelcome.Controls.Add(this.label8);
			this.tabWelcome.Controls.Add(this.label6);
			this.tabWelcome.Controls.Add(this.label5);
			this.tabWelcome.Location = new System.Drawing.Point(4, 22);
			this.tabWelcome.Name = "tabWelcome";
			this.tabWelcome.Size = new System.Drawing.Size(691, 285);
			this.tabWelcome.TabIndex = 5;
			this.tabWelcome.Text = "Welcome";
			this.tabWelcome.UseVisualStyleBackColor = true;
			// 
			// linkAbout
			// 
			this.linkAbout.AutoSize = true;
			this.linkAbout.Location = new System.Drawing.Point(65, 170);
			this.linkAbout.Name = "linkAbout";
			this.linkAbout.Size = new System.Drawing.Size(44, 13);
			this.linkAbout.TabIndex = 5;
			this.linkAbout.TabStop = true;
			this.linkAbout.Text = "About...";
			this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
			// 
			// linkEditControlledDomains
			// 
			this.linkEditControlledDomains.AutoSize = true;
			this.linkEditControlledDomains.Location = new System.Drawing.Point(65, 145);
			this.linkEditControlledDomains.Name = "linkEditControlledDomains";
			this.linkEditControlledDomains.Size = new System.Drawing.Size(128, 13);
			this.linkEditControlledDomains.TabIndex = 4;
			this.linkEditControlledDomains.TabStop = true;
			this.linkEditControlledDomains.Text = "Edit Controlled Domains...";
			this.linkEditControlledDomains.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkEditControlledDomains_LinkClicked);
			// 
			// linkConfigureRules
			// 
			this.linkConfigureRules.AutoSize = true;
			this.linkConfigureRules.Location = new System.Drawing.Point(65, 120);
			this.linkConfigureRules.Name = "linkConfigureRules";
			this.linkConfigureRules.Size = new System.Drawing.Size(91, 13);
			this.linkConfigureRules.TabIndex = 3;
			this.linkConfigureRules.TabStop = true;
			this.linkConfigureRules.Text = "Configure Rules...";
			this.linkConfigureRules.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConfigureRules_LinkClicked);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(34, 85);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(479, 17);
			this.label8.TabIndex = 2;
			this.label8.Text = "You can access it again by clicking on \"Settings\" in the \"SendRight\" ribbon.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(34, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(402, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "This is the Settings window. It only pops up automatically once.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(33, 30);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(214, 24);
			this.label5.TabIndex = 0;
			this.label5.Text = "Welcome to SendRight !";
			// 
			// tabControlledDomains
			// 
			this.tabControlledDomains.Controls.Add(this.btnDeleteControlledDomain);
			this.tabControlledDomains.Controls.Add(this.lstControlledDomains);
			this.tabControlledDomains.Controls.Add(this.panelControlledDomains);
			this.tabControlledDomains.Controls.Add(this.btnNewControlledDomain);
			this.tabControlledDomains.Location = new System.Drawing.Point(4, 22);
			this.tabControlledDomains.Name = "tabControlledDomains";
			this.tabControlledDomains.Padding = new System.Windows.Forms.Padding(3);
			this.tabControlledDomains.Size = new System.Drawing.Size(691, 285);
			this.tabControlledDomains.TabIndex = 0;
			this.tabControlledDomains.Text = "Controlled Domains";
			this.tabControlledDomains.UseVisualStyleBackColor = true;
			// 
			// btnDeleteControlledDomain
			// 
			this.btnDeleteControlledDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteControlledDomain.Enabled = false;
			this.btnDeleteControlledDomain.Location = new System.Drawing.Point(610, 107);
			this.btnDeleteControlledDomain.Name = "btnDeleteControlledDomain";
			this.btnDeleteControlledDomain.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteControlledDomain.TabIndex = 4;
			this.btnDeleteControlledDomain.Text = "Delete";
			this.btnDeleteControlledDomain.UseVisualStyleBackColor = true;
			this.btnDeleteControlledDomain.Click += new System.EventHandler(this.btnDeleteControlledDomain_Click);
			// 
			// lstControlledDomains
			// 
			this.lstControlledDomains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstControlledDomains.FormattingEnabled = true;
			this.lstControlledDomains.Location = new System.Drawing.Point(6, 6);
			this.lstControlledDomains.Name = "lstControlledDomains";
			this.lstControlledDomains.Size = new System.Drawing.Size(679, 95);
			this.lstControlledDomains.TabIndex = 12;
			this.lstControlledDomains.SelectedIndexChanged += new System.EventHandler(this.lstControlledDomains_SelectedIndexChanged);
			// 
			// panelControlledDomains
			// 
			this.panelControlledDomains.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelControlledDomains.Controls.Add(this.btnDeleteException);
			this.panelControlledDomains.Controls.Add(this.lstExceptions);
			this.panelControlledDomains.Controls.Add(this.label3);
			this.panelControlledDomains.Controls.Add(this.txtControlledDomains);
			this.panelControlledDomains.Controls.Add(this.label4);
			this.panelControlledDomains.Location = new System.Drawing.Point(6, 136);
			this.panelControlledDomains.Name = "panelControlledDomains";
			this.panelControlledDomains.Size = new System.Drawing.Size(679, 143);
			this.panelControlledDomains.TabIndex = 11;
			this.panelControlledDomains.Visible = false;
			// 
			// btnDeleteException
			// 
			this.btnDeleteException.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteException.Location = new System.Drawing.Point(604, 117);
			this.btnDeleteException.Name = "btnDeleteException";
			this.btnDeleteException.Size = new System.Drawing.Size(72, 23);
			this.btnDeleteException.TabIndex = 11;
			this.btnDeleteException.Text = "Delete";
			this.btnDeleteException.UseVisualStyleBackColor = true;
			this.btnDeleteException.Click += new System.EventHandler(this.btnDeleteException_Click);
			// 
			// lstExceptions
			// 
			this.lstExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstExceptions.FormattingEnabled = true;
			this.lstExceptions.Location = new System.Drawing.Point(114, 33);
			this.lstExceptions.Name = "lstExceptions";
			this.lstExceptions.Size = new System.Drawing.Size(562, 69);
			this.lstExceptions.TabIndex = 5;
			this.lstExceptions.SelectedIndexChanged += new System.EventHandler(this.lstExceptions_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(48, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Exceptions:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 10);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Controlled Domain(s):";
			// 
			// btnNewControlledDomain
			// 
			this.btnNewControlledDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewControlledDomain.Location = new System.Drawing.Point(529, 107);
			this.btnNewControlledDomain.Name = "btnNewControlledDomain";
			this.btnNewControlledDomain.Size = new System.Drawing.Size(75, 23);
			this.btnNewControlledDomain.TabIndex = 10;
			this.btnNewControlledDomain.Text = "+ New";
			this.btnNewControlledDomain.UseVisualStyleBackColor = true;
			this.btnNewControlledDomain.Click += new System.EventHandler(this.btnNewControlledDomain_Click);
			// 
			// tabRules
			// 
			this.tabRules.Controls.Add(this.txtAllowedFromAddresses);
			this.tabRules.Controls.Add(this.chkOnSendFromNonAccountEmail);
			this.tabRules.Controls.Add(this.chkOnMixedTO);
			this.tabRules.Controls.Add(this.chkOnCC);
			this.tabRules.Controls.Add(this.chkOnMultipleDomains);
			this.tabRules.Controls.Add(this.label2);
			this.tabRules.Controls.Add(this.numOnTooManyRecipients);
			this.tabRules.Controls.Add(this.chkOnTooManyRecipients);
			this.tabRules.Controls.Add(this.txtOnProtectedAddresses);
			this.tabRules.Controls.Add(this.chkOnProtectedAddresses);
			this.tabRules.Location = new System.Drawing.Point(4, 22);
			this.tabRules.Name = "tabRules";
			this.tabRules.Padding = new System.Windows.Forms.Padding(3);
			this.tabRules.Size = new System.Drawing.Size(691, 285);
			this.tabRules.TabIndex = 1;
			this.tabRules.Text = "Rules";
			this.tabRules.UseVisualStyleBackColor = true;
			// 
			// chkOnMixedTO
			// 
			this.chkOnMixedTO.AutoSize = true;
			this.chkOnMixedTO.Checked = true;
			this.chkOnMixedTO.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnMixedTO.Location = new System.Drawing.Point(6, 98);
			this.chkOnMixedTO.Name = "chkOnMixedTO";
			this.chkOnMixedTO.Size = new System.Drawing.Size(407, 17);
			this.chkOnMixedTO.TabIndex = 7;
			this.chkOnMixedTO.Text = "Warn when the TO line has both controlled domains and non-controlled domains.";
			this.chkOnMixedTO.UseVisualStyleBackColor = true;
			this.chkOnMixedTO.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// chkOnCC
			// 
			this.chkOnCC.AutoSize = true;
			this.chkOnCC.Checked = true;
			this.chkOnCC.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnCC.Location = new System.Drawing.Point(6, 75);
			this.chkOnCC.Name = "chkOnCC";
			this.chkOnCC.Size = new System.Drawing.Size(538, 17);
			this.chkOnCC.TabIndex = 6;
			this.chkOnCC.Text = "Warn when there is a controlled domain in the TO line and one or more non-control" +
    "led domains in CC or BCC.";
			this.chkOnCC.UseVisualStyleBackColor = true;
			this.chkOnCC.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// chkOnMultipleDomains
			// 
			this.chkOnMultipleDomains.AutoSize = true;
			this.chkOnMultipleDomains.Checked = true;
			this.chkOnMultipleDomains.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnMultipleDomains.Location = new System.Drawing.Point(6, 52);
			this.chkOnMultipleDomains.Name = "chkOnMultipleDomains";
			this.chkOnMultipleDomains.Size = new System.Drawing.Size(448, 17);
			this.chkOnMultipleDomains.TabIndex = 5;
			this.chkOnMultipleDomains.Text = "Warn when emailing multiple addresses that are *not* @ controlled domains (two or" +
    " more).";
			this.chkOnMultipleDomains.UseVisualStyleBackColor = true;
			this.chkOnMultipleDomains.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(180, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "recipients or more.";
			// 
			// numOnTooManyRecipients
			// 
			this.numOnTooManyRecipients.Location = new System.Drawing.Point(134, 28);
			this.numOnTooManyRecipients.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numOnTooManyRecipients.Name = "numOnTooManyRecipients";
			this.numOnTooManyRecipients.Size = new System.Drawing.Size(40, 20);
			this.numOnTooManyRecipients.TabIndex = 3;
			this.numOnTooManyRecipients.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numOnTooManyRecipients.ValueChanged += new System.EventHandler(this.ruleModified);
			// 
			// chkOnTooManyRecipients
			// 
			this.chkOnTooManyRecipients.AutoSize = true;
			this.chkOnTooManyRecipients.Checked = true;
			this.chkOnTooManyRecipients.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOnTooManyRecipients.Location = new System.Drawing.Point(6, 29);
			this.chkOnTooManyRecipients.Name = "chkOnTooManyRecipients";
			this.chkOnTooManyRecipients.Size = new System.Drawing.Size(122, 17);
			this.chkOnTooManyRecipients.TabIndex = 2;
			this.chkOnTooManyRecipients.Text = "Warn when emailing";
			this.chkOnTooManyRecipients.UseVisualStyleBackColor = true;
			this.chkOnTooManyRecipients.CheckedChanged += new System.EventHandler(this.ruleModified);
			// 
			// tabStatistics
			// 
			this.tabStatistics.Controls.Add(this.btnResetStats);
			this.tabStatistics.Controls.Add(this.btnStatsReset);
			this.tabStatistics.Controls.Add(this.lblStatsNumSendCancelled);
			this.tabStatistics.Controls.Add(this.lblStatsNumIntervenes);
			this.tabStatistics.Controls.Add(this.lblStatsNumReviewed);
			this.tabStatistics.Location = new System.Drawing.Point(4, 22);
			this.tabStatistics.Name = "tabStatistics";
			this.tabStatistics.Size = new System.Drawing.Size(691, 285);
			this.tabStatistics.TabIndex = 3;
			this.tabStatistics.Text = "Statistics";
			this.tabStatistics.UseVisualStyleBackColor = true;
			// 
			// btnResetStats
			// 
			this.btnResetStats.Location = new System.Drawing.Point(613, 259);
			this.btnResetStats.Name = "btnResetStats";
			this.btnResetStats.Size = new System.Drawing.Size(75, 23);
			this.btnResetStats.TabIndex = 5;
			this.btnResetStats.Text = "Reset";
			this.btnResetStats.UseVisualStyleBackColor = true;
			this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
			// 
			// btnStatsReset
			// 
			this.btnStatsReset.Location = new System.Drawing.Point(764, 342);
			this.btnStatsReset.Name = "btnStatsReset";
			this.btnStatsReset.Size = new System.Drawing.Size(75, 23);
			this.btnStatsReset.TabIndex = 4;
			this.btnStatsReset.Text = "Reset";
			this.btnStatsReset.UseVisualStyleBackColor = true;
			// 
			// lblStatsNumSendCancelled
			// 
			this.lblStatsNumSendCancelled.AutoSize = true;
			this.lblStatsNumSendCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatsNumSendCancelled.Location = new System.Drawing.Point(25, 110);
			this.lblStatsNumSendCancelled.Name = "lblStatsNumSendCancelled";
			this.lblStatsNumSendCancelled.Size = new System.Drawing.Size(582, 24);
			this.lblStatsNumSendCancelled.TabIndex = 2;
			this.lblStatsNumSendCancelled.Tag = "Number of times a send was cancelled after SendRight intervened: ?";
			this.lblStatsNumSendCancelled.Text = "Number of times a send was cancelled after SendRight intervened: ?";
			// 
			// lblStatsNumIntervenes
			// 
			this.lblStatsNumIntervenes.AutoSize = true;
			this.lblStatsNumIntervenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatsNumIntervenes.Location = new System.Drawing.Point(25, 70);
			this.lblStatsNumIntervenes.Name = "lblStatsNumIntervenes";
			this.lblStatsNumIntervenes.Size = new System.Drawing.Size(437, 24);
			this.lblStatsNumIntervenes.TabIndex = 1;
			this.lblStatsNumIntervenes.Tag = "Number of times SendRight intervened in a send: ?";
			this.lblStatsNumIntervenes.Text = "Number of times SendRight intervened in a send: ?";
			// 
			// lblStatsNumReviewed
			// 
			this.lblStatsNumReviewed.AutoSize = true;
			this.lblStatsNumReviewed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatsNumReviewed.Location = new System.Drawing.Point(25, 30);
			this.lblStatsNumReviewed.Name = "lblStatsNumReviewed";
			this.lblStatsNumReviewed.Size = new System.Drawing.Size(375, 24);
			this.lblStatsNumReviewed.TabIndex = 0;
			this.lblStatsNumReviewed.Tag = "Number of sends reviewed by SendRight: ?";
			this.lblStatsNumReviewed.Text = "Number of sends reviewed by SendRight: ?";
			// 
			// tabAbout
			// 
			this.tabAbout.Controls.Add(this.linkSendRight);
			this.tabAbout.Controls.Add(this.label7);
			this.tabAbout.Location = new System.Drawing.Point(4, 22);
			this.tabAbout.Name = "tabAbout";
			this.tabAbout.Size = new System.Drawing.Size(691, 285);
			this.tabAbout.TabIndex = 4;
			this.tabAbout.Text = "About";
			this.tabAbout.UseVisualStyleBackColor = true;
			// 
			// linkSendRight
			// 
			this.linkSendRight.AutoSize = true;
			this.linkSendRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkSendRight.Location = new System.Drawing.Point(26, 116);
			this.linkSendRight.Name = "linkSendRight";
			this.linkSendRight.Size = new System.Drawing.Size(235, 24);
			this.linkSendRight.TabIndex = 1;
			this.linkSendRight.TabStop = true;
			this.linkSendRight.Text = "http://www.sendright.email/";
			this.linkSendRight.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSendRight_LinkClicked);
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(25, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(533, 88);
			this.label7.TabIndex = 0;
			this.label7.Text = "SendRight is a free, open source Outlook plugin designed to improve email communi" +
    "cation and reduce the chances of accidentally sending sensitive emails to the wr" +
    "ong recipient.";
			// 
			// btnExport
			// 
			this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExport.Location = new System.Drawing.Point(16, 467);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(75, 23);
			this.btnExport.TabIndex = 9;
			this.btnExport.Text = "Export...";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImport.Location = new System.Drawing.Point(97, 467);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(75, 23);
			this.btnImport.TabIndex = 10;
			this.btnImport.Text = "Import...";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// txtPromotion
			// 
			this.txtPromotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtPromotion.Enabled = false;
			this.txtPromotion.Location = new System.Drawing.Point(12, 377);
			this.txtPromotion.Multiline = true;
			this.txtPromotion.Name = "txtPromotion";
			this.txtPromotion.Size = new System.Drawing.Size(694, 72);
			this.txtPromotion.TabIndex = 11;
			this.txtPromotion.Text = "This email was reviewed by SendRight. SendRight is free and open source. http://w" +
    "ww.sendright.email/";
			this.txtPromotion.Validated += new System.EventHandler(this.txtPromotion_Validated);
			// 
			// picArrow
			// 
			this.picArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.picArrow.ErrorImage = null;
			this.picArrow.Image = global::SendRight.Properties.Resources.GreenAnimatedArrowRight;
			this.picArrow.InitialImage = null;
			this.picArrow.Location = new System.Drawing.Point(12, 333);
			this.picArrow.Name = "picArrow";
			this.picArrow.Size = new System.Drawing.Size(150, 38);
			this.picArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picArrow.TabIndex = 12;
			this.picArrow.TabStop = false;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(742, 501);
			this.Controls.Add(this.picArrow);
			this.Controls.Add(this.txtPromotion);
			this.Controls.Add(this.chkPromote);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblNumPermittedRecipientsSets);
			this.Controls.Add(this.label1);
			this.MinimumSize = new System.Drawing.Size(750, 530);
			this.Name = "FormSettings";
			this.Text = "SendRight Settings";
			this.Load += new System.EventHandler(this.FormSettings_Load);
			this.tabs.ResumeLayout(false);
			this.tabWelcome.ResumeLayout(false);
			this.tabWelcome.PerformLayout();
			this.tabControlledDomains.ResumeLayout(false);
			this.panelControlledDomains.ResumeLayout(false);
			this.panelControlledDomains.PerformLayout();
			this.tabRules.ResumeLayout(false);
			this.tabRules.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numOnTooManyRecipients)).EndInit();
			this.tabStatistics.ResumeLayout(false);
			this.tabStatistics.PerformLayout();
			this.tabAbout.ResumeLayout(false);
			this.tabAbout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picArrow)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblNumPermittedRecipientsSets;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolTip toolTips;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage tabControlledDomains;
		private System.Windows.Forms.Button btnDeleteControlledDomain;
		private System.Windows.Forms.ListBox lstControlledDomains;
		private System.Windows.Forms.Panel panelControlledDomains;
		private System.Windows.Forms.TextBox txtControlledDomains;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnNewControlledDomain;
		private System.Windows.Forms.TabPage tabRules;
		private System.Windows.Forms.TabPage tabStatistics;
		private System.Windows.Forms.TabPage tabAbout;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.TextBox txtOnProtectedAddresses;
		private System.Windows.Forms.CheckBox chkOnProtectedAddresses;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numOnTooManyRecipients;
		private System.Windows.Forms.CheckBox chkOnTooManyRecipients;
		private System.Windows.Forms.CheckBox chkOnMultipleDomains;
		private System.Windows.Forms.CheckBox chkOnCC;
		private System.Windows.Forms.CheckBox chkOnMixedTO;
		private System.Windows.Forms.Button btnDeleteException;
		private System.Windows.Forms.ListBox lstExceptions;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblStatsNumSendCancelled;
		private System.Windows.Forms.Label lblStatsNumIntervenes;
		private System.Windows.Forms.Label lblStatsNumReviewed;
		private System.Windows.Forms.CheckBox chkPromote;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnStatsReset;
		private System.Windows.Forms.TextBox txtPromotion;
		private System.Windows.Forms.CheckBox chkOnSendFromNonAccountEmail;
		private System.Windows.Forms.Button btnResetStats;
		private System.Windows.Forms.TextBox txtAllowedFromAddresses;
		private System.Windows.Forms.TabPage tabWelcome;
		private System.Windows.Forms.LinkLabel linkAbout;
		private System.Windows.Forms.LinkLabel linkEditControlledDomains;
		private System.Windows.Forms.LinkLabel linkConfigureRules;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkSendRight;
		private System.Windows.Forms.PictureBox picArrow;
	}
}