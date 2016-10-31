using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditStudentForm : Form
    {
        private StudentManager _studentManager;
        private Student _selectedStudent;

        public AddEditStudentForm(StudentManager studentManager)
        {
            InitializeComponent();
            _studentManager = studentManager;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (_selectedStudent != null)
            {
                _selectedStudent.FirstName = firstNameTxt.Text;
                _selectedStudent.MiddleName = middleNameTxt.Text;
                _selectedStudent.LastName = lastNameTxt.Text;
                //TODO: Add code for getting class from dropdown
                _selectedStudent.IsActive = activeCheckbox.Checked;

                //_studentManager.UpdateStudent(_selectedStudent);
                _studentManager.UpdateRecord(_selectedStudent);
                //TODO: Add checking if record was updated successsffully
                _studentManager.SelectedRecord = null;

                MessageBox.Show("Student record was updated");

                _studentManager.LoadAllRecords();
            }
            else
            {
                Student newStudent = new Student(studentNoTxt.Text, 
                    firstNameTxt.Text, 
                    middleNameTxt.Text, 
                    lastNameTxt.Text, 
                    new Class(1, "Test Section", true),
                    true); //TODO: Add code for getting the class
                
                //_studentManager.AddStudent(newStudent);
                _studentManager.AddRecord(newStudent);

                MessageBox.Show("Student record was added");
            }

            Dispose();
            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _studentManager.SelectedRecord = null;
            Dispose();
            
        }

        private void AddEditStudentForm_Load(object sender, EventArgs e)
        {
            if (_studentManager.SelectedRecord != null)
            {
                _selectedStudent = _studentManager.SelectedRecord;

                submitBtn.Text = "Save Student";
                studentNoTxt.Enabled = false;

                studentNoTxt.Text = _selectedStudent.StudentNumber;
                firstNameTxt.Text = _selectedStudent.FirstName;
                middleNameTxt.Text = _selectedStudent.MiddleName;
                lastNameTxt.Text = _selectedStudent.LastName;
                //TODO: Add code for selecting class
                activeCheckbox.Checked = _selectedStudent.IsActive;
            }
        }



    }
}
