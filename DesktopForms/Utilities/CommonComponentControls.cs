using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using PartsCatalog.Models;
using PartsCatalog.DesktopForms.Views;

namespace PartsCatalog.DesktopForms.Utilities {
	/// <summary>
	/// Utility class to help out with some common component controls for
	/// things like Category, Sub-Category, and Package comboboxes.
	/// </summary>
	public class CommonComponentControls {
		// Controls.
		private Form frmParent;
		private ComboBox cmbCategory;
		private ComboBox cmbSubCategory;
		private ComboBox cmbPackage;
		private DataGridView grdProperties;

		// Properties grid context menu.
		private ContextMenuStrip ctmProperty;
		private ToolStripMenuItem contextPropertyEditToolStripMenuItem;
		private ToolStripMenuItem contextPropertyDeleteToolStripMenuItem;

		// Binding variables.
		private PartsCatalog.Models.Component _component;
		private BindingList<Property> properties;
		private BindingList<Category> categories;
		private BindingList<SubCategory> subCategories;
		private BindingList<Package> packages;

		/// <summary>
		/// Initializes the controls.
		/// </summary>
		/// <param name="frmParent">Parent form.</param>
		/// <param name="component">Associated component.</param>
		/// <param name="cmbCategory">Category combobox control.</param>
		/// <param name="cmbSubCategory">Sub-Category combobox control.</param>
		/// <param name="cmbPackage">Package combobox control.</param>
		/// <param name="grdProperties">Properties table control.</param>
		public CommonComponentControls(Form frmParent, PartsCatalog.Models.Component component,
				ComboBox cmbCategory, ComboBox cmbSubCategory, ComboBox cmbPackage,
				DataGridView grdProperties) {
			// Initialize the binding variables.
			properties = new BindingList<Property>();
			categories = new BindingList<Category>();
			subCategories = new BindingList<SubCategory>();
			packages = new BindingList<Package>();

			// Grab the controls.
			this.frmParent = frmParent;
			this.cmbCategory = cmbCategory;
			this.cmbSubCategory = cmbSubCategory;
			this.cmbPackage = cmbPackage;
			this.grdProperties = grdProperties;

			// Setup the event bindings.
			SetupPropertiesContextMenu();
			this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
			this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
			this.cmbPackage.SelectedIndexChanged += new System.EventHandler(this.cmbPackage_SelectedIndexChanged);
			this.grdProperties.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdProperties_MouseClick);
			this.grdProperties.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdProperties_CellMouseDoubleClick);

			// Setup data bindings for the comboboxes.
			cmbCategory.DataSource = categories;
			cmbCategory.DisplayMember = "Name";
			cmbCategory.ValueMember = "ID";
			cmbSubCategory.DataSource = subCategories;
			cmbSubCategory.DisplayMember = "Name";
			cmbSubCategory.ValueMember = "ID";
			cmbPackage.DataSource = packages;
			cmbPackage.DisplayMember = "Name";
			cmbPackage.ValueMember = "ID";

			// Setup the properties table.
			grdProperties.AutoGenerateColumns = false;
			grdProperties.DataSource = properties;
			grdProperties.Columns.Add("Name", "Property");
			grdProperties.Columns.Add("Value", "Value");
			grdProperties.Columns["Name"].DataPropertyName = "Name";
			grdProperties.Columns["Value"].DataPropertyName = "Value";
			grdProperties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			grdProperties.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			grdProperties.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			// Associate component.
			AssociatedComponent = component;
		}

		/// <summary>
		/// Populates the controls with the currently associated component data.
		/// </summary>
		/// <param name="retrieveComponent">Should we retrieve the component data?</param>
		public void PopulateWithComponent(bool retrieveComponent) {
			// Update the component data.
			if (retrieveComponent)
				AssociatedComponent.Retrieve();

			// Deal with the lists.
			PopulateCategoriesList();
			PopulatePackagesList();
			cmbCategory.SelectedValue = GetCategoryID();
			cmbSubCategory.SelectedValue = GetSubCategoryID();
			cmbPackage.SelectedValue = GetPackageID();

			// Populate the properties table.
			properties.Clear();
			foreach (Property property in AssociatedComponent.Properties) {
				properties.Add(property);
			}
		}

		/// <summary>
		/// Populates the categories list with data from the database.
		/// </summary>
		protected void PopulateCategoriesList() {
			categories.Clear();
			new Category().List(categories);
		}

		/// <summary>
		/// Populates the sub-categories list with data from the database.
		/// </summary>
		/// <param name="parent">Parent category.</param>
		protected void PopulateSubCategoriesList(Category parent) {
			subCategories.Clear();
			foreach (SubCategory subCategory in parent.SubCategories) {
				subCategories.Add(subCategory);
			}
		}

		/// <summary>
		/// Populates the packages list with data from the database.
		/// </summary>
		protected void PopulatePackagesList() {
			packages.Clear();
			new Package().List(packages);
		}

		/// <summary>
		/// Opens the dialog for adding a new property.
		/// </summary>
		public void AddProperty() {
			Property property = new Property();
			property.Parent = AssociatedComponent;

			PropertyForm form = new PropertyForm(property);
			form.StartPosition = FormStartPosition.CenterParent;
			DialogResult result = form.ShowDialog(frmParent);

			// Append the new property to the lists if the user saved it.
			if (result == DialogResult.Yes) {
				AssociatedComponent.Properties.Add(property);
				properties.Add(property);
			}
		}

		/// <summary>
		/// Opens the dialog for editing a selected property.
		/// </summary>
		/// <param name="property">Property to be edited.</param>
		public void EditProperty(Property property) {
			PropertyForm form = new PropertyForm(property);
			form.StartPosition = FormStartPosition.CenterParent;
			form.ShowDialog(frmParent);
		}

		/// <summary>
		/// Asks the user if they really want to delete the property and delete if
		/// they actually want it.
		/// </summary>
		/// <param name="property">Property to be deleted.</param>
		public void DeleteProperty(Property property) {
			DialogResult dialog = MessageBox.Show("Are you sure you want to delete " +
				"the property '" + property.Name + "'?", "Delete component property?",
				MessageBoxButtons.YesNo);

			// Ignore if the user was mistaken.
			if (dialog == DialogResult.No)
				return;

			// Delete the property from the remote server and from the local lists.
			property.Delete();
			AssociatedComponent.Properties.Remove(property);
			properties.Remove(property);
		}

		/// <summary>
		/// Sets up the context menu used by the properties grid.
		/// </summary>
		protected void SetupPropertiesContextMenu() {
			// Creates all of the context menu controls.
			this.ctmProperty = new System.Windows.Forms.ContextMenuStrip();
			this.contextPropertyEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextPropertyDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctmProperty.SuspendLayout();
			
			// Context menu.
			this.ctmProperty.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextPropertyEditToolStripMenuItem,
            this.contextPropertyDeleteToolStripMenuItem});
			this.ctmProperty.Name = "ctmProperty";
			this.ctmProperty.Size = new System.Drawing.Size(108, 48);
			
			// Edit menu item.
			//this.contextPropertyEditToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextPropertyEditToolStripMenuItem.Image")));
			this.contextPropertyEditToolStripMenuItem.Name = "contextPropertyEditToolStripMenuItem";
			this.contextPropertyEditToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.contextPropertyEditToolStripMenuItem.Text = "Edit...";
			this.contextPropertyEditToolStripMenuItem.Click += new System.EventHandler(this.contextPropertyEditToolStripMenuItem_Click);
			
			// Delete menu item.
			//this.contextPropertyDeleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contextPropertyDeleteToolStripMenuItem.Image")));
			this.contextPropertyDeleteToolStripMenuItem.Name = "contextPropertyDeleteToolStripMenuItem";
			this.contextPropertyDeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.contextPropertyDeleteToolStripMenuItem.Text = "Delete";
			this.contextPropertyDeleteToolStripMenuItem.Click += new System.EventHandler(this.contextPropertyDeleteToolStripMenuItem_Click);

			this.ctmProperty.ResumeLayout(false);
		}

		/// <summary>
		/// Gets the associated component category ID.
		/// </summary>
		/// <returns></returns>
		public int GetCategoryID() {
			if (AssociatedComponent.Category != null)
				return AssociatedComponent.Category.ID;

			return -1;
		}

		/// <summary>
		/// Gets the associated component sub-category ID.
		/// </summary>
		/// <returns></returns>
		public int GetSubCategoryID() {
			if (AssociatedComponent.SubCategory != null)
				return AssociatedComponent.SubCategory.ID;

			return -1;
		}

		/// <summary>
		/// Gets the associated component package ID.
		/// </summary>
		/// <returns></returns>
		public int GetPackageID() {
			if (AssociatedComponent.Package != null)
				return AssociatedComponent.Package.ID;

			return -1;
		}

		/// <summary>
		/// Edits the currently selected property item in the table.
		/// </summary>
		public void EditPropertyGridItem() {
			Property property = (Property)grdProperties.CurrentRow.DataBoundItem;
			if (property == null)
				return;

			EditProperty(property);
		}

		/// <summary>
		/// Deletes the currently selected property item in the table.
		/// </summary>
		public void DeletePropertyGridItem() {
			Property property = (Property)grdProperties.CurrentRow.DataBoundItem;
			if (property == null)
				return;

			DeleteProperty(property);
		}

		/// <summary>
		/// Component that is associated with this object.
		/// </summary>
		public PartsCatalog.Models.Component AssociatedComponent {
			get { return _component; }
			set { _component = value; PopulateWithComponent(true); }
		}

		/******************
		 * Event Handlers *
		 ******************/

		private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) {
			Category category = (Category)cmbCategory.SelectedItem;
			if (category == null)
				return;

			AssociatedComponent.Category = category;
			PopulateSubCategoriesList(AssociatedComponent.Category);
		}

		private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e) {
			SubCategory subCategory = (SubCategory)cmbSubCategory.SelectedItem;
			if (subCategory == null)
				return;

			AssociatedComponent.SubCategory = subCategory;
		}

		private void cmbPackage_SelectedIndexChanged(object sender, EventArgs e) {
			Package package = (Package)cmbPackage.SelectedItem;
			if (package == null)
				return;

			AssociatedComponent.Package = package;
		}

		private void grdProperties_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
			Property property = (Property)grdProperties.CurrentRow.DataBoundItem;
			EditProperty(property);
		}

		private void grdProperties_MouseClick(object sender, MouseEventArgs e) {
			// Select the row where the right button was clicked and show the context menu.
			if (e.Button == MouseButtons.Right) {
				int row = grdProperties.HitTest(e.X, e.Y).RowIndex;

				// Check if we actually were hovering a row.
				if (row == -1)
					return;

				grdProperties.ClearSelection();
				grdProperties.Rows[row].Selected = true;
				grdProperties.CurrentCell = grdProperties.Rows[row].Cells[0];
				ctmProperty.Show((Control)sender, new Point(e.X, e.Y));
			}
		}

		private void contextPropertyEditToolStripMenuItem_Click(object sender, EventArgs e) {
			EditPropertyGridItem();
		}

		private void contextPropertyDeleteToolStripMenuItem_Click(object sender, EventArgs e) {
			DeletePropertyGridItem();
		}
	}
}
