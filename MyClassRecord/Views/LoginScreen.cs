using System;
using System.Windows.Forms;
using MyClassRecord.Controllers;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class LoginScreen : Form
    {
        private readonly AppRepository _appRepository;
        private readonly LoginManager _loginManager;
        private User _authenticatedUser;

        public LoginScreen(AppRepository appRepository)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _appRepository = appRepository;
            _loginManager = new LoginManager(appRepository.UserRepository);

            //Assign Lazy Loading Repositories
            LazyLoadingRepository.ClassRepository = _appRepository.ClassRepository;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            _authenticatedUser = _loginManager.Authenticate(usernameTxt.Text, passwordTxt.Text);

            if (_authenticatedUser.IsExisting)
            {
                Program.LoggedInUser = _authenticatedUser;
                errorMsg.Visible = false;

                displayMainMenu();
            }
            else
            {
                errorMsg.Visible = true;
            }

        }

        private void displayMainMenu()
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen(_appRepository, this);
            mainMenuScreen.Show();
            Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            resetFields();
            base.OnVisibleChanged(e);
        }

        private void resetFields()
        {
            usernameTxt.Clear();
            passwordTxt.Clear();

            usernameTxt.Focus();
        }
    }
}
