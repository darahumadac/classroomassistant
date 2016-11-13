using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public class StudentManager : Manager<Student>
    {
        public Repository<Class> ClassRepository { get; set; }

        public StudentManager(ManageStudentScreen manageStudentScreen, 
                            Repository<Student> studentRepository)
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
        private Repository<Class> _classRepository;

        public AddEditStudentManager(AddEditStudentForm addEditStudentForm, Manager<Student> studentManager) 
            : base(addEditStudentForm, studentManager)
        {
            _addEditStudentForm = addEditStudentForm;
            _classRepository = LazyLoadingRepository.ClassRepository;

        }

        public void PopulateSectionDropdown(int selectedGradeLevel)
        {
            _addEditStudentForm.sectionDropdown.Items.Clear();

            List<Class> classes = _classRepository.GetAll().FindAll(c => c.Grade == selectedGradeLevel);
            foreach (var gradeAndSection in classes)
            {
                _addEditStudentForm.sectionDropdown.Items.Add(gradeAndSection.Section);
            }
        }

        protected override void InitializeColorOfLabels()
        {
            _addEditStudentForm.firstNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.middelNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.lastNameLbl.ForeColor = Color.Black;
            _addEditStudentForm.gradeLbl.ForeColor = Color.Black;
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
            if (_addEditStudentForm.gradeDropdown.SelectedItem == null)
            {
                _addEditStudentForm.gradeLbl.ForeColor = Color.Red;
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
            ObjectId classId = _classRepository.GetAll()
                                .First(c => c.Grade == _addEditStudentForm.gradeDropdown.SelectedIndex + 1 &&
                                c.Section == (string)_addEditStudentForm.sectionDropdown.SelectedItem).Id;

            return new Student(_addEditStudentForm.studentNoTxt.Text,
                    _addEditStudentForm.firstNameTxt.Text,
                    _addEditStudentForm.middleNameTxt.Text,
                    _addEditStudentForm.lastNameTxt.Text,
                    classId,
                    _addEditStudentForm.activeCheckbox.Checked); 
        }
    }
}
