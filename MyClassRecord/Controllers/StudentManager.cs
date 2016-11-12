using System.Collections.Generic;
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

        protected override List<Student> GetAllRecordsFromDatabase()
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

        //TODO: Add validation
        public override bool IsValid(ManagedEntity newRecord)
        {
            return true;
        }
    }

    public class AddEditStudentManager : AddEditManager<Student>
    {
        private AddEditStudentForm _addEditStudentForm;

        public AddEditStudentManager(AddEditStudentForm addEditStudentForm, Manager<Student> studentManager) 
            : base(addEditStudentForm, studentManager)
        {
            _addEditStudentForm = addEditStudentForm;
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
