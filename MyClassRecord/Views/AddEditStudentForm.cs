using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditStudentForm : AddEditForm//Form
    {
        private StudentManager _studentManager;
        private Student _selectedStudent;
        private AddEditManager<Student> _addEditStudentManager;

        public AddEditStudentForm(StudentManager studentManager)
        {
            InitializeComponent();

            _studentManager = studentManager;
            _addEditStudentManager = new AddEditStudentManager(this, studentManager);
        }

        private void AddEditStudentForm_Load(object sender, EventArgs e)
        {
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
