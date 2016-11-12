﻿using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class AddEditClassForm : AddEditForm//Form
    {
        private ClassManager _classManager;
        private Class _selectedClass;
        private AddEditManager<Class> _addEditClassManager;

        public AddEditClassForm(ClassManager classManager)
        {
            InitializeComponent();
            
            _classManager = classManager;
            _addEditClassManager = new AddEditClassManager(this, classManager);

            //Add grade levels to dropdown
            for (int i = 1; i <= 12; i++)
            {
                gradeDropdown.Items.Add(i);
            }
        }

        private void AddEditClassForm_Load(object sender, EventArgs e)
        {
            _addEditClassManager.InitializeForm();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            _addEditClassManager.Submit();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _addEditClassManager.Cancel();
        }

        
    }
}
