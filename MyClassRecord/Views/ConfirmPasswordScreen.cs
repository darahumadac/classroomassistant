using System;
using System.Drawing;
using System.Windows.Forms;
using MyClassRecord.Models;

namespace MyClassRecord.Views
{
    public partial class ConfirmPasswordScreen : Form
    {
        private readonly User _selectedUser;
        private readonly ManageUserScreen _userListView;

        public ConfirmPasswordScreen(User selectedUser, ManageUserScreen userListView)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _selectedUser = selectedUser;
            _userListView = userListView;

            updateMsg.Text = string.Empty;
            updateMsg.Visible = true;
            
        }

        private void ConfirmPasswordScreen_Load(object sender, EventArgs e)
        {
            currentPwText.Focus();
        }

        private void updatePwBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPwText.Text.Equals(_selectedUser.Password)
                    && !string.IsNullOrEmpty(newPasswordTxt.Text)
                    && !string.IsNullOrEmpty(confirmNewPwTxt.Text)
                    && newPasswordTxt.Text.Equals(confirmNewPwTxt.Text))
                {
                    _selectedUser.Password = newPasswordTxt.Text;
                    _userListView.Save();

                    updateMsg.Text = "Password changed";
                    updateMsg.ForeColor = Color.Green;

                    updatePwBtn.Enabled = false;
                }
                else
                {
                    updateMsg.Text = "Passwords do not match";
                    updateMsg.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                _userListView.Revert();
                updateMsg.Text = "Password: At least 6 characters";
                updateMsg.ForeColor = Color.Red;
            }
           
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        
    }
}
