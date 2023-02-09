using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_Client.ViewModel.Users;
using Desktop_Client.Data.UserData;

namespace Desktop_Client.Screens
{
    public partial class UserInfoScreen : Form
    {
        public UserInfoScreen()
        {
            InitializeComponent();
            this.getAndPopulateUserInfo();
        }

        private void getAndPopulateUserInfo()
        {
            var userInfo = UsersViewModel.GetUserInfo();

            this.usernameTextBox.Text = userInfo.UserName;
            this.firstNameTextBox.Text = userInfo.FirstName;
            this.lastNameTextBox.Text = userInfo.LastName;
            this.emailTextBox.Text = userInfo.Email;
            this.sessionKeyInfoLabel.Text = $"Session Key {Session.Key}";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            UsersViewModel.Logout();
            this.Close();
        }
    }
}
