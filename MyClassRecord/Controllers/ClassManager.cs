using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public class ClassManager : Manager<Class>
    {
        public ClassManager(ManagerForm manageClassForm, Repository<Class> classRepository)
            : base(manageClassForm, classRepository)
        {
        }

        public override void InitializeManageForm()
        {
            _form.findLbl.Text = "Grade/Section";
            base.InitializeManageForm();
        }

        public override List<Class> GetAllRecordsFromDatabase()
        {
            return _repository.GetAll().OrderBy(c => c.Grade).ToList();
        }

        protected override List<Class> GetRecordsFromDatabaseByKeyword(string keywordSearch, string fieldName)
        {
            return _repository.GetBySearchKeyword(keywordSearch, fieldName)
                .OrderBy(c => c.Grade).ToList();
        }

        public override bool UpdateRecord(ManagedEntity selectedClass)
        {
            Class currentClass = (Class)selectedClass;

            var updateStatement = Builders<Class>.Update
                .Set("Grade", currentClass.Grade)
                .Set("Section", currentClass.Section)
                .Set("IsActive", currentClass.IsActive)
                .Set("UpdatedBy", Program.LoggedInUser.Username)
                .CurrentDate("UpdatedDate");

            return base.UpdateRecord(selectedClass, updateStatement);
        }

    }

    public class AddEditClassManager : AddEditManager<Class>
    {
        private readonly AddEditClassForm _addEditClassForm;

        public AddEditClassManager(AddEditClassForm addEditClassForm, Manager<Class> classManager)
            : base(addEditClassForm, classManager)
        {
            _addEditClassForm = addEditClassForm;
        }

        protected override void InitializeColorOfLabels()
        {
            _addEditClassForm.sectionLbl.ForeColor = Color.Black;
            _addEditClassForm.gradeLbl.ForeColor = Color.Black;
        }

        protected override bool ValidateInputsForUpdate(ManagedEntity record)
        {
            Class classRecord = (Class)record;

            return validateSection(classRecord.Section) && classRecord.Grade > 0;
        }

        protected override bool ValidateInputsForAdd()
        {
            return validateGradeLevel() && validateSection(_addEditClassForm.sectionTxt.Text);
        }

        private bool validateSection(string section)
        {
            if (string.IsNullOrEmpty(section))
            {
                _addEditClassForm.sectionLbl.ForeColor = Color.Red;
                return false;
            }
            return true;
        }

        private bool validateGradeLevel()
        {
            if (_addEditClassForm.gradeDropdown.SelectedItem == null)
            {
                _addEditClassForm.gradeLbl.ForeColor = Color.Red;
                return false;
            }

            return true;
        }

        protected override bool IsExisting(ManagedEntity record)
        {
            Class classRecord = (Class)record;

            //Check if same record exists
            if (_manager.GetAllRecordsFromDatabase().FirstOrDefault(e =>
                e.Id != record.Id &&
                e.Grade == classRecord.Grade &&
                e.Section == classRecord.Section) != null)
            {
                return true;
            }

            return false;
        }

        protected override void SetControlValuesForEdit()
        {
            _addEditClassForm.submitBtn.Text = "Save Class";

            _addEditClassForm.gradeDropdown.SelectedItem = _manager.SelectedRecord.Grade;
            _addEditClassForm.sectionTxt.Text = _manager.SelectedRecord.Section;

            _addEditClassForm.activeCheckbox.Checked = _manager.SelectedRecord.IsActive;
            
        }

        protected override void SetEntityValuesForUpdate()
        {
            _manager.SelectedRecord.Grade = (int)_addEditClassForm.gradeDropdown.SelectedItem;
            _manager.SelectedRecord.Section = _addEditClassForm.sectionTxt.Text;
            _manager.SelectedRecord.IsActive = _addEditClassForm.activeCheckbox.Checked;

            //TODO: Deactivate students when class is deactivated
        }

        protected override Class ConstructRecordToAdd()
        {
            return new Class((int)_addEditClassForm.gradeDropdown.SelectedItem,
                _addEditClassForm.sectionTxt.Text,
            _addEditClassForm.activeCheckbox.Checked);
        }
    }
}
