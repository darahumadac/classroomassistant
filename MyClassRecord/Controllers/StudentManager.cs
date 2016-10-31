using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public class StudentManager
    {
        private readonly ManageStudentScreen _manageStudentScreen;
        private readonly Repository<Student> _studentRepository;
        private List<Student> _students;

        public Student SelectedRecord { get; set; }

        public StudentManager() { }
        public StudentManager(ManageStudentScreen manageStudentScreen, Repository<Student> studentRepository)
        {
            _manageStudentScreen = manageStudentScreen;
            _studentRepository = studentRepository;
        }

        public void InitializeForm()
        {
            _manageStudentScreen.findLbl.Text = "ID No./Last Name";
            LoadAllRecords();
        }

        public void AddStudent(Student newStudent)
        {
            _studentRepository.Add(newStudent);
            LoadAllRecords();
        }

        public void LoadAllRecords()
        {
            _manageStudentScreen.searchTxt.Clear();

            _students = _studentRepository.GetAll().OrderBy(s => s.LastName).ToList();
            InitializeDataGrid(_students);
        }

        private void InitializeDataGrid(List<Student> studentList)
        {
            _manageStudentScreen.listGridView.DataSource = studentList;

            _manageStudentScreen.totalRecordsLbl.Text = string.Format("{0} records", studentList.Count);
            if (studentList.Count > 0)
            {
                _manageStudentScreen.listGridView.Rows[0].Selected = true;
                _manageStudentScreen.editBtn.Enabled = true;
            }

        }

        public void LoadRecordsBySearch(string keywordSearch, string fieldName)
        {
            _students = _studentRepository.GetBySearchKeyword(keywordSearch, fieldName)
                .OrderBy(s => s.LastName).ToList();
            InitializeDataGrid(_students);
        }

        public void UpdateStudent(Student selectedStudent)
        {
            var updateStatement = Builders<Student>.Update
                .Set("FirstName", selectedStudent.FirstName)
                .Set("MiddleName", selectedStudent.MiddleName)
                .Set("LastName", selectedStudent.LastName)
                .Set("GradeAndSection", selectedStudent.GradeAndSection)
                .Set("IsActive", selectedStudent.IsActive)
                .Set("UpdatedBy", Program.LoggedInUser.Username)
                .CurrentDate("UpdatedDate");

            _studentRepository.Update(selectedStudent.Id, updateStatement);
            
        }

        //TODO: Add validation
    }
}
