using System.Collections.Generic;
using System.Linq;
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

        protected override List<Class> GetAllRecordsFromDatabase()
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

        //TODO: Add validation
        public override bool IsValid(ManagedEntity newRecord)
        {
            return true;
        }
    }

    public class AddEditClassManager : AddEditManager<Class>
    {
        private AddEditClassForm _addEditClassForm;
        public AddEditClassManager(AddEditClassForm addEditClassForm, Manager<Class> classManager)
            : base(addEditClassForm, classManager)
        {
            _addEditClassForm = addEditClassForm;
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
        }

        protected override Class ConstructRecordToAdd()
        {
            return new Class((int) _addEditClassForm.gradeDropdown.SelectedItem,
                _addEditClassForm.sectionTxt.Text,
            _addEditClassForm.activeCheckbox.Checked);
        }
    }
}
