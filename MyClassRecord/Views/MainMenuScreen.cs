using System;
using System.Windows.Forms;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class MainMenuScreen : Form
    {
        private AppRepository _appRepository;
        private readonly LoginScreen _loginScreen;


        public MainMenuScreen(AppRepository appRepository, LoginScreen loginScreen)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _appRepository = appRepository;
            _loginScreen = loginScreen;

            if (Program.LoggedInUser.IsAdmin)
            {
                manageUserBtn.Visible = true;
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            welcomeLbl.Text = String.Format("Welcome, {0}", Program.LoggedInUser.Username);
        }

        private void MainMenu_Closed(object sender, FormClosedEventArgs e)
        {
            logOut();
        }

        private void logOut()
        {
            Program.LoggedInUser = new User();

            _loginScreen.Show();
        }

        private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            logOut();
            Dispose();
        }

        private void manageStudentsBtn_Click(object sender, EventArgs e)
        {
            ClassMenuScreen manageClassMenuScreen = new ClassMenuScreen(_appRepository, this);
            manageClassMenuScreen.Show();
        }

        private void manageUserBtn_Click(object sender, EventArgs e)
        {
            ManageUserScreen manageUserListScreen = new ManageUserScreen(_appRepository.UserRepository);
            manageUserListScreen.Show();
        }

    
    }
}
