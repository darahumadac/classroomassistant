namespace MyClassRecord.Views
{
    partial class AddEditStudentForm
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
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.middelNameLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.middleNameTxt = new System.Windows.Forms.TextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.classDropdown = new System.Windows.Forms.ComboBox();
            this.activeCheckbox = new System.Windows.Forms.CheckBox();
            this.studentNoTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Location = new System.Drawing.Point(39, 95);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(57, 13);
            this.firstNameLbl.TabIndex = 0;
            this.firstNameLbl.Text = "First Name";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Location = new System.Drawing.Point(38, 147);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(58, 13);
            this.lastNameLbl.TabIndex = 1;
            this.lastNameLbl.Text = "Last Name";
            // 
            // middelNameLbl
            // 
            this.middelNameLbl.AutoSize = true;
            this.middelNameLbl.Location = new System.Drawing.Point(27, 121);
            this.middelNameLbl.Name = "middelNameLbl";
            this.middelNameLbl.Size = new System.Drawing.Size(69, 13);
            this.middelNameLbl.TabIndex = 2;
            this.middelNameLbl.Text = "Middle Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grade/Section";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.firstNameTxt.Location = new System.Drawing.Point(102, 92);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(140, 20);
            this.firstNameTxt.TabIndex = 5;
            // 
            // middleNameTxt
            // 
            this.middleNameTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.middleNameTxt.Location = new System.Drawing.Point(102, 118);
            this.middleNameTxt.Name = "middleNameTxt";
            this.middleNameTxt.Size = new System.Drawing.Size(140, 20);
            this.middleNameTxt.TabIndex = 6;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.lastNameTxt.Location = new System.Drawing.Point(102, 144);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(140, 20);
            this.lastNameTxt.TabIndex = 7;
            // 
            // classDropdown
            // 
            this.classDropdown.FormattingEnabled = true;
            this.classDropdown.Location = new System.Drawing.Point(103, 187);
            this.classDropdown.Name = "classDropdown";
            this.classDropdown.Size = new System.Drawing.Size(139, 21);
            this.classDropdown.TabIndex = 8;
            // 
            // activeCheckbox
            // 
            this.activeCheckbox.AutoSize = true;
            this.activeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeCheckbox.Location = new System.Drawing.Point(54, 225);
            this.activeCheckbox.Name = "activeCheckbox";
            this.activeCheckbox.Size = new System.Drawing.Size(62, 17);
            this.activeCheckbox.TabIndex = 9;
            this.activeCheckbox.Text = "Active?";
            this.activeCheckbox.UseVisualStyleBackColor = true;
            // 
            // studentNoTxt
            // 
            this.studentNoTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.studentNoTxt.Location = new System.Drawing.Point(102, 52);
            this.studentNoTxt.Name = "studentNoTxt";
            this.studentNoTxt.Size = new System.Drawing.Size(140, 20);
            this.studentNoTxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Student No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "*All fields are required";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(102, 256);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 13;
            this.submitBtn.Text = "Add Student";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(189, 256);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddEditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 291);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.studentNoTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.activeCheckbox);
            this.Controls.Add(this.classDropdown);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.middleNameTxt);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.middelNameLbl);
            this.Controls.Add(this.lastNameLbl);
            this.Controls.Add(this.firstNameLbl);
            this.Name = "AddEditStudentForm";
            this.Text = "AddEditStudentForm";
            this.Load += new System.EventHandler(this.AddEditStudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label middelNameLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameTxt;
        private System.Windows.Forms.TextBox middleNameTxt;
        private System.Windows.Forms.TextBox lastNameTxt;
        private System.Windows.Forms.ComboBox classDropdown;
        private System.Windows.Forms.CheckBox activeCheckbox;
        private System.Windows.Forms.TextBox studentNoTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}