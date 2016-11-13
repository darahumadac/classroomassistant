using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MongoDB.Driver;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public class StudentManager : Manager<Student>
    {
        public StudentManager(ManageStudentScreen manageStudentScreen, Repository<Student> studentRepository)
            : base(manageStudentScreen, studentRepository)
        {
        }

        public override void InitializeManageForm()
        {
            _form.findLbl.Text = "ID No./Last Name";
            base.InitializeManageForm();
        }

        public override List<Student> GetAllRecordsFromDatabase()
        {
            return _repository.GetAll().OrderBy(s => s.LastName).ToList();
        }

        protected override List<Student> GetRecordsFromDatabaseByKeyword(string keywordSearch, string fieldName)
        {
            return _repository.GetBySearchKeyword(keywordSearch, fieldName)
                .OrderBy(s => s.LastName).ToList();
        }

        public override bool UpdateRecord(ManagedEntity selectedStudent)
        {
            Student currentStudent = (Student)selectedStudent;

            var updateStatement = Builders<Student>.Update
                .Set("FirstName", currentStudent.FirstName)
                .Set("MiddleName", currentStudent.MiddleName)
                .Set("LastName", currentStudent.LastName)
                .Set("GradeAndSection", currentStudent.GradeAndSection)
                .Set("IsActive", currentStudent.IsActive)
                .Set("UpdatedBy", Program.LoggedInUser.Username)
                .CurrentDate("UpdatedDate");

            return base.UpdateRecord(selectedStudent, updateStatement);
            
        }

    }

    public class AddEditStudentManager : AddEditManager<Student>
    {
        private readonly AddEditStudentForm _addEditStudentForm;

        public AddEditStudentManager(AddEditStudentForm addEditStudentForm, Manager<Student> studentManager) 
            : base(addEditStudentForm, studentManager)
        {
            _addEditStudentForm = addEditStudentForm;
        }

        protected override void InitializeColorOfLabels()
        {
            _addEditStudentForm.firstNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.middelNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.lastNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.classLbl.ForeColor = Color.Black;
            _addEditStudentForm.studentNoLbl.ForeColor = Color.Black;
        }

        protected override bool ValidateInputsForAdd()
        {
            return
                validateStudentNumber(_addEditStudentForm.studentNoTxt.Text) &&
                validateName(_addEditStudentForm.firstNameTxt.Text,
                            _addEditStudentForm.middleNameTxt.Text,
                            _addEditStudentForm.lastNameTxt.Text) &&
                validateClass();
        }

        protected override bool ValidateInputsForUpdate(ManagedEntity newRecord)
        {
            Student studentRecord = (Student)newRecord;
            return validateName(studentRecord.FirstName, studentRecord.MiddleName, studentRecord.LastName) &&
                   validateStudentNumber(studentRecord.StudentNumber);

        }

        private bool validateClass()
        {
            if (_addEditStudentForm.classDropdown.SelectedItem == null)
            {
                _addEditStudentForm.classLbl.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private bool validateName(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                _addEditStudentForm.firstNameLbl.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(middleName))
            {
                _addEditStudentForm.middelNameLbl.ForeColor = Color.Red;
                return false;
            }
            if (string.IsNullOrEmpty(lastName))
            {
                _addEditStudentForm.lastNameLbl.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        private bool validateStudentNumber(string studentNumber)
        {
            if (string.IsNullOrEmpty(studentNumber))
            {
                _addEditStudentForm.studentNoLbl.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        protected override bool IsExisting(ManagedEntity record)
        {
            Student studentRecord = (Student)record;

            if (_manager.GetAllRecordsFromDatabase().FirstOrDefault(e =>
                e.Id != studentRecord.Id &&
                e.StudentNumber == studentRecord.StudentNumber) != null)
            {
                return true;
            }

            return false;
        }

        protected override void SetControlValuesForEdit()
        {
            _addEditStudentForm.submitBtn.Text = "Save Student";
            _addEditStudentForm.studentNoTxt.Enabled = false;

            _addEditStudentForm.studentNoTxt.Text = _manager.SelectedRecord.StudentNumber;
            _addEditStudentForm.firstNameTxt.Text = _manager.SelectedRecord.FirstName;
            _addEditStudentForm.middleNameTxt.Text = _manager.SelectedRecord.MiddleName;
            _addEditStudentForm.lastNameTxt.Text = _manager.SelectedRecord.LastName;
            //TODO: Add code for selecting class here
            _addEditStudentForm.activeCheckbox.Checked = _manager.SelectedRecord.IsActive;
            
        }

        protected override void SetEntityValuesForUpdate()
        {
            _manager.SelectedRecord.FirstName = _addEditStudentForm.firstNameTxt.Text;
            _manager.SelectedRecord.MiddleName = _addEditStudentForm.middleNameTxt.Text;
            _manager.SelectedRecord.LastName = _addEditStudentForm.lastNameTxt.Text;
            //TODO: Add code for getting class from dropdown
            _manager.SelectedRecord.IsActive = _addEditStudentForm.activeCheckbox.Checked;
        }

        protected override Student ConstructRecordToAdd()
        {
            return new Student(_addEditStudentForm.studentNoTxt.Text,
                    _addEditStudentForm.firstNameTxt.Text,
                    _addEditStudentForm.middleNameTxt.Text,
                    _addEditStudentForm.lastNameTxt.Text,
                    new Class(1, "Test Section", true), //TODO: Add code for getting the class
                    _addEditStudentForm.activeCheckbox.Checked); 
        }
    }
}
