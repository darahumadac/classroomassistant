using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditStudentForm : AddEditForm
    {
        private readonly AddEditManager<Student> _addEditStudentManager;

        public AddEditStudentForm(StudentManager studentManager)
        {
            InitializeComponent();
            _addEditStudentManager = new AddEditStudentManager(this, studentManager);
        }

        private void AddEditStudentForm_Load(object sender, EventArgs e)
        {
            classDropdown.SelectedIndex = 0;
            _addEditStudentManager.InitializeForm();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            _addEditStudentManager.Submit();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _addEditStudentManager.Cancel();
        }
    }
}
