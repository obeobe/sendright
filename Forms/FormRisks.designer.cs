namespace SendRight {
	partial class FormRisks {
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
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.html = new TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel();
			this.SuspendLayout();
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSend.Location = new System.Drawing.Point(530, 430);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 1;
			this.btnSend.Text = "SEND";
			this.btnSend.UseVisualStyleBackColor = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(449, 430);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// html
			// 
			this.html.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.html.AutoSize = false;
			this.html.BackColor = System.Drawing.SystemColors.Window;
			this.html.BaseStylesheet = null;
			this.html.Location = new System.Drawing.Point(0, 0);
			this.html.Name = "html";
			this.html.Size = new System.Drawing.Size(619, 417);
			this.html.TabIndex = 2;
			this.html.TabStop = false;
			this.html.Text = null;
			// 
			// FormRisks
			// 
			this.AcceptButton = this.btnCancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(617, 465);
			this.ControlBox = false;
			this.Controls.Add(this.html);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSend);
			this.Name = "FormRisks";
			this.Text = "Detected Risks";
			this.Load += new System.EventHandler(this.FormRisks_Load);
			this.ResumeLayout(false);

		}

		#endregion

		//private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel html;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnCancel;
		private TheArtOfDev.HtmlRenderer.WinForms.HtmlLabel html;
	}
}