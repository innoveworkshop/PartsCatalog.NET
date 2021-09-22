namespace PartsCatalog.DesktopForms {
	partial class ComponentForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentForm));
			this.stpStatus = new System.Windows.Forms.StatusStrip();
			this.tslNotification = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.stpMenu = new System.Windows.Forms.MenuStrip();
			this.componentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.datasheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.stpTool = new System.Windows.Forms.ToolStrip();
			this.panMain = new System.Windows.Forms.Panel();
			this.panProperties = new System.Windows.Forms.Panel();
			this.grdProperties = new System.Windows.Forms.DataGridView();
			this.panFields = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.cmbPackage = new System.Windows.Forms.ComboBox();
			this.lblPackage = new System.Windows.Forms.Label();
			this.cmbSubCategory = new System.Windows.Forms.ComboBox();
			this.lblSubCategory = new System.Windows.Forms.Label();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.updQuantity = new System.Windows.Forms.NumericUpDown();
			this.lblQuantity = new System.Windows.Forms.Label();
			this.btnDatasheet = new System.Windows.Forms.Button();
			this.picImage = new System.Windows.Forms.PictureBox();
			this.tslID = new System.Windows.Forms.ToolStripStatusLabel();
			this.stpStatus.SuspendLayout();
			this.stpMenu.SuspendLayout();
			this.panMain.SuspendLayout();
			this.panProperties.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdProperties)).BeginInit();
			this.panFields.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.updQuantity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
			this.SuspendLayout();
			// 
			// stpStatus
			// 
			this.stpStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslNotification,
            this.tslSeparator1,
            this.tslID});
			this.stpStatus.Location = new System.Drawing.Point(0, 395);
			this.stpStatus.Name = "stpStatus";
			this.stpStatus.Size = new System.Drawing.Size(569, 22);
			this.stpStatus.TabIndex = 0;
			// 
			// tslNotification
			// 
			this.tslNotification.Name = "tslNotification";
			this.tslNotification.Size = new System.Drawing.Size(71, 17);
			this.tslNotification.Text = "Component";
			// 
			// tslSeparator1
			// 
			this.tslSeparator1.Name = "tslSeparator1";
			this.tslSeparator1.Size = new System.Drawing.Size(452, 17);
			this.tslSeparator1.Spring = true;
			// 
			// stpMenu
			// 
			this.stpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.datasheetToolStripMenuItem,
            this.propertyToolStripMenuItem});
			this.stpMenu.Location = new System.Drawing.Point(0, 0);
			this.stpMenu.Name = "stpMenu";
			this.stpMenu.Size = new System.Drawing.Size(569, 24);
			this.stpMenu.TabIndex = 1;
			this.stpMenu.Text = "menuStrip1";
			// 
			// componentToolStripMenuItem
			// 
			this.componentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripMenuItem1,
            this.duplicateToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.componentToolStripMenuItem.Name = "componentToolStripMenuItem";
			this.componentToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.componentToolStripMenuItem.Text = "Component";
			// 
			// refreshToolStripMenuItem
			// 
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem1});
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.imageToolStripMenuItem.Text = "Image";
			// 
			// browseToolStripMenuItem
			// 
			this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
			this.browseToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.browseToolStripMenuItem.Text = "Browse...";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(118, 6);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			// 
			// datasheetToolStripMenuItem
			// 
			this.datasheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem2,
            this.toolStripMenuItem3,
            this.downloadToolStripMenuItem});
			this.datasheetToolStripMenuItem.Name = "datasheetToolStripMenuItem";
			this.datasheetToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.datasheetToolStripMenuItem.Text = "Datasheet";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.openToolStripMenuItem.Text = "Open...";
			// 
			// deleteToolStripMenuItem2
			// 
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 6);
			// 
			// downloadToolStripMenuItem
			// 
			this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
			this.downloadToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.downloadToolStripMenuItem.Text = "Download...";
			// 
			// propertyToolStripMenuItem
			// 
			this.propertyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem4,
            this.deleteToolStripMenuItem3});
			this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
			this.propertyToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.propertyToolStripMenuItem.Text = "Property";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.addToolStripMenuItem.Text = "Add...";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.editToolStripMenuItem.Text = "Edit...";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(104, 6);
			// 
			// deleteToolStripMenuItem3
			// 
			this.deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
			this.deleteToolStripMenuItem3.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem3.Text = "Delete";
			// 
			// stpTool
			// 
			this.stpTool.Location = new System.Drawing.Point(0, 24);
			this.stpTool.Name = "stpTool";
			this.stpTool.Size = new System.Drawing.Size(569, 25);
			this.stpTool.TabIndex = 2;
			this.stpTool.Text = "toolStrip1";
			// 
			// panMain
			// 
			this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panMain.Controls.Add(this.panProperties);
			this.panMain.Controls.Add(this.panFields);
			this.panMain.Controls.Add(this.btnDatasheet);
			this.panMain.Controls.Add(this.picImage);
			this.panMain.Location = new System.Drawing.Point(0, 52);
			this.panMain.Name = "panMain";
			this.panMain.Size = new System.Drawing.Size(569, 340);
			this.panMain.TabIndex = 3;
			// 
			// panProperties
			// 
			this.panProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panProperties.Controls.Add(this.grdProperties);
			this.panProperties.Location = new System.Drawing.Point(165, 136);
			this.panProperties.Name = "panProperties";
			this.panProperties.Size = new System.Drawing.Size(398, 201);
			this.panProperties.TabIndex = 3;
			// 
			// grdProperties
			// 
			this.grdProperties.AllowUserToAddRows = false;
			this.grdProperties.AllowUserToDeleteRows = false;
			this.grdProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grdProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdProperties.Location = new System.Drawing.Point(0, 0);
			this.grdProperties.Name = "grdProperties";
			this.grdProperties.ReadOnly = true;
			this.grdProperties.RowHeadersVisible = false;
			this.grdProperties.Size = new System.Drawing.Size(398, 201);
			this.grdProperties.TabIndex = 0;
			// 
			// panFields
			// 
			this.panFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panFields.Controls.Add(this.txtDescription);
			this.panFields.Controls.Add(this.lblDescription);
			this.panFields.Controls.Add(this.cmbPackage);
			this.panFields.Controls.Add(this.lblPackage);
			this.panFields.Controls.Add(this.cmbSubCategory);
			this.panFields.Controls.Add(this.lblSubCategory);
			this.panFields.Controls.Add(this.cmbCategory);
			this.panFields.Controls.Add(this.lblCategory);
			this.panFields.Controls.Add(this.txtName);
			this.panFields.Controls.Add(this.lblName);
			this.panFields.Controls.Add(this.updQuantity);
			this.panFields.Controls.Add(this.lblQuantity);
			this.panFields.Location = new System.Drawing.Point(159, 3);
			this.panFields.Name = "panFields";
			this.panFields.Size = new System.Drawing.Size(407, 130);
			this.panFields.TabIndex = 2;
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(6, 95);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(398, 32);
			this.txtDescription.TabIndex = 11;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(3, 79);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 10;
			this.lblDescription.Text = "Description";
			// 
			// cmbPackage
			// 
			this.cmbPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPackage.FormattingEnabled = true;
			this.cmbPackage.Location = new System.Drawing.Point(292, 55);
			this.cmbPackage.Name = "cmbPackage";
			this.cmbPackage.Size = new System.Drawing.Size(112, 21);
			this.cmbPackage.TabIndex = 9;
			this.cmbPackage.SelectedIndexChanged += new System.EventHandler(this.cmbPackage_SelectedIndexChanged);
			// 
			// lblPackage
			// 
			this.lblPackage.AutoSize = true;
			this.lblPackage.Location = new System.Drawing.Point(289, 39);
			this.lblPackage.Name = "lblPackage";
			this.lblPackage.Size = new System.Drawing.Size(50, 13);
			this.lblPackage.TabIndex = 8;
			this.lblPackage.Text = "Package";
			// 
			// cmbSubCategory
			// 
			this.cmbSubCategory.FormattingEnabled = true;
			this.cmbSubCategory.Location = new System.Drawing.Point(149, 55);
			this.cmbSubCategory.Name = "cmbSubCategory";
			this.cmbSubCategory.Size = new System.Drawing.Size(137, 21);
			this.cmbSubCategory.TabIndex = 7;
			this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
			// 
			// lblSubCategory
			// 
			this.lblSubCategory.AutoSize = true;
			this.lblSubCategory.Location = new System.Drawing.Point(146, 39);
			this.lblSubCategory.Name = "lblSubCategory";
			this.lblSubCategory.Size = new System.Drawing.Size(71, 13);
			this.lblSubCategory.TabIndex = 6;
			this.lblSubCategory.Text = "Sub-Category";
			// 
			// cmbCategory
			// 
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(6, 55);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(137, 21);
			this.cmbCategory.TabIndex = 5;
			this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new System.Drawing.Point(3, 39);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(49, 13);
			this.lblCategory.TabIndex = 4;
			this.lblCategory.Text = "Category";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(74, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(330, 20);
			this.txtName.TabIndex = 3;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(71, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(35, 13);
			this.lblName.TabIndex = 2;
			this.lblName.Text = "Name";
			// 
			// updQuantity
			// 
			this.updQuantity.Location = new System.Drawing.Point(6, 16);
			this.updQuantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.updQuantity.Name = "updQuantity";
			this.updQuantity.Size = new System.Drawing.Size(59, 20);
			this.updQuantity.TabIndex = 1;
			// 
			// lblQuantity
			// 
			this.lblQuantity.AutoSize = true;
			this.lblQuantity.Location = new System.Drawing.Point(3, 0);
			this.lblQuantity.Name = "lblQuantity";
			this.lblQuantity.Size = new System.Drawing.Size(46, 13);
			this.lblQuantity.TabIndex = 0;
			this.lblQuantity.Text = "Quantity";
			// 
			// btnDatasheet
			// 
			this.btnDatasheet.Location = new System.Drawing.Point(26, 159);
			this.btnDatasheet.Name = "btnDatasheet";
			this.btnDatasheet.Size = new System.Drawing.Size(110, 23);
			this.btnDatasheet.TabIndex = 1;
			this.btnDatasheet.Text = "Datasheet";
			this.btnDatasheet.UseVisualStyleBackColor = true;
			// 
			// picImage
			// 
			this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picImage.Location = new System.Drawing.Point(6, 0);
			this.picImage.Name = "picImage";
			this.picImage.Size = new System.Drawing.Size(150, 150);
			this.picImage.TabIndex = 0;
			this.picImage.TabStop = false;
			// 
			// tslID
			// 
			this.tslID.Name = "tslID";
			this.tslID.Size = new System.Drawing.Size(31, 17);
			this.tslID.Text = "New";
			// 
			// ComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 417);
			this.Controls.Add(this.panMain);
			this.Controls.Add(this.stpTool);
			this.Controls.Add(this.stpStatus);
			this.Controls.Add(this.stpMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.stpMenu;
			this.MaximizeBox = false;
			this.Name = "ComponentForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Component";
			this.stpStatus.ResumeLayout(false);
			this.stpStatus.PerformLayout();
			this.stpMenu.ResumeLayout(false);
			this.stpMenu.PerformLayout();
			this.panMain.ResumeLayout(false);
			this.panProperties.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdProperties)).EndInit();
			this.panFields.ResumeLayout(false);
			this.panFields.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.updQuantity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip stpStatus;
		private System.Windows.Forms.MenuStrip stpMenu;
		private System.Windows.Forms.ToolStrip stpTool;
		private System.Windows.Forms.ToolStripMenuItem componentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem datasheetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem propertyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem3;
		private System.Windows.Forms.Panel panMain;
		private System.Windows.Forms.Button btnDatasheet;
		private System.Windows.Forms.PictureBox picImage;
		private System.Windows.Forms.Panel panFields;
		private System.Windows.Forms.NumericUpDown updQuantity;
		private System.Windows.Forms.Label lblQuantity;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.ComboBox cmbSubCategory;
		private System.Windows.Forms.Label lblSubCategory;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.ComboBox cmbPackage;
		private System.Windows.Forms.Label lblPackage;
		private System.Windows.Forms.Panel panProperties;
		private System.Windows.Forms.DataGridView grdProperties;
		private System.Windows.Forms.ToolStripStatusLabel tslNotification;
		private System.Windows.Forms.ToolStripStatusLabel tslSeparator1;
		private System.Windows.Forms.ToolStripStatusLabel tslID;
	}
}