using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;
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

        protected abstract void SetControlValuesForEdit();
        protected abstract void SetEntityValuesForUpdate();
        protected abstract void InitializeColorOfLabels();
        protected abstract bool ValidateInputsForAdd();
        protected abstract bool ValidateInputsForUpdate(ManagedEntity record);
        protected abstract bool IsExisting(ManagedEntity record);
        protected abstract T ConstructRecordToAdd();

        public void InitializeForm()
        {
            if (_manager.SelectedRecord != null)
            {
                SetControlValuesForEdit();
            }
        }

        public void Submit()
        {
            InitializeColorOfLabels();

            if (_manager.SelectedRecord != null)
            {
                SetEntityValuesForUpdate();

                if (ValidateInputsForUpdate(_manager.SelectedRecord))
                {
                    if (!IsExisting(_manager.SelectedRecord))
                    {
                        if (_manager.UpdateRecord(_manager.SelectedRecord))
                        {
                            _manager.SelectedRecord = null;

                            MessageBox.Show("Record was updated");

                            _manager.LoadAllRecords();

                            _addEditForm.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Cannot update record. Try again");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot add record. Record already exists");
                    }

                }
                else
                {
                    MessageBox.Show("Please correct fields in red");
                }

            }
            else
            {
                if (ValidateInputsForAdd())
                {
                    T recordToAdd = ConstructRecordToAdd();

                    if (!IsExisting(recordToAdd))
                    {
                        if (_manager.AddRecord(recordToAdd))
                        {
                            MessageBox.Show("Record was added");
                            _addEditForm.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Cannot add record. Try again");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot add record. Record already exists");
                    }
                }
                else
                {
                    MessageBox.Show("Please correct fields in red");
                }

            }
        }

        public void Cancel()
        {
            _manager.SelectedRecord = null;
            _manager.LoadAllRecords();
            _addEditForm.Dispose();
        }
    }
}
