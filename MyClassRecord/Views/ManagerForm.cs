using System;
using MyClassRecord.Controllers;

namespace MyClassRecord.Views
{
    public partial class ManagerForm
    {

        public ManagerForm() { InitializeComponent(); }
        public ManagerForm(string managedObjectName)
        {
            InitializeComponent();
            
            findLbl.Text += string.Format(" {0}", managedObjectName);
            addBtn.Text += string.Format(" {0}", managedObjectName);
        }

        protected virtual void addBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected virtual void showAllBtn_Click(object sender, EventArgs e)
        {

        }

        protected virtual void editBtn_Click(object sender, EventArgs e)
        {

        }

        protected virtual void searchBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
