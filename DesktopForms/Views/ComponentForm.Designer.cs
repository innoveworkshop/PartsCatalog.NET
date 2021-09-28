namespace PartsCatalog.DesktopForms.Views {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentForm));
			this.stpStatus = new System.Windows.Forms.StatusStrip();
			this.tslNotification = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslSeparator1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslID = new System.Windows.Forms.ToolStripStatusLabel();
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
			this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.stpTool = new System.Windows.Forms.ToolStrip();
			this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.duplicateToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.showDatasheetToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deleteDatasheetToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.downloadDatasheetToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.addPropertyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.editPropertyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.deletePropertyToolStripButton = new System.Windows.Forms.ToolStripButton();
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
			this.ctmProperty = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextPropertyEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextPropertyDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dlgOpenImage = new System.Windows.Forms.OpenFileDialog();
			this.ctmImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.contextBrowseImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextDeleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stpStatus.SuspendLayout();
			this.stpMenu.SuspendLayout();
			this.stpTool.SuspendLayout();
			this.panMain.SuspendLayout();
			this.panProperties.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdProperties)).BeginInit();
			this.panFields.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.updQuantity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
			this.ctmProperty.SuspendLayout();
			this.ctmImage.SuspendLayout();
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
			// tslID
			// 
			this.tslID.Name = "tslID";
			this.tslID.Size = new System.Drawing.Size(31, 17);
			this.tslID.Text = "New";
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
			this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
			this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.refreshToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.refreshToolStripMenuItem.Text = "Refresh";
			this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Enabled = false;
			this.duplicateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("duplicateToolStripMenuItem.Image")));
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem.Image")));
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
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
			this.browseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("browseToolStripMenuItem.Image")));
			this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
			this.browseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.browseToolStripMenuItem.Text = "Browse...";
			this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// deleteToolStripMenuItem1
			// 
			this.deleteToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem1.Image")));
			this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
			this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.deleteToolStripMenuItem1.Text = "Delete";
			this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
			// 
			// datasheetToolStripMenuItem
			// 
			this.datasheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.deleteToolStripMenuItem2,
            this.toolStripMenuItem3,
            this.uploadToolStripMenuItem});
			this.datasheetToolStripMenuItem.Enabled = false;
			this.datasheetToolStripMenuItem.Name = "datasheetToolStripMenuItem";
			this.datasheetToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.datasheetToolStripMenuItem.Text = "Datasheet";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open...";
			// 
			// deleteToolStripMenuItem2
			// 
			this.deleteToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem2.Image")));
			this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
			this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
			this.deleteToolStripMenuItem2.Text = "Delete";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
			// 
			// uploadToolStripMenuItem
			// 
			this.uploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolStripMenuItem.Image")));
			this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
			this.uploadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.uploadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.uploadToolStripMenuItem.Text = "Upload...";
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
			this.addToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addToolStripMenuItem.Image")));
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.addToolStripMenuItem.Text = "Add...";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.editToolStripMenuItem.Text = "Edit...";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
			// 
			// deleteToolStripMenuItem3
			// 
			this.deleteToolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripMenuItem3.Image")));
			this.deleteToolStripMenuItem3.Name = "deleteToolStripMenuItem3";
			this.deleteToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
			this.deleteToolStripMenuItem3.Text = "Delete";
			this.deleteToolStripMenuItem3.Click += new System.EventHandler(this.deleteToolStripMenuItem3_Click);
			// 
			// stpTool
			// 
			this.stpTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.toolStripSeparator1,
            this.duplicateToolStripButton,
            this.saveToolStripButton,
            this.deleteToolStripButton,
            this.toolStripSeparator2,
            this.showDatasheetToolStripButton,
            this.deleteDatasheetToolStripButton,
            this.downloadDatasheetToolStripButton,
            this.toolStripSeparator3,
            this.addPropertyToolStripButton,
            this.editPropertyToolStripButton,
            this.deletePropertyToolStripButton});
			this.stpTool.Location = new System.Drawing.Point(0, 24);
			this.stpTool.Name = "stpTool";
			this.stpTool.Size = new System.Drawing.Size(569, 25);
			this.stpTool.TabIndex = 2;
			this.stpTool.Text = "toolStrip1";
			// 
			// refreshToolStripButton
			// 
			this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
			this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshToolStripButton.Name = "refreshToolStripButton";
			this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.refreshToolStripButton.Text = "Refresh";
			this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// duplicateToolStripButton
			// 
			this.duplicateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.duplicateToolStripButton.Enabled = false;
			this.duplicateToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateToolStripButton.Image")));
			this.duplicateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.duplicateToolStripButton.Name = "duplicateToolStripButton";
			this.duplicateToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.duplicateToolStripButton.Text = "Duplicate";
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "Save";
			// 
			// deleteToolStripButton
			// 
			this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
			this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteToolStripButton.Name = "deleteToolStripButton";
			this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.deleteToolStripButton.Text = "Delete";
			this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// showDatasheetToolStripButton
			// 
			this.showDatasheetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.showDatasheetToolStripButton.Enabled = false;
			this.showDatasheetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("showDatasheetToolStripButton.Image")));
			this.showDatasheetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.showDatasheetToolStripButton.Name = "showDatasheetToolStripButton";
			this.showDatasheetToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.showDatasheetToolStripButton.Text = "Open Datasheet";
			// 
			// deleteDatasheetToolStripButton
			// 
			this.deleteDatasheetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deleteDatasheetToolStripButton.Enabled = false;
			this.deleteDatasheetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteDatasheetToolStripButton.Image")));
			this.deleteDatasheetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteDatasheetToolStripButton.Name = "deleteDatasheetToolStripButton";
			this.deleteDatasheetToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.deleteDatasheetToolStripButton.Text = "Delete Datasheet";
			// 
			// downloadDatasheetToolStripButton
			// 
			this.downloadDatasheetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.downloadDatasheetToolStripButton.Enabled = false;
			this.downloadDatasheetToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("downloadDatasheetToolStripButton.Image")));
			this.downloadDatasheetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.downloadDatasheetToolStripButton.Name = "downloadDatasheetToolStripButton";
			this.downloadDatasheetToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.downloadDatasheetToolStripButton.Text = "Download Datasheet";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// addPropertyToolStripButton
			// 
			this.addPropertyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.addPropertyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addPropertyToolStripButton.Image")));
			this.addPropertyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.addPropertyToolStripButton.Name = "addPropertyToolStripButton";
			this.addPropertyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.addPropertyToolStripButton.Text = "Add Property";
			this.addPropertyToolStripButton.Click += new System.EventHandler(this.addPropertyToolStripButton_Click);
			// 
			// editPropertyToolStripButton
			// 
			this.editPropertyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.editPropertyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editPropertyToolStripButton.Image")));
			this.editPropertyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.editPropertyToolStripButton.Name = "editPropertyToolStripButton";
			this.editPropertyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.editPropertyToolStripButton.Text = "Edit Property";
			this.editPropertyToolStripButton.Click += new System.EventHandler(this.editPropertyToolStripButton_Click);
			// 
			// deletePropertyToolStripButton
			// 
			this.deletePropertyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.deletePropertyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deletePropertyToolStripButton.Image")));
			this.deletePropertyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deletePropertyToolStripButton.Name = "deletePropertyToolStripButton";
			this.deletePropertyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.deletePropertyToolStripButton.Text = "Delete Property";
			this.deletePropertyToolStripButton.Click += new System.EventHandler(this.deletePropertyToolStripButton_Click);
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
			this.grdProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdProperties.Size = new System.Drawing.Size(398, 201);
			this.grdProperties.TabIndex = 0;
			this.grdProperties.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdProperties_MouseClick);
			this.grdProperties.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdProperties_CellMouseDoubleClick);
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
			this.picImage.ContextMenuStrip = this.ctmImage;
			this.picImage.Location = new System.Drawing.Point(6, 0);
			this.picImage.Name = "picImage";
			this.picImage.Size = new System.Drawing.Size(150, 150);
			this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picImage.TabIndex = 0;
			this.picImage.TabStop = false;
			// 
			// ctmProperty
			// 
			this.ctmProperty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextPropertyEditToolStripMenuItem,
            this.contextPropertyDeleteToolStripMenuItem});
			this.ctmProperty.Name = "ctmProperty";
			this.ctmProperty.Size = new System.Drawing.Size(108, 48);
			// 
			// contextPropertyEditToolStripMenuItem
			// 
			this.contextPropertyEditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextPropertyEditToolStripMenuItem.Image")));
			this.contextPropertyEditToolStripMenuItem.Name = "contextPropertyEditToolStripMenuItem";
			this.contextPropertyEditToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.contextPropertyEditToolStripMenuItem.Text = "Edit...";
			this.contextPropertyEditToolStripMenuItem.Click += new System.EventHandler(this.contextPropertyEditToolStripMenuItem_Click);
			// 
			// contextPropertyDeleteToolStripMenuItem
			// 
			this.contextPropertyDeleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextPropertyDeleteToolStripMenuItem.Image")));
			this.contextPropertyDeleteToolStripMenuItem.Name = "contextPropertyDeleteToolStripMenuItem";
			this.contextPropertyDeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.contextPropertyDeleteToolStripMenuItem.Text = "Delete";
			this.contextPropertyDeleteToolStripMenuItem.Click += new System.EventHandler(this.contextPropertyDeleteToolStripMenuItem_Click);
			// 
			// dlgOpenImage
			// 
			this.dlgOpenImage.Filter = resources.GetString("dlgOpenImage.Filter");
			this.dlgOpenImage.Title = "Upload Component Image";
			// 
			// ctmImage
			// 
			this.ctmImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextBrowseImageToolStripMenuItem,
            this.contextDeleteImageToolStripMenuItem});
			this.ctmImage.Name = "ctmImage";
			this.ctmImage.Size = new System.Drawing.Size(122, 48);
			// 
			// contextBrowseImageToolStripMenuItem
			// 
			this.contextBrowseImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextBrowseImageToolStripMenuItem.Image")));
			this.contextBrowseImageToolStripMenuItem.Name = "contextBrowseImageToolStripMenuItem";
			this.contextBrowseImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.contextBrowseImageToolStripMenuItem.Text = "Browse...";
			this.contextBrowseImageToolStripMenuItem.Click += new System.EventHandler(this.contextBrowseImageToolStripMenuItem_Click);
			// 
			// contextDeleteImageToolStripMenuItem
			// 
			this.contextDeleteImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextDeleteImageToolStripMenuItem.Image")));
			this.contextDeleteImageToolStripMenuItem.Name = "contextDeleteImageToolStripMenuItem";
			this.contextDeleteImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.contextDeleteImageToolStripMenuItem.Text = "Delete";
			this.contextDeleteImageToolStripMenuItem.Click += new System.EventHandler(this.contextDeleteImageToolStripMenuItem_Click);
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
			this.stpTool.ResumeLayout(false);
			this.stpTool.PerformLayout();
			this.panMain.ResumeLayout(false);
			this.panProperties.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdProperties)).EndInit();
			this.panFields.ResumeLayout(false);
			this.panFields.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.updQuantity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
			this.ctmProperty.ResumeLayout(false);
			this.ctmImage.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
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
		private System.Windows.Forms.ContextMenuStrip ctmProperty;
		private System.Windows.Forms.ToolStripMenuItem contextPropertyEditToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contextPropertyDeleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton refreshToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton duplicateToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton showDatasheetToolStripButton;
		private System.Windows.Forms.ToolStripButton deleteDatasheetToolStripButton;
		private System.Windows.Forms.ToolStripButton downloadDatasheetToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton addPropertyToolStripButton;
		private System.Windows.Forms.ToolStripButton editPropertyToolStripButton;
		private System.Windows.Forms.ToolStripButton deletePropertyToolStripButton;
		private System.Windows.Forms.OpenFileDialog dlgOpenImage;
		private System.Windows.Forms.ContextMenuStrip ctmImage;
		private System.Windows.Forms.ToolStripMenuItem contextBrowseImageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contextDeleteImageToolStripMenuItem;
	}
}