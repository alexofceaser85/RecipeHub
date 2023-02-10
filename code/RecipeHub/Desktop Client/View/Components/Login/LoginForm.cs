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

            UsersViewModel.Login(username, password);
            UserInfoScreen infoScreen = new UserInfoScreen();
            infoScreen.ShowDialog();
        }
    }
}
