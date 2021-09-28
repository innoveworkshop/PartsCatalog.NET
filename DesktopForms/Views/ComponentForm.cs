using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;

namespace PartsCatalog.DesktopForms.Views {
	public partial class ComponentForm : Form {
		private PartsCatalog.Models.Component _component;
		private BindingList<Property> properties;
		private BindingList<Category> categories;
		private BindingList<SubCategory> subCategories;
		private BindingList<Package> packages;

		/// <summary>
		/// Initializes the form with a blank "new" component.
		/// </summary>
		public ComponentForm() {
			InitializeComponent();
			properties = new BindingList<Property>();
			categories = new BindingList<Category>();
			subCategories = new BindingList<SubCategory>();
			packages = new BindingList<Package>();

			// Setup data bindings for the combo boxes.
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

			// Associate a blank component.
			AssociatedComponent = new PartsCatalog.Models.Component();
		}

		/// <summary>
		/// Initializes the form with the specified component loaded and populated.
		/// </summary>
		/// <param name="component">Component to be associated with this form.</param>
		public ComponentForm(PartsCatalog.Models.Component component) : this() {
			AssociatedComponent = component;
		}

		/// <summary>
		/// Populates the form with the currently associated component data.
		/// </summary>
		private void PopulateWithComponent() {
			// Reset the bound fields.
			updQuantity.DataBindings.Clear();
			txtName.DataBindings.Clear();
			txtDescription.DataBindings.Clear();

			// Bind data to fields.
			AssociatedComponent.Retrieve();
			updQuantity.DataBindings.Add("Value", AssociatedComponent, "Quantity",
				true, DataSourceUpdateMode.OnPropertyChanged);
			txtName.DataBindings.Add("Text", AssociatedComponent, "Name", true,
				DataSourceUpdateMode.OnPropertyChanged);
			txtDescription.DataBindings.Add("Text", AssociatedComponent, "Description",
				true, DataSourceUpdateMode.OnPropertyChanged);

			// Deal with the lists.
			PopulateCategoriesList();
			PopulatePackagesList();
			if (AssociatedComponent.IsPersistent()) {
				cmbCategory.SelectedValue = AssociatedComponent.Category.ID;
				cmbSubCategory.SelectedValue = AssociatedComponent.SubCategory.ID;
				cmbPackage.SelectedValue = AssociatedComponent.Package.ID;
			}

			// Populate the properties table.
			properties.Clear();
			foreach (Property property in AssociatedComponent.Properties) {
				properties.Add(property);
			}

			// Populate the component image.
			PopulateComponentImage(true);

			// Notify the user.
			if (AssociatedComponent.IsPersistent()) {
				Text = AssociatedComponent.Name;
				StatusText = "Component data loaded successfully";
				StatusID = AssociatedComponent.ID.ToString();
			} else {
				Text = "New Component";
				StatusText = "Creating a new component";
				StatusID = "New";
			}
		}

		/// <summary>
		/// Populates the categories list with data from the database.
		/// </summary>
		public void PopulateCategoriesList() {
			categories.Clear();
			new Category().List(categories);
		}

		/// <summary>
		/// Populates the sub-categories list with data from the database.
		/// </summary>
		/// <param name="parent">Parent category.</param>
		public void PopulateSubCategoriesList(Category parent) {
			subCategories.Clear();
			foreach (SubCategory subCategory in parent.SubCategories) {
				subCategories.Add(subCategory);
			}
		}

		/// <summary>
		/// Populates the packages list with data from the database.
		/// </summary>
		public void PopulatePackagesList() {
			packages.Clear();
			new Package().List(packages);
		}

		/// <summary>
		/// Populates the component image control.
		/// </summary>
		/// <param name="retrieve">Should we retrieve the image object?</param>
		public void PopulateComponentImage(bool retrieve) {
			// Clear the image if there's already one in place.
			if (picImage.Image != null) {
				picImage.Image.Dispose();
				picImage.Image = null;
			}

			// Retrieve the image object.
			if (retrieve)
				AssociatedComponent.Retrieve();

			// Associate the image.
			if (AssociatedComponent.Picture.HasImage()) {
				MemoryStream ms = new MemoryStream();

				ms.Write(AssociatedComponent.Picture.FileContent, 0,
					Convert.ToInt32(AssociatedComponent.Picture.FileContent.Length));
				picImage.Image = System.Drawing.Image.FromStream(ms);
				
				ms.Dispose();
			}
		}

		/// <summary>
		/// Asks the user if they really want to delete the property and delete if
		/// they actually want it.
		/// </summary>
		/// <param name="property">Property to be deleted.</param>
		public void DeleteAssociatedComponent() {
			DialogResult dialog = MessageBox.Show("Are you sure you want to delete " +
				"the '" + AssociatedComponent.Name + "' component?",
				"Delete component?", MessageBoxButtons.YesNo);

			// Ignore if the user was mistaken.
			if (dialog == DialogResult.No)
				return;

			// Delete the component from the remote server.
			AssociatedComponent.Delete();
		}

		/// <summary>
		/// Opens the dialog for adding a new property.
		/// </summary>
		public void AddProperty() {
			Property property = new Property();
			property.Parent = AssociatedComponent;

			PropertyForm form = new PropertyForm(property);
			form.StartPosition = FormStartPosition.CenterParent;
			DialogResult result = form.ShowDialog(this);

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
			form.ShowDialog(this);
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
		/// Browses and selects a component image and uploads it to the server.
		/// </summary>
		public void SelectComponentImage() {
			// Browse for a new component image.
			if (dlgOpenImage.ShowDialog() != DialogResult.OK)
				return;

			// Set the component image and upload the file.
			AssociatedComponent.Picture.AssociatedComponent =
				new PartsCatalog.Models.Component(AssociatedComponent.ID);
			AssociatedComponent.Picture.FileContent = File.ReadAllBytes(
				dlgOpenImage.FileName);
			AssociatedComponent.Picture.Save();

			// Show the new image.
			PopulateComponentImage(false);
		}

		/// <summary>
		/// Deletes the component image from the form and the server.
		/// </summary>
		public void DeleteComponentImage() {
			DialogResult dialog = MessageBox.Show("Are you sure you want to delete " +
				"this component's image?", "Delete component image?",
				MessageBoxButtons.YesNo);

			// Ignore if the user was mistaken.
			if (dialog == DialogResult.No)
				return;

			// Actually delete the image.
			AssociatedComponent.Picture.Delete();
			if (picImage.Image != null) {
				picImage.Image.Dispose();
				picImage.Image = null;
			}
		}

		/// <summary>
		/// Component that is associated with this form.
		/// </summary>
		public PartsCatalog.Models.Component AssociatedComponent {
			get { return _component; }
			set { _component = value; PopulateWithComponent(); }
		}

		/// <summary>
		/// Form's status bar notification text.
		/// </summary>
		public string StatusText {
			get { return tslNotification.Text; }
			set { tslNotification.Text = value; }
		}

		/// <summary>
		/// Form's status bar ID text.
		/// </summary>
		public string StatusID {
			get { return tslID.Text; }
			set { tslID.Text = value; }
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

		private void editToolStripMenuItem_Click(object sender, EventArgs e) {
			Property property = (Property)grdProperties.CurrentRow.DataBoundItem;
			if (property == null)
				return;

			EditProperty(property);
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e) {
			AddProperty();
		}

		private void deleteToolStripMenuItem3_Click(object sender, EventArgs e) {
			Property property = (Property)grdProperties.CurrentRow.DataBoundItem;
			if (property == null)
				return;

			DeleteProperty(property);
		}

		private void contextPropertyEditToolStripMenuItem_Click(object sender, EventArgs e) {
			editToolStripMenuItem_Click(sender, e);
		}

		private void contextPropertyDeleteToolStripMenuItem_Click(object sender, EventArgs e) {
			deleteToolStripMenuItem3_Click(sender, e);
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

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
			PopulateWithComponent();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			AssociatedComponent.Save();
			PopulateWithComponent();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteAssociatedComponent();
			Close();
		}

		private void refreshToolStripButton_Click(object sender, EventArgs e) {
			refreshToolStripMenuItem_Click(sender, e);
		}

		private void saveToolStripButton_Click(object sender, EventArgs e) {
			saveToolStripMenuItem_Click(sender, e);
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e) {
			deleteToolStripMenuItem_Click(sender, e);
		}

		private void addPropertyToolStripButton_Click(object sender, EventArgs e) {
			addToolStripMenuItem_Click(sender, e);
		}

		private void editPropertyToolStripButton_Click(object sender, EventArgs e) {
			editToolStripMenuItem_Click(sender, e);
		}

		private void deletePropertyToolStripButton_Click(object sender, EventArgs e) {
			deleteToolStripMenuItem3_Click(sender, e);
		}

		private void browseToolStripMenuItem_Click(object sender, EventArgs e) {
			SelectComponentImage();
		}

		private void deleteToolStripMenuItem1_Click(object sender, EventArgs e) {
			DeleteComponentImage();
		}

		private void contextBrowseImageToolStripMenuItem_Click(object sender, EventArgs e) {
			SelectComponentImage();
		}

		private void contextDeleteImageToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteComponentImage();
		}
	}
}