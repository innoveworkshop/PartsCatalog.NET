using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PartsCatalog.Models;

namespace PartsCatalog.PocketPCForms.Views {
	public partial class PropertyForm : Form {
		public PropertyForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Initializes the form with a property associated for editing.
		/// </summary>
		/// <param name="property">Property to be associated with this form.</param>
		public PropertyForm(Property property) : this() {
			//Property = property;
			Text = "Edit Property";
			//btnSave.Text = "Save";
		}
	}
}