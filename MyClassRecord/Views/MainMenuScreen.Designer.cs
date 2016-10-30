namespace MyClassRecord.Views
{
    partial class MainMenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyClassRecord.Views.MainMenuScreen));
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.logoutLink = new System.Windows.Forms.LinkLabel();
            this.manageClassRecordsBtn = new System.Windows.Forms.Button();
            this.manageClassBtn = new System.Windows.Forms.Button();
            this.manageUserBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLbl.Location = new System.Drawing.Point(12, 19);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(72, 13);
            this.welcomeLbl.TabIndex = 2;
            this.welcomeLbl.Text = "Welcome, {0}";
            // 
            // logoutLink
            // 
            this.logoutLink.AutoSize = true;
            this.logoutLink.Location = new System.Drawing.Point(269, 19);
            this.logoutLink.Name = "logoutLink";
            this.logoutLink.Size = new System.Drawing.Size(45, 13);
            this.logoutLink.TabIndex = 4;
            this.logoutLink.TabStop = true;
            this.logoutLink.Text = "Log Out";
            this.logoutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLink_LinkClicked);
            // 
            // manageClassRecordsBtn
            // 
            this.manageClassRecordsBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageClassRecordsBtn.Image")));
            this.manageClassRecordsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageClassRecordsBtn.Location = new System.Drawing.Point(179, 61);
            this.manageClassRecordsBtn.Name = "manageClassRecordsBtn";
            this.manageClassRecordsBtn.Size = new System.Drawing.Size(135, 43);
            this.manageClassRecordsBtn.TabIndex = 5;
            this.manageClassRecordsBtn.Text = "Manage Class Records";
            this.manageClassRecordsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageClassRecordsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageClassRecordsBtn.UseVisualStyleBackColor = true;
            // 
            // manageClassBtn
            // 
            this.manageClassBtn.Image = ((System.Drawing.Image)(resources.GetObject("manageClassBtn.Image")));
            this.manageClassBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageClassBtn.Location = new System.Drawing.Point(15, 61);
            this.manageClassBtn.Name = "manageClassBtn";
            this.manageClassBtn.Size = new System.Drawing.Size(135, 43);
            this.manageClassBtn.TabIndex = 6;
            this.manageClassBtn.Text = "Manage Class";
            this.manageClassBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.manageClassBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageClassBtn.UseVisualStyleBackColor = true;
            this.manageClassBtn.Click += new System.EventHandler(this.manageStudentsBtn_Click);
            // 
            // manageUserBtn
            // 
            this.manageUserBtn.Location = new System.Drawing.Point(100, 124);
            this.manageUserBtn.Name = "manageUserBtn";
            this.manageUserBtn.Size = new System.Drawing.Size(124, 27);
            this.manageUserBtn.TabIndex = 7;
            this.manageUserBtn.Text = "Manage Users";
            this.manageUserBtn.UseVisualStyleBackColor = true;
            this.manageUserBtn.Visible = false;
            this.manageUserBtn.Click += new System.EventHandler(this.manageUserBtn_Click);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 163);
            this.Controls.Add(this.manageUserBtn);
            this.Controls.Add(this.manageClassBtn);
            this.Controls.Add(this.manageClassRecordsBtn);
            this.Controls.Add(this.logoutLink);
            this.Controls.Add(this.welcomeLbl);
            this.MaximizeBox = false;
            this.Name = "MainMenuScreen";
            this.Text = "Main Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_Closed);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.LinkLabel logoutLink;
        private System.Windows.Forms.Button manageClassRecordsBtn;
        private System.Windows.Forms.Button manageClassBtn;
        private System.Windows.Forms.Button manageUserBtn;
    }
}

