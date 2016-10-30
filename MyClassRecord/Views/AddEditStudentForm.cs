using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                _studentManager.UpdateStudent(_selectedStudent);
                _studentManager.SelectedRecord = null;
            }
            else
            {
                Student newStudent = new Student(studentNoTxt.Text, 
                    firstNameTxt.Text, 
                    middleNameTxt.Text, 
                    lastNameTxt.Text, 
                    new Class(1, "Test Section")); //TODO: Add code for getting the class
                
                _studentManager.AddStudent(newStudent);
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
