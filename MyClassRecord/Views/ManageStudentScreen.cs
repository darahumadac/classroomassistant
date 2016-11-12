using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class ManageStudentScreen : ManagerForm
    {
        private readonly StudentManager _studentManager;

        public ManageStudentScreen(Repository<Student> studentRepository)
            : base("Student")
        {
            InitializeComponent();

            _studentManager = new StudentManager(this, studentRepository);
            
            _studentManager.InitializeManageForm();
        }

        protected override void addBtn_Click(object sender, EventArgs e)
        {
            _studentManager.SelectedRecord = null;

            AddEditStudentForm _addStudentForm  = new AddEditStudentForm(_studentManager);
            _addStudentForm.Show();
        }

        protected override void showAllBtn_Click(object sender, EventArgs e)
        {
            _studentManager.LoadAllRecords();
        }

        protected override void editBtn_Click(object sender, EventArgs e)
        {
            _studentManager.SelectedRecord = (Student)listGridView.CurrentRow.DataBoundItem;

            AddEditStudentForm _editStudentForm = new AddEditStudentForm(_studentManager);
            _editStudentForm.Show();
        }

        protected override void searchBtn_Click(object sender, EventArgs e)
        {
            int idNumber;

            if (int.TryParse(searchTxt.Text.Trim(), out idNumber))
            {
                _studentManager.LoadRecordsBySearch(searchTxt.Text, "StudentNumber");
            }
            else
            {
                _studentManager.LoadRecordsBySearch(searchTxt.Text, "LastName");
            }
            
        }
    }
}
