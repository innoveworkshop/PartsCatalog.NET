namespace PartsCatalog.PocketPCForms.Views {
	partial class ComponentForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mnuMain;

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
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mniSave = new System.Windows.Forms.MenuItem();
			this.mnuComponent = new System.Windows.Forms.MenuItem();
			this.mniRefresh = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabDetails = new System.Windows.Forms.TabPage();
			this.cmbPackage = new System.Windows.Forms.ComboBox();
			this.lblPackage = new System.Windows.Forms.Label();
			this.cmbSubCategory = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.updQuantity = new System.Windows.Forms.NumericUpDown();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.tabProperties = new System.Windows.Forms.TabPage();
			this.grdProperties = new System.Windows.Forms.DataGrid();
			this.tabMain.SuspendLayout();
			this.tabDetails.SuspendLayout();
			this.tabProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.Add(this.mniSave);
			this.mnuMain.MenuItems.Add(this.mnuComponent);
			// 
			// mniSave
			// 
			this.mniSave.Text = "Save";
			this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
			// 
			// mnuComponent
			// 
			this.mnuComponent.MenuItems.Add(this.mniRefresh);
			this.mnuComponent.MenuItems.Add(this.mniDelete);
			this.mnuComponent.Text = "Component";
			// 
			// mniRefresh
			// 
			this.mniRefresh.Text = "Refresh";
			this.mniRefresh.Click += new System.EventHandler(this.mniRefresh_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Text = "Delete";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabDetails);
			this.tabMain.Controls.Add(this.tabProperties);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.None;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(240, 269);
			this.tabMain.TabIndex = 19;
			// 
			// tabDetails
			// 
			this.tabDetails.Controls.Add(this.cmbPackage);
			this.tabDetails.Controls.Add(this.lblPackage);
			this.tabDetails.Controls.Add(this.cmbSubCategory);
			this.tabDetails.Controls.Add(this.label1);
			this.tabDetails.Controls.Add(this.cmbCategory);
			this.tabDetails.Controls.Add(this.lblCategory);
			this.tabDetails.Controls.Add(this.txtDescription);
			this.tabDetails.Controls.Add(this.lblDescription);
			this.tabDetails.Controls.Add(this.updQuantity);
			this.tabDetails.Controls.Add(this.lblName);
			this.tabDetails.Controls.Add(this.txtName);
			this.tabDetails.Controls.Add(this.lblQuantity);
			this.tabDetails.Location = new System.Drawing.Point(0, 0);
			this.tabDetails.Name = "tabDetails";
			this.tabDetails.Size = new System.Drawing.Size(240, 246);
			this.tabDetails.Text = "Details";
			// 
			// cmbPackage
			// 
			this.cmbPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPackage.Location = new System.Drawing.Point(7, 195);
			this.cmbPackage.Name = "cmbPackage";
			this.cmbPackage.Size = new System.Drawing.Size(226, 22);
			this.cmbPackage.TabIndex = 34;
			// 
			// lblPackage
			// 
			this.lblPackage.Location = new System.Drawing.Point(6, 179);
			this.lblPackage.Name = "lblPackage";
			this.lblPackage.Size = new System.Drawing.Size(75, 13);
			this.lblPackage.Text = "Package";
			// 
			// cmbSubCategory
			// 
			this.cmbSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbSubCategory.Location = new System.Drawing.Point(7, 154);
			this.cmbSubCategory.Name = "cmbSubCategory";
			this.cmbSubCategory.Size = new System.Drawing.Size(226, 22);
			this.cmbSubCategory.TabIndex = 26;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 138);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.Text = "Sub-Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.Location = new System.Drawing.Point(7, 113);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(226, 22);
			this.cmbCategory.TabIndex = 25;
			// 
			// lblCategory
			// 
			this.lblCategory.Location = new System.Drawing.Point(6, 97);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(75, 13);
			this.lblCategory.Text = "Category";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(7, 61);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(226, 33);
			this.txtDescription.TabIndex = 24;
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(6, 45);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(99, 13);
			this.lblDescription.Text = "Description";
			// 
			// updQuantity
			// 
			this.updQuantity.Location = new System.Drawing.Point(7, 20);
			this.updQuantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.updQuantity.Name = "updQuantity";
			this.updQuantity.Size = new System.Drawing.Size(63, 22);
			this.updQuantity.TabIndex = 23;
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(75, 4);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(59, 13);
			this.lblName.Text = "Name";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(76, 20);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(157, 21);
			this.txtName.TabIndex = 22;
			// 
			// lblQuantity
			// 
			this.lblQuantity.Location = new System.Drawing.Point(6, 4);
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(42, 13);
			this.lblQuantity.Text = "Qnt";
			// 
			// tabProperties
			// 
			this.tabProperties.Controls.Add(this.grdProperties);
			this.tabProperties.Location = new System.Drawing.Point(0, 0);
			this.tabProperties.Name = "tabProperties";
			this.tabProperties.Size = new System.Drawing.Size(240, 246);
			this.tabProperties.Text = "Parameters";
			// 
			// grdProperties
			// 
			this.grdProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdProperties.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.grdProperties.Location = new System.Drawing.Point(0, 0);
			this.grdProperties.Name = "grdProperties";
			this.grdProperties.Size = new System.Drawing.Size(248, 249);
			this.grdProperties.TabIndex = 1;
			// 
			// ComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.tabMain);
			this.Menu = this.mnuMain;
			this.Name = "ComponentForm";
			this.Text = "Component";
			this.tabMain.ResumeLayout(false);
			this.tabDetails.ResumeLayout(false);
			this.tabProperties.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabDetails;
		private System.Windows.Forms.ComboBox cmbSubCategory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.NumericUpDown updQuantity;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblQuantity;
		private System.Windows.Forms.TabPage tabProperties;
		private System.Windows.Forms.DataGrid grdProperties;
		private System.Windows.Forms.Label lblPackage;
		private System.Windows.Forms.ComboBox cmbPackage;
		private System.Windows.Forms.MenuItem mniSave;
		private System.Windows.Forms.MenuItem mnuComponent;
		private System.Windows.Forms.MenuItem mniRefresh;
		private System.Windows.Forms.MenuItem mniDelete;

	}
}