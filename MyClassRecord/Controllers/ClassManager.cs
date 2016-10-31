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

        public override void InitializeForm()
        {
            _form.findLbl.Text = "Grade/Section";
            base.InitializeForm();
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

        public void UpdateRecord(ManagedEntity selectedClass)
        {
            Class currentClass = (Class)selectedClass;

            var updateStatement = Builders<Class>.Update
                .Set("Grade", currentClass.Grade)
                .Set("Section", currentClass.Section)
                .Set("IsActive", currentClass.IsActive)
                .Set("UpdatedBy", Program.LoggedInUser.Username)
                .CurrentDate("UpdatedDate");

            base.UpdateRecord(selectedClass, updateStatement);

        }
    }
}
