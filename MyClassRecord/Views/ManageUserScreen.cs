using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using MyClassRecord.Models;
using MyClassRecord.Models.Repositories;

namespace MyClassRecord.Views
{
    public partial class ManageUserScreen : Form
    {
        private readonly Repository<User> _userRepository;

        public ManageUserScreen(Repository<User> userRepository)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
            _userRepository = userRepository;
        }

        private void ManageUserScreen_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }

        public void LoadAllRecords()
        {
            //_userRepository.Revert();

            userListGridView.DataSource = _userRepository.GetAll()
                .OrderBy(u => u.UserId).ToList();
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            User newUser = new User("User " + _userRepository.GetAll().Count, 
                ConfigurationManager.AppSettings["defaultPw"], false) 
            {IsActive = true};

            _userRepository.Add(newUser);
            _userRepository.Save();

            LoadAllRecords();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            _userRepository.Save();
        }

        public void Revert()
        {
            //_userRepository.Revert();
        }

        private void changePwBtn_Click(object sender, EventArgs e)
        {
            User selectedUser = (User)userListGridView.SelectedRows[0].DataBoundItem;

            ConfirmPasswordScreen confirmPassword = new ConfirmPasswordScreen(selectedUser, this);
            confirmPassword.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string username = usernameSearch.Text;
            if (string.IsNullOrEmpty(username))
            {
                LoadAllRecords();
            }
            else
            {
                userListGridView.DataSource =
                _userRepository.GetAll()
                .FindAll(u => u.Username.Equals(username))
                .ToList();
            }
            
        }

        private void enableUserManagementButtons(bool enabled)
        {
            changePwBtn.Enabled = enabled;
        }

        private void userListGridView_dataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bool hasUsers = userListGridView.RowCount > 0;

            enableUserManagementButtons(hasUsers);
        }

    }
}
