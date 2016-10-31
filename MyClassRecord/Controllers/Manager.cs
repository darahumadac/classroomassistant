using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public class Manager<T> where T : ManagedEntity 
    {
        protected ManagerForm _form;
        protected Repository<T> _repository;
        protected List<T> _recordsList;

        public T SelectedRecord { get; set; }

        public Manager(ManagerForm form, Repository<T> repository)
        {
            _form = form;
            _repository = repository;
        }

        public virtual void InitializeForm()
        {
            LoadAllRecords();
        }

        public virtual void AddRecord(ManagedEntity newStudent)
        {
            _repository.Add((T)newStudent);
            LoadAllRecords();
        }

        public virtual void LoadAllRecords()
        {
            _form.searchTxt.Clear();

            _recordsList = GetAllRecordsFromDatabase();
            InitializeDataGrid(_recordsList);
        }

        //Override this to sort records
        protected virtual List<T> GetAllRecordsFromDatabase()
        {
            return _repository.GetAll().ToList();
        }

        protected virtual void InitializeDataGrid(List<T> recordsList)
        {
            _form.listGridView.DataSource = recordsList;

            _form.totalRecordsLbl.Text = string.Format("{0} records", recordsList.Count);
            if (recordsList.Count > 0)
            {
                _form.listGridView.Rows[0].Selected = true;
                _form.editBtn.Enabled = true;
            }

        }

        public void LoadRecordsBySearch(string keywordSearch, string fieldName)
        {
            _recordsList = GetRecordsFromDatabaseByKeyword(keywordSearch, fieldName);
            InitializeDataGrid(_recordsList);
        }

        //Override this to sort records
        protected virtual List<T> GetRecordsFromDatabaseByKeyword(string keywordSearch, string fieldName)
        {
            return _repository.GetBySearchKeyword(keywordSearch, fieldName);
        } 

        public void UpdateRecord(ManagedEntity selectedRecord, UpdateDefinition<T> updateStatement)
        {
            _repository.Update(selectedRecord.Id, updateStatement);

        }
    }
}
