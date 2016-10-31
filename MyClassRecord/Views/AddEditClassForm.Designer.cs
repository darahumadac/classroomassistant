namespace MyClassRecord.Views
{
    partial class AddEditClassForm
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
            this.gradeLbl = new System.Windows.Forms.Label();
            this.sectionTxt = new System.Windows.Forms.TextBox();
            this.sectionLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.gradeDropdown = new System.Windows.Forms.ComboBox();
            this.activeCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // gradeLbl
            // 
            this.gradeLbl.AutoSize = true;
            this.gradeLbl.Location = new System.Drawing.Point(34, 33);
            this.gradeLbl.Name = "gradeLbl";
            this.gradeLbl.Size = new System.Drawing.Size(65, 13);
            this.gradeLbl.TabIndex = 14;
            this.gradeLbl.Text = "Grade Level";
            // 
            // sectionTxt
            // 
            this.sectionTxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sectionTxt.Location = new System.Drawing.Point(105, 57);
            this.sectionTxt.Name = "sectionTxt";
            this.sectionTxt.Size = new System.Drawing.Size(140, 20);
            this.sectionTxt.TabIndex = 13;
            // 
            // sectionLbl
            // 
            this.sectionLbl.AutoSize = true;
            this.sectionLbl.Location = new System.Drawing.Point(56, 60);
            this.sectionLbl.Name = "sectionLbl";
            this.sectionLbl.Size = new System.Drawing.Size(43, 13);
            this.sectionLbl.TabIndex = 12;
            this.sectionLbl.Text = "Section";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(195, 116);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 23);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(105, 116);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 16;
            this.submitBtn.Text = "Add Class";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // gradeDropdown
            // 
            this.gradeDropdown.FormattingEnabled = true;
            this.gradeDropdown.Location = new System.Drawing.Point(105, 30);
            this.gradeDropdown.Name = "gradeDropdown";
            this.gradeDropdown.Size = new System.Drawing.Size(73, 21);
            this.gradeDropdown.TabIndex = 18;
            // 
            // activeCheckbox
            // 
            this.activeCheckbox.AutoSize = true;
            this.activeCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeCheckbox.Location = new System.Drawing.Point(56, 90);
            this.activeCheckbox.Name = "activeCheckbox";
            this.activeCheckbox.Size = new System.Drawing.Size(62, 17);
            this.activeCheckbox.TabIndex = 19;
            this.activeCheckbox.Text = "Active?";
            this.activeCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddEditClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.activeCheckbox);
            this.Controls.Add(this.gradeDropdown);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.gradeLbl);
            this.Controls.Add(this.sectionTxt);
            this.Controls.Add(this.sectionLbl);
            this.Name = "AddEditClassForm";
            this.Text = "AddEditClassForm";
            this.Load += new System.EventHandler(this.AddEditClassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gradeLbl;
        private System.Windows.Forms.TextBox sectionTxt;
        private System.Windows.Forms.Label sectionLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.ComboBox gradeDropdown;
        private System.Windows.Forms.CheckBox activeCheckbox;
    }
}