using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditClassForm : Form
    {
        private ClassManager _classManager;
        private Class _selectedClass;
        public AddEditClassForm(ClassManager classManager)
        {
            InitializeComponent();
            _classManager = classManager;

            for (int i = 1; i <= 12; i++)
            {
                gradeDropdown.Items.Add(i);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (_selectedClass != null)
            {
                _selectedClass.Grade = (int)gradeDropdown.SelectedItem;
                _selectedClass.Section = sectionTxt.Text;
                _selectedClass.IsActive = activeCheckbox.Checked;

                _classManager.UpdateRecord(_selectedClass);
                //TODO: Add checking if record was updated successsffully
                _classManager.SelectedRecord = null;

                MessageBox.Show("Class record was updated");

                _classManager.LoadAllRecords();
            }
            else
            {
                Class newClass = new Class((int)gradeDropdown.SelectedItem, sectionTxt.Text, activeCheckbox.Checked); 
                _classManager.AddRecord(newClass);

                MessageBox.Show("Class record was added");
            }

            Dispose();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _classManager.SelectedRecord = null;
            Dispose();
        }

        private void AddEditClassForm_Load(object sender, EventArgs e)
        {
            if (_classManager.SelectedRecord != null)
            {
                _selectedClass = _classManager.SelectedRecord;

                submitBtn.Text = "Save Class";

                gradeDropdown.SelectedItem = _selectedClass.Grade;
                sectionTxt.Text = _selectedClass.Section;

                activeCheckbox.Checked = _selectedClass.IsActive;
            }
        }
    }
}
