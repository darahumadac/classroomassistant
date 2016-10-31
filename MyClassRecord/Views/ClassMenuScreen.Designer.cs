namespace MyClassRecord.Views
{
    partial class ClassMenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassMenuScreen));
            this.manageStudentsBtn = new System.Windows.Forms.Button();
            this.manageClassesBtn = new System.Windows.Forms.Button();
            this.manageRequirementsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageStudentsBtn
            // 
            this.manageStudentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageStudentsBtn.Image")));
            this.manageStudentsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageStudentsBtn.Location = new System.Drawing.Point(15, 61);
            this.manageStudentsBtn.Name = "manageStudentsBtn";
            this.manageStudentsBtn.Size = new System.Drawing.Size(135, 43);
            this.manageStudentsBtn.TabIndex = 6;
            this.manageStudentsBtn.Text = "Manage Students";
            this.manageStudentsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageStudentsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageStudentsBtn.UseVisualStyleBackColor = true;
            this.manageStudentsBtn.Click += new System.EventHandler(this.manageStudentsBtn_Click);
            // 
            // manageClassesBtn
            // 
            this.manageClassesBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageClassesBtn.Image")));
            this.manageClassesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageClassesBtn.Location = new System.Drawing.Point(179, 61);
            this.manageClassesBtn.Name = "manageClassesBtn";
            this.manageClassesBtn.Size = new System.Drawing.Size(135, 43);
            this.manageClassesBtn.TabIndex = 7;
            this.manageClassesBtn.Text = "Manage Classes";
            this.manageClassesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageClassesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageClassesBtn.UseVisualStyleBackColor = true;
            this.manageClassesBtn.Click += new System.EventHandler(this.manageClassesBtn_Click);
            // 
            // manageRequirementsBtn
            // 
            this.manageRequirementsBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageRequirementsBtn.Image")));
            this.manageRequirementsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageRequirementsBtn.Location = new System.Drawing.Point(15, 110);
            this.manageRequirementsBtn.Name = "manageRequirementsBtn";
            this.manageRequirementsBtn.Size = new System.Drawing.Size(135, 43);
            this.manageRequirementsBtn.TabIndex = 8;
            this.manageRequirementsBtn.Text = "Manage Requirements";
            this.manageRequirementsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageRequirementsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageRequirementsBtn.UseVisualStyleBackColor = true;
            // 
            // ClassMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 163);
            this.Controls.Add(this.manageRequirementsBtn);
            this.Controls.Add(this.manageClassesBtn);
            this.Controls.Add(this.manageStudentsBtn);
            this.MaximizeBox = false;
            this.Name = "ClassMenuScreen";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button manageStudentsBtn;
        private System.Windows.Forms.Button manageClassesBtn;
        private System.Windows.Forms.Button manageRequirementsBtn;
    }
}

