using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop_Client.Screens;
using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.Components.Login
{
    public partial class LoginForm : UserControl
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var username = this.usernameTextBox.Text;
            var password = this.passwordTextInput.Text;

            UsersViewModel.Login(username, hashPassword(password));
            UserInfoScreen infoScreen = new UserInfoScreen();
            infoScreen.ShowDialog();
        }

        static string hashPassword(string passwordToHash)
        {
            using HashAlgorithm algorithm = SHA512.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
            var builder = new StringBuilder();
            foreach (var passwordByte in bytes)
            {
                builder.Append(passwordByte.ToString("x2"));
            }

            var hashedPassword = builder.ToString();
            return hashedPassword;
        }
    }
}
