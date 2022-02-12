using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using PartsCatalog.Models;
using PartsCatalog.DesktopForms.Views;

namespace PartsCatalog.DesktopForms.Utilities {
	/// <summary>
	/// A little helper class to manage a component <see cref="DataGridView"/>.
	/// </summary>
	public class ComponentGridHelper {
		private DataGridView grdComponents;
		private BindingList<PartsCatalog.Models.Component> partsComponents;

		/// <summary>
		/// Initializes this helper class with its associated component grid view.
		/// </summary>
		/// <param name="grdComponents">Component grid view.</param>
		public ComponentGridHelper(DataGridView grdComponents) {
			// Initialize components.
			this.grdComponents = grdComponents;
			partsComponents = new BindingList<PartsCatalog.Models.Component>();

			// Setup the components table data source.
			SetupGridView();
			grdComponents.DataSource = partsComponents;
			SetupGridColumns();
		}

		/// <summary>
		/// Clears the data in the grid view.
		/// </summary>
		public void Clear() {
			partsComponents.Clear();
		}

		/// <summary>
		/// Populates the components table view with data from a specific criteria.
		/// </summary>
		/// <param name="criteria">Object that will be used as criteria for
		/// fetching the components via the <see cref="PartsCatalog.Models.List<T>"/>
		/// call.</param>
		/// <param name="queryParam">URL parameter query name.</param>
		public void PopulateWithCriteria<T>(RemoteObject<T> criteria, string queryParam)
				where T : RemoteObject<T>, new() {
			if (criteria == null)
				return;

			new PartsCatalog.Models.Component().List<T>(partsComponents, queryParam, criteria);
		}

		/// <summary>
		/// Sets up the default double-click event for each cell to open the
		/// component view window.
		/// </summary>
		public void SetupDefaultDoubleClickEvent() {
			grdComponents.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(ShowSelectedComponentEvent);
		}

		/// <summary>
		/// Sets up the <see cref="DataGridView"/> visual parameters.
		/// </summary>
		protected void SetupGridView() {
			// Previously set in the visual editor.
			grdComponents.AllowUserToAddRows = false;
			grdComponents.AllowUserToDeleteRows = false;
			grdComponents.BorderStyle = BorderStyle.Fixed3D;
			grdComponents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			grdComponents.ReadOnly = true;
			grdComponents.RowHeadersVisible = false;
			grdComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			// Custom stuff.
			grdComponents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			grdComponents.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
			SetupGridDoubleBuffering(grdComponents);
		}

		/// <summary>
		/// Sets up all of the grid columns and their styles.
		/// </summary>
		protected void SetupGridColumns() {
			// Quantity
			grdComponents.Columns["Quantity"].DisplayIndex = 0;
			grdComponents.Columns["Quantity"].Width = 45;
			grdComponents.Columns["Quantity"].HeaderText = "Qnt";

			// Name
			grdComponents.Columns["Name"].DisplayIndex = 1;
			grdComponents.Columns["Name"].Width = 100;

			// Description
			grdComponents.Columns["Description"].DisplayIndex = 2;
			grdComponents.Columns["Description"].Width = 255;

			// Package
			grdComponents.Columns["Package"].DisplayIndex = 3;
			grdComponents.Columns["Package"].Width = 80;

			// Category
			grdComponents.Columns["Category"].DisplayIndex = 4;
			grdComponents.Columns["Category"].Width = 115;

			// Sub-Category
			grdComponents.Columns["SubCategory"].DisplayIndex = 5;
			grdComponents.Columns["SubCategory"].Width = 115;
			grdComponents.Columns["SubCategory"].HeaderText = "Sub-Category";

			// Picture
			grdComponents.Columns["Picture"].Visible = false;

			// Datasheet
			grdComponents.Columns["Datasheet"].Visible = false;

			// ID
			grdComponents.Columns["ID"].DisplayIndex = 8;
			grdComponents.Columns["ID"].Width = 35;
		}

		/// <summary>
		/// Enables double buffering to improve the performance in a <see cref="DataGridView"/>
		/// </summary>
		/// <param name="gridView">Grid view to have double buffering enabled.</param>
		private void SetupGridDoubleBuffering(DataGridView gridView) {
			// Make sure we are not running under Remote Desktop.
			if (!System.Windows.Forms.SystemInformation.TerminalServerSession) {
				Type dgvType = gridView.GetType();

				PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
					BindingFlags.Instance | BindingFlags.NonPublic);
				pi.SetValue(gridView, true, null);
			}
		}

		/******************
		 * Event Handlers *
		 ******************/

		protected void ShowSelectedComponentEvent(object sender, DataGridViewCellMouseEventArgs e) {
			ComponentForm form = new ComponentForm(
				(PartsCatalog.Models.Component)grdComponents.CurrentRow.DataBoundItem);
			form.Show();
		}
	}
}
