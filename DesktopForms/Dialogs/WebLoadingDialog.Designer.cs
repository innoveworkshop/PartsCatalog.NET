namespace PartsCatalog.DesktopForms.Dialogs {
	partial class WebLoadingDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebLoadingDialog));
			this.barProgress = new System.Windows.Forms.ProgressBar();
			this.picEarth = new System.Windows.Forms.PictureBox();
			this.lblMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picEarth)).BeginInit();
			this.SuspendLayout();
			// 
			// barProgress
			// 
			this.barProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.barProgress.Location = new System.Drawing.Point(12, 72);
			this.barProgress.Name = "barProgress";
			this.barProgress.Size = new System.Drawing.Size(299, 23);
			this.barProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.barProgress.TabIndex = 0;
			this.barProgress.UseWaitCursor = true;
			// 
			// picEarth
			// 
			this.picEarth.Image = ((System.Drawing.Image)(resources.GetObject("picEarth.Image")));
			this.picEarth.Location = new System.Drawing.Point(12, 12);
			this.picEarth.Name = "picEarth";
			this.picEarth.Size = new System.Drawing.Size(48, 48);
			this.picEarth.TabIndex = 1;
			this.picEarth.TabStop = false;
			this.picEarth.UseWaitCursor = true;
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.Location = new System.Drawing.Point(66, 12);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(245, 48);
			this.lblMessage.TabIndex = 2;
			this.lblMessage.Text = "Fetching data from the PartsCatalog web service...";
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMessage.UseWaitCursor = true;
			// 
			// WebLoadingDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(323, 107);
			this.ControlBox = false;
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.picEarth);
			this.Controls.Add(this.barProgress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WebLoadingDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fetching Data from Web Service";
			this.UseWaitCursor = true;
			((System.ComponentModel.ISupportInitialize)(this.picEarth)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar barProgress;
		private System.Windows.Forms.PictureBox picEarth;
		private System.Windows.Forms.Label lblMessage;
	}
}