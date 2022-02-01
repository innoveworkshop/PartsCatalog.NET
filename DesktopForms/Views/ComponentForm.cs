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

namespace PartsCatalog.DesktopForms.Views {
	public partial class ComponentForm : Form {
		private CommonComponentControls commonComponentControls;

		/// <summary>
		/// Initializes the form with a blank "new" component.
		/// </summary>
		public ComponentForm() {
			// Populate the form and allow drag and drop of an image.
			InitializeComponent();
			picImage.AllowDrop = true;

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

			// Bind data to fields.
			AssociatedComponent.Retrieve();
			updQuantity.DataBindings.Add("Value", AssociatedComponent, "Quantity",
				true, DataSourceUpdateMode.OnPropertyChanged);
			txtName.DataBindings.Add("Text", AssociatedComponent, "Name", true,
				DataSourceUpdateMode.OnPropertyChanged);
			txtDescription.DataBindings.Add("Text", AssociatedComponent, "Description",
				true, DataSourceUpdateMode.OnPropertyChanged);

			// Populate common controls.
			commonComponentControls.PopulateWithComponent(false);

			// Populate the component image and datasheet.
			PopulateComponentImage(true);
			PopulateComponentDatasheet(false);

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
		/// Populates the component image control.
		/// </summary>
		/// <param name="retrieve">Should we retrieve the image object?</param>
		public void PopulateComponentImage(bool retrieve) {
			// Disables all of the controls when an image isn't associated.
			deleteToolStripMenuItem1.Enabled = false;
			contextDeleteImageToolStripMenuItem.Enabled = false;

			// Clear the image if there's already one in place.
			if (picImage.Image != null) {
				picImage.Image.Dispose();
				picImage.Image = null;
			}

			// Retrieve the image object.
			if (retrieve)
				AssociatedComponent.Retrieve();

			// Check if we actually have an image.
			if (AssociatedComponent.Picture.HasImage()) {
				// Associate the image.
				MemoryStream ms = new MemoryStream();
				ms.Write(AssociatedComponent.Picture.FileContent, 0,
					Convert.ToInt32(AssociatedComponent.Picture.FileContent.Length));
				picImage.Image = System.Drawing.Image.FromStream(ms);
				ms.Dispose();

				// // Enables all of the controls.
				deleteToolStripMenuItem1.Enabled = true;
				contextDeleteImageToolStripMenuItem.Enabled = true;
			} else {
				// Check if we have a package image instead.
				AssociatedComponent.Package.Retrieve();
				if (AssociatedComponent.Package.Picture.HasImage()) {
					// Associate the image.
					MemoryStream ms = new MemoryStream();
					ms.Write(AssociatedComponent.Package.Picture.FileContent, 0,
						Convert.ToInt32(AssociatedComponent.Package.Picture.FileContent.Length));
					picImage.Image = System.Drawing.Image.FromStream(ms);
					ms.Dispose();
				}
			}
		}

		/// <summary>
		/// Populates the component datasheet controls.
		/// </summary>
		/// <param name="retrieve">Should we retrieve the datasheet object?</param>
		public void PopulateComponentDatasheet(bool retrieve) {
			// Disables all of the controls when a datasheet isn't associated.
			btnDatasheet.Enabled = false;
			openToolStripMenuItem.Enabled = false;
			deleteToolStripMenuItem2.Enabled = false;

			// Retrieve the datasheet object.
			if (retrieve)
				AssociatedComponent.Retrieve();

			// Check if we actually have a datasheet available.
			if (!AssociatedComponent.Datasheet.IsAvailable())
				return;

			// Enables all of the controls.
			btnDatasheet.Enabled = true;
			openToolStripMenuItem.Enabled = true;
			deleteToolStripMenuItem2.Enabled = true;
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
		/// Sets the component image and uploads it to the server.
		/// </summary>
		/// <param name="filePath">Image file to be uploaded.</param>
		public void SetComponentImage(string filePath) {
			// Set the component image and upload the file.
			AssociatedComponent.Picture.AssociatedComponent =
				new PartsCatalog.Models.Component(AssociatedComponent.ID);
			AssociatedComponent.Picture.FileContent = File.ReadAllBytes(filePath);
			AssociatedComponent.Picture.Save();

			// Show the new image.
			PopulateComponentImage(false);
		}

		/// <summary>
		/// Browses and selects a component image and uploads it to the server.
		/// </summary>
		public void SelectComponentImage() {
			// Browse for a new component image.
			if (dlgOpenImage.ShowDialog() != DialogResult.OK)
				return;

			// Set the component image and upload the file.
			SetComponentImage(dlgOpenImage.FileName);
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

			// Actually delete the image and update the controls.
			AssociatedComponent.Picture.Delete();
			PopulateComponentImage(false);
		}

		/// <summary>
		/// Browses and selects a component datasheet and uploads it to the server.
		/// </summary>
		public void SelectComponentDatasheet() {
			// Browse for a new component datasheet.
			if (dlgOpenDatasheet.ShowDialog() != DialogResult.OK)
				return;

			// Set the component datasheet and upload the file.
			AssociatedComponent.Datasheet.AssociatedComponent =
				new PartsCatalog.Models.Component(AssociatedComponent.ID);
			AssociatedComponent.Datasheet.Upload(dlgOpenDatasheet.FileName);

			// Enable the datasheet controls.
			PopulateComponentDatasheet(false);
		}

		/// <summary>
		/// Deletes the component datasheet from the form and the server.
		/// </summary>
		public void DeleteComponentDatasheet() {
			DialogResult dialog = MessageBox.Show("Are you sure you want to delete " +
				"this component's datasheet?", "Delete component datasheet?",
				MessageBoxButtons.YesNo);

			// Ignore if the user was mistaken.
			if (dialog == DialogResult.No)
				return;

			// Actually delete the datasheet and update the controls.
			AssociatedComponent.Datasheet.Delete();
			PopulateComponentDatasheet(false);
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
		
		private void editToolStripMenuItem_Click(object sender, EventArgs e) {
			commonComponentControls.EditPropertyGridItem();
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e) {
			commonComponentControls.AddProperty();
		}

		private void deleteToolStripMenuItem3_Click(object sender, EventArgs e) {
			commonComponentControls.DeletePropertyGridItem();
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

		private void uploadToolStripMenuItem_Click(object sender, EventArgs e) {
			SelectComponentDatasheet();
		}

		private void deleteToolStripMenuItem2_Click(object sender, EventArgs e) {
			DeleteComponentDatasheet();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			AssociatedComponent.Datasheet.Open();
		}

		private void btnDatasheet_Click(object sender, EventArgs e) {
			AssociatedComponent.Datasheet.Open();
		}

		private void ComponentForm_Load(object sender, EventArgs e) {
			tslServer.Text = PartsCatalog.Configuration.Domain;
		}

		private void picImage_DragEnter(object sender, DragEventArgs e) {
			// Display a nice copy effect if we actually have a file being dropped.
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void picImage_DragDrop(object sender, DragEventArgs e) {
			// Get the file and check if we only have a single one.
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 1)
				throw new Exception("Only a single file should be dragged and dropped");

			// Associate the new image.
			SetComponentImage(files[0]);
		}
	}
}