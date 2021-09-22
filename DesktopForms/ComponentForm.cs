using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;

namespace DesktopForms {
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
			updQuantity.DataBindings.Add("Value", AssociatedComponent, "Quantity");
			txtName.DataBindings.Add("Text", AssociatedComponent, "Name");
			txtDescription.DataBindings.Add("Text", AssociatedComponent, "Description");
			grdProperties.DataSource = AssociatedComponent.Properties;

			// Deal with the lists.
			PopulateCategoriesList();
			PopulatePackagesList();
			if (AssociatedComponent.IsPersistent()) {
				cmbCategory.SelectedValue = AssociatedComponent.Category.ID;
				cmbSubCategory.SelectedValue = AssociatedComponent.SubCategory.ID;
				cmbPackage.SelectedValue = AssociatedComponent.Package.ID;
			}

			// Refresh the properties table.
			properties.Clear();
			foreach (Property property in AssociatedComponent.Properties) {
				properties.Add(property);
			}

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
	}
}