using System;
using MyClassRecord.Controllers;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class ManageClassForm : ManagerForm
    {
        private ClassManager _classManager;

        public ManageClassForm(Repository<Class> classRepository)
            :base("Class")
        {
            InitializeComponent();

            _classManager = new ClassManager(this, classRepository);
            _classManager.InitializeForm();
        }

        protected override void addBtn_Click(object sender, EventArgs e)
        {
            _classManager.SelectedRecord = null;

            AddEditClassForm _addClassForm = new AddEditClassForm(_classManager);
            _addClassForm.Show();
        }

        protected override void showAllBtn_Click(object sender, EventArgs e)
        {
            _classManager.LoadAllRecords();
        }

        protected override void editBtn_Click(object sender, EventArgs e)
        {
            _classManager.SelectedRecord = (Class)listGridView.CurrentRow.DataBoundItem;

            AddEditClassForm _editClassForm = new AddEditClassForm(_classManager);
            _editClassForm.Show();
        }

        protected override void searchBtn_Click(object sender, EventArgs e)
        {
            int gradeLevel;

            if (int.TryParse(searchTxt.Text.Trim(), out gradeLevel))
            {
                //TODO: Make search by Grade work; can't search by grade because it is int
                _classManager.LoadRecordsBySearch(searchTxt.Text, "Grade");
            }
            else
            {
                _classManager.LoadRecordsBySearch(searchTxt.Text, "Section");
            }
        }

    }
}
