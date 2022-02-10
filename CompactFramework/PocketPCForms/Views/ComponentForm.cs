using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;
using PartsCatalog.DesktopForms.Utilities;

namespace PartsCatalog.PocketPCForms.Views {
	public partial class ComponentForm : Form {
		private CommonComponentControls commonComponentControls;

		/// <summary>
		/// Initializes the form with a blank "new" component.
		/// </summary>
		public ComponentForm() {
			// Populate the form and allow drag and drop of an image.
			InitializeComponent();

			// Setup the common component controls.
			commonComponentControls = new CommonComponentControls(
				this, new PartsCatalog.Models.Component(), cmbCategory,
				cmbSubCategory, cmbPackage, grdProperties);
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

			// Populate common controls.
			commonComponentControls.PopulateWithComponent(false);

			// Bind data to fields.
			updQuantity.DataBindings.Add("Value", AssociatedComponent, "Quantity",
				true, DataSourceUpdateMode.OnPropertyChanged);
			txtName.DataBindings.Add("Text", AssociatedComponent, "Name", true,
				DataSourceUpdateMode.OnPropertyChanged);
			txtDescription.DataBindings.Add("Text", AssociatedComponent, "Description",
				true, DataSourceUpdateMode.OnPropertyChanged);

			// Populate the component image and datasheet.
			//PopulateComponentImage(true);
			//PopulateComponentDatasheet(false);

			// Notify the user.
			if (AssociatedComponent.IsPersistent()) {
				Text = AssociatedComponent.Name;
			} else {
				Text = "New Component";
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
				"Delete component?", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2);

			// Ignore if the user was mistaken.
			if (dialog == DialogResult.No)
				return;

			// Delete the component from the remote server.
			AssociatedComponent.Delete();
		}

		/// <summary>
		/// Component that is associated with this form.
		/// </summary>
		public PartsCatalog.Models.Component AssociatedComponent {
			get { return commonComponentControls.AssociatedComponent; }
			set {
				commonComponentControls.AssociatedComponent = value;
				PopulateWithComponent();
			}
		}

		/******************
		 * Event Handlers *
		 ******************/

		private void mniSave_Click(object sender, EventArgs e) {
			AssociatedComponent.Save();
			PopulateWithComponent();
		}

		private void mniRefresh_Click(object sender, EventArgs e) {
			PopulateWithComponent();
		}

		private void mniDelete_Click(object sender, EventArgs e) {
			DeleteAssociatedComponent();
			Close();
		}
	}
}