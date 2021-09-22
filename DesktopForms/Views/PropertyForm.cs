using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;

namespace PartsCatalog.DesktopForms.Views {
	public partial class PropertyForm : Form {
		private Property _property;

		/// <summary>
		/// Initializes the form for a new property.
		/// </summary>
		public PropertyForm() {
			InitializeComponent();

			Property = new Property();
			Text = "New Property";
			btnSave.Text = "Add";
		}

		/// <summary>
		/// Initializes the form with a property associated for editing.
		/// </summary>
		/// <param name="property">Property to be associated with this form.</param>
		public PropertyForm(Property property) : this() {
			Property = property;
			Text = "Edit Property";
			btnSave.Text = "Save";
		}

		/// <summary>
		/// Populates the form with data from the current property.
		/// </summary>
		private void PopulateWithProperty() {
			// Reset the bound fields.
			txtName.DataBindings.Clear();
			txtValue.DataBindings.Clear();

			// Bind data to fields.
			txtName.DataBindings.Add("Text", Property, "Name", true,
				DataSourceUpdateMode.OnPropertyChanged);
			txtValue.DataBindings.Add("Text", Property, "Value", true,
				DataSourceUpdateMode.OnPropertyChanged);
		}

		/// <summary>
		/// Property associated with this form.
		/// </summary>
		public Property Property {
			get { return _property; }
			set { _property = value; PopulateWithProperty(); }
		}

		/******************
		 * Event Handlers *
		 ******************/

		private void btnCancel_Click(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			Property.Save();

			this.DialogResult = DialogResult.Yes;
			Close();
		}
	}
}