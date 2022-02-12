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

		/// <summary>
		/// Initializes the search form.
		/// </summary>
		public ComponentSearchForm() {
			InitializeComponent();

			// Initialize the binding variables.
			categories = new BindingList<Category>();
			packages = new BindingList<Package>();

			// Setup data bindings for the comboboxes.
			cmbCategory.DataSource = categories;
			cmbCategory.DisplayMember = "Name";
			cmbCategory.ValueMember = "ID";
			cmbPackage.DataSource = packages;
			cmbPackage.DisplayMember = "Name";
			cmbPackage.ValueMember = "ID";

			// Setup the components table.
			gridHelper = new ComponentGridHelper(grdResults);
			gridHelper.SetupDefaultDoubleClickEvent();
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
	}
}