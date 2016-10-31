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
        //private readonly ManageStudentScreen _manageStudentScreen;
        //private readonly Repository<Student> _studentRepository;
        //private List<Student> _students;

        //public Student SelectedRecord { get; set; }

        public StudentManager(ManageStudentScreen manageStudentScreen, Repository<Student> studentRepository)
            : base(manageStudentScreen, studentRepository)
        {
            //_manageStudentScreen = manageStudentScreen;
            //_studentRepository = studentRepository;
        }

        public override void InitializeForm()
        {
            _form.findLbl.Text = "ID No./Last Name";
            //_manageStudentScreen.findLbl.Text = "ID No./Last Name";
            base.InitializeForm();//LoadAllRecords();
        }

        //public void AddRecord(ManagedEntity newStudent)
        //{
        //    _studentRepository.Add((Student)newStudent);
        //    LoadAllRecords();
        //}

        //public void LoadAllRecords()
        //{
        //    _manageStudentScreen.searchTxt.Clear();

        //    _students = _studentRepository.GetAll().OrderBy(s => s.LastName).ToList();
        //    InitializeDataGrid(_students);
        //}

        protected override List<Student> GetAllRecordsFromDatabase()
        {
            //return _studentRepository.GetAll().OrderBy(s => s.LastName).ToList();
            return _repository.GetAll().OrderBy(s => s.LastName).ToList();
        }

        protected override List<Student> GetRecordsFromDatabaseByKeyword(string keywordSearch, string fieldName)
        {
            //return _studentRepository.GetBySearchKeyword(keywordSearch, fieldName)
            //    .OrderBy(s => s.LastName).ToList();
            return _repository.GetBySearchKeyword(keywordSearch, fieldName)
                .OrderBy(s => s.LastName).ToList();
        }

        //private void InitializeDataGrid(List<Student> studentList)
        //{
        //    _manageStudentScreen.listGridView.DataSource = studentList;

        //    _manageStudentScreen.totalRecordsLbl.Text = string.Format("{0} records", studentList.Count);
        //    if (studentList.Count > 0)
        //    {
        //        _manageStudentScreen.listGridView.Rows[0].Selected = true;
        //        _manageStudentScreen.editBtn.Enabled = true;
        //    }

        //}

        //public void LoadRecordsBySearch(string keywordSearch, string fieldName)
        //{
        //    _students = _studentRepository.GetBySearchKeyword(keywordSearch, fieldName)
        //        .OrderBy(s => s.LastName).ToList();
        //    InitializeDataGrid(_students);
        //}

        public void UpdateRecord(ManagedEntity selectedStudent)
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

            //_studentRepository.Update(selectedStudent.Id, updateStatement);
            base.UpdateRecord(selectedStudent, updateStatement);
            
        }

        //TODO: Add validation
    }
}
