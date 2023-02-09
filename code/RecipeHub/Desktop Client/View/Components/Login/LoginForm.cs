using System.Security.Cryptography;
using System.Text;
using Desktop_Client.View.Screens;
using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Components.Login
{
    /// <summary>
    /// The login form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class LoginForm : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
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
