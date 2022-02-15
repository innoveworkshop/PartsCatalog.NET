using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;
using PartsCatalog.DesktopForms.Views;
using PartsCatalog.DesktopForms.Utilities;

namespace PartsCatalog.DesktopForms.Views {
	/// <summary>
	/// A simple component search form.
	/// </summary>
	public partial class ComponentSearchForm : Form {
		private BindingList<Category> categories;
		private BindingList<Package> packages;
		private ComponentGridHelper gridHelper;
		private bool isSelecting;
		private PartsCatalog.Models.Component _selectedComponent;

		/// <summary>
		/// Initializes the search form.
		/// </summary>
		public ComponentSearchForm() {
			InitializeComponent();

			// Initialize the binding variables.
			categories = new BindingList<Category>();
			packages = new BindingList<Package>();
			isSelecting = false;
			SelectedComponent = null;

			// Setup data bindings for the comboboxes.
			cmbCategory.DataSource = categories;
			cmbCategory.DisplayMember = "Name";
			cmbCategory.ValueMember = "ID";
			cmbPackage.DataSource = packages;
			cmbPackage.DisplayMember = "Name";
			cmbPackage.ValueMember = "ID";

			// Setup the components table.
			gridHelper = new ComponentGridHelper(grdResults);
		}

		/// <summary>
		/// Shows the form as a dialog for selecting a component.
		/// </summary>
		/// <param name="owner">Owner of this dialog.</param>
		/// <returns>DialogResult.OK if a selection was made.</returns>
		public DialogResult ShowDialogSelection(IWin32Window owner) {
			isSelecting = true;
			return ShowDialog(owner);
		}

		/// <summary>
		/// Populates the categories combobox.
		/// </summary>
		public void PopulateCategories() {
			new Category().List(categories);
			cmbCategory.SelectedIndex = -1;
		}

		/// <summary>
		/// Populates the packages combobox.
		/// </summary>
		public void PopulatePackages() {
			new Package().List(packages);
			cmbPackage.SelectedIndex = -1;
		}

		/// <summary>
		/// Performs a search.
		/// </summary>
		protected void PerformSearch() {
			string query = txtSearchQuery.Text;

			// Include the category if requested.
			Category category = (Category)cmbCategory.SelectedItem;
			if (category != null)
				query += " category:" + category.ID;

			// Include the package if requested.
			Package package = (Package)cmbPackage.SelectedItem;
			if (package != null)
				query += " package:" + package.ID;

			// Search for the components.
			gridHelper.SearchComponents(query);
		}

		/// <summary>
		/// Component selected by the user.
		/// </summary>
		public PartsCatalog.Models.Component SelectedComponent {
			get { return _selectedComponent; }
			protected set {
				_selectedComponent = value;

				if (isSelecting)
					this.DialogResult = DialogResult.OK;
			}
		}

		/******************
		 * Event Handlers *
		 ******************/

		private void ComponentSearchForm_Load(object sender, EventArgs e) {
			PopulateCategories();
			PopulatePackages();
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			PerformSearch();
		}

		private void txtSearchQuery_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == (char)Keys.Enter)
				PerformSearch();
		}

		private void grdResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
			// Just show the component if we are not performing a selection.
			if (!isSelecting) {
				gridHelper.ShowSelectedComponentDefaultEvent(sender, null);
				return;
			}

			// Select the component.
			SelectedComponent = (PartsCatalog.Models.Component)grdResults.CurrentRow.DataBoundItem;
		}
	}
}