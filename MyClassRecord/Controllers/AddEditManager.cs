using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClassRecord.Models;
using MyClassRecord.Views;

namespace MyClassRecord.Controllers
{
    public abstract class AddEditManager<T> where T : ManagedEntity
    {
        protected  AddEditForm _addEditForm;
        protected Manager<T> _manager;
        
        protected AddEditManager(AddEditForm addEditForm, Manager<T> manager)
        {
            _addEditForm = addEditForm;
            _manager = manager;
        }

        public void InitializeForm()
        {
            if (_manager.SelectedRecord != null)
            {
                SetControlValuesForEdit();
            }
        }

        protected abstract void SetControlValuesForEdit();
        protected abstract void SetEntityValuesForUpdate();

        public void Submit()
        {
            if (_manager.SelectedRecord != null)
            {
                SetEntityValuesForUpdate();
                
                if (_manager.IsValid(_manager.SelectedRecord))
                {
                    if (_manager.UpdateRecord(_manager.SelectedRecord))
                    {
                        _manager.SelectedRecord = null;

                        MessageBox.Show("Record was updated");

                        _manager.LoadAllRecords();
                    }
                    else
                    {
                        MessageBox.Show("Cannot update record. Try again");
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("Please correct fields in red");
                }

            }
            else
            {
                T recordToAdd = ConstructRecordToAdd();
                
                if (_manager.IsValid(recordToAdd) )
                {
                    if (_manager.AddRecord(recordToAdd))
                    {
                        MessageBox.Show("Record was added");
                    }
                    else
                    {
                        MessageBox.Show("Cannot add record. Try again");
                    }
                }
                else
                {
                    MessageBox.Show("Please correct fields in red");
                }

            }

            _addEditForm.Dispose();
        }

        protected abstract T ConstructRecordToAdd();
        public void Cancel()
        {
            _manager.SelectedRecord = null;
            _addEditForm.Dispose();
        }
    }
}
