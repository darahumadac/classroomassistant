using System;
using System.Windows.Forms;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class ClassMenuScreen : Form
    {
        private AppRepository _appRepository;
        private readonly MainMenuScreen _mainMenuScreen;

        public ClassMenuScreen(AppRepository appRepository, MainMenuScreen mainMenuScreen)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _appRepository = appRepository;
            _mainMenuScreen = mainMenuScreen;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void manageStudentsBtn_Click(object sender, EventArgs e)
        {
            ManagerForm manageStudentsForm = new ManageStudentScreen(_appRepository.StudentRepository);
            manageStudentsForm.Show();
        }

        private void manageClassesBtn_Click(object sender, EventArgs e)
        {
            ManagerForm manageClassesForm = new ManageClassForm(_appRepository.ClassRepository);
            manageClassesForm.Show();
        }

    

    
    }
}
