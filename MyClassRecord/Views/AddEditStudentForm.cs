using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditStudentForm : AddEditForm
    {
        private readonly AddEditStudentManager _addEditStudentManager;

        public AddEditStudentForm(StudentManager studentManager)
        {
            InitializeComponent();
            _addEditStudentManager = new AddEditStudentManager(this, studentManager);

            //Add grade levels to dropdown
            for (int i = 1; i <= 12; i++)
            {
                gradeDropdown.Items.Add(i);
            }
        }

        private void GradeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _addEditStudentManager.PopulateSectionDropdown(gradeDropdown.SelectedIndex + 1);
        }

        private void AddEditStudentForm_Load(object sender, EventArgs e)
        {
            gradeDropdown.SelectedIndex = 0;
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
