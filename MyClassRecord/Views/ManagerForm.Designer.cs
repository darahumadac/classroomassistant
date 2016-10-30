using System.Windows.Forms;

namespace MyClassRecord.Views
{
    partial class ManagerForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.showAllBtn = new System.Windows.Forms.Button();
            this.listGridView = new System.Windows.Forms.DataGridView();
            this.addBtn = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.findLbl = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.totalRecordsLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // showAllBtn
            // 
            this.showAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showAllBtn.Location = new System.Drawing.Point(14, 322);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(75, 23);
            this.showAllBtn.TabIndex = 10;
            this.showAllBtn.Text = "Show All";
            this.showAllBtn.UseVisualStyleBackColor = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // listGridView
            // 
            this.listGridView.AllowUserToAddRows = false;
            this.listGridView.AllowUserToDeleteRows = false;
            this.listGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.listGridView.Location = new System.Drawing.Point(14, 58);
            this.listGridView.MultiSelect = false;
            this.listGridView.Name = "listGridView";
            this.listGridView.ReadOnly = true;
            this.listGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listGridView.Size = new System.Drawing.Size(628, 252);
            this.listGridView.TabIndex = 8;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(567, 23);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 9;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.searchTxt.Location = new System.Drawing.Point(119, 25);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(111, 20);
            this.searchTxt.TabIndex = 11;
            // 
            // findLbl
            // 
            this.findLbl.AutoSize = true;
            this.findLbl.Location = new System.Drawing.Point(9, 28);
            this.findLbl.Name = "findLbl";
            this.findLbl.Size = new System.Drawing.Size(27, 13);
            this.findLbl.TabIndex = 12;
            this.findLbl.Text = "Find";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(236, 23);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(54, 23);
            this.searchBtn.TabIndex = 13;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.Enabled = false;
            this.editBtn.Location = new System.Drawing.Point(567, 322);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 14;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // totalRecordsLbl
            // 
            this.totalRecordsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalRecordsLbl.AutoSize = true;
            this.totalRecordsLbl.Location = new System.Drawing.Point(95, 327);
            this.totalRecordsLbl.Name = "totalRecordsLbl";
            this.totalRecordsLbl.Size = new System.Drawing.Size(106, 13);
            this.totalRecordsLbl.TabIndex = 16;
            this.totalRecordsLbl.Text = "{0} records displayed";
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 367);
            this.Controls.Add(this.totalRecordsLbl);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.findLbl);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.showAllBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.listGridView);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            ((System.ComponentModel.ISupportInitialize)(this.listGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button showAllBtn;
        internal DataGridView listGridView;
        internal Button addBtn;
        internal TextBox searchTxt;
        internal Button searchBtn;
        internal Button editBtn;
        internal Label totalRecordsLbl;
        internal Label findLbl;

    }
}