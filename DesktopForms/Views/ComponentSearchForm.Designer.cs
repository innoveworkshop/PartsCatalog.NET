namespace PartsCatalog.DesktopForms.Views {
	partial class ComponentSearchForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentSearchForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.grpSearchParameters = new System.Windows.Forms.GroupBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.cmbPackage = new System.Windows.Forms.ComboBox();
			this.lblPackage = new System.Windows.Forms.Label();
			this.cmbCategory = new System.Windows.Forms.ComboBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.txtSearchQuery = new System.Windows.Forms.TextBox();
			this.stpStatus = new System.Windows.Forms.StatusStrip();
			this.grdResults = new System.Windows.Forms.DataGridView();
			this.grpSearchParameters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
			this.SuspendLayout();
			// 
			// grpSearchParameters
			// 
			this.grpSearchParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpSearchParameters.Controls.Add(this.btnSearch);
			this.grpSearchParameters.Controls.Add(this.cmbPackage);
			this.grpSearchParameters.Controls.Add(this.lblPackage);
			this.grpSearchParameters.Controls.Add(this.cmbCategory);
			this.grpSearchParameters.Controls.Add(this.lblCategory);
			this.grpSearchParameters.Controls.Add(this.txtSearchQuery);
			this.grpSearchParameters.Location = new System.Drawing.Point(9, 3);
			this.grpSearchParameters.Name = "grpSearchParameters";
			this.grpSearchParameters.Size = new System.Drawing.Size(595, 88);
			this.grpSearchParameters.TabIndex = 0;
			this.grpSearchParameters.TabStop = false;
			this.grpSearchParameters.Text = "Search Parameters";
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(492, 45);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(98, 33);
			this.btnSearch.TabIndex = 16;
			this.btnSearch.Text = "Search";
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// cmbPackage
			// 
			this.cmbPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPackage.FormattingEnabled = true;
			this.cmbPackage.Location = new System.Drawing.Point(308, 57);
			this.cmbPackage.Name = "cmbPackage";
			this.cmbPackage.Size = new System.Drawing.Size(178, 21);
			this.cmbPackage.TabIndex = 15;
			// 
			// lblPackage
			// 
			this.lblPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPackage.AutoSize = true;
			this.lblPackage.Location = new System.Drawing.Point(305, 42);
			this.lblPackage.Name = "lblPackage";
			this.lblPackage.Size = new System.Drawing.Size(50, 13);
			this.lblPackage.TabIndex = 14;
			this.lblPackage.Text = "Package";
			// 
			// cmbCategory
			// 
			this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCategory.FormattingEnabled = true;
			this.cmbCategory.Location = new System.Drawing.Point(6, 57);
			this.cmbCategory.Name = "cmbCategory";
			this.cmbCategory.Size = new System.Drawing.Size(293, 21);
			this.cmbCategory.TabIndex = 11;
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Location = new System.Drawing.Point(3, 42);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(49, 13);
			this.lblCategory.TabIndex = 10;
			this.lblCategory.Text = "Category";
			// 
			// txtSearchQuery
			// 
			this.txtSearchQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchQuery.Location = new System.Drawing.Point(6, 19);
			this.txtSearchQuery.Name = "txtSearchQuery";
			this.txtSearchQuery.Size = new System.Drawing.Size(584, 20);
			this.txtSearchQuery.TabIndex = 0;
			this.txtSearchQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchQuery_KeyPress);
			// 
			// stpStatus
			// 
			this.stpStatus.Location = new System.Drawing.Point(0, 382);
			this.stpStatus.Name = "stpStatus";
			this.stpStatus.Size = new System.Drawing.Size(613, 22);
			this.stpStatus.TabIndex = 2;
			this.stpStatus.Text = "statusStrip1";
			// 
			// grdResults
			// 
			this.grdResults.AllowUserToAddRows = false;
			this.grdResults.AllowUserToDeleteRows = false;
			this.grdResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grdResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.grdResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdResults.DefaultCellStyle = dataGridViewCellStyle5;
			this.grdResults.Location = new System.Drawing.Point(9, 97);
			this.grdResults.Name = "grdResults";
			this.grdResults.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.grdResults.RowHeadersVisible = false;
			this.grdResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdResults.Size = new System.Drawing.Size(595, 282);
			this.grdResults.TabIndex = 3;
			// 
			// ComponentSearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 404);
			this.Controls.Add(this.grdResults);
			this.Controls.Add(this.stpStatus);
			this.Controls.Add(this.grpSearchParameters);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ComponentSearchForm";
			this.Text = "Find Component";
			this.Load += new System.EventHandler(this.ComponentSearchForm_Load);
			this.grpSearchParameters.ResumeLayout(false);
			this.grpSearchParameters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpSearchParameters;
		private System.Windows.Forms.StatusStrip stpStatus;
		private System.Windows.Forms.DataGridView grdResults;
		private System.Windows.Forms.TextBox txtSearchQuery;
		private System.Windows.Forms.ComboBox cmbPackage;
		private System.Windows.Forms.Label lblPackage;
		private System.Windows.Forms.ComboBox cmbCategory;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.Button btnSearch;
	}
}