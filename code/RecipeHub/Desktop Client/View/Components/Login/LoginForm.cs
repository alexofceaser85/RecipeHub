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
        private readonly UsersViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.viewModel = new UsersViewModel();
        }

        /// <summary>
        /// Occurs when the user successfully logs into the application.
        /// </summary>
        public event EventHandler? LoggedIn;

        /// <summary>
        /// Occurs when the user selects to register an account.
        /// </summary>
        public event EventHandler? RegistrationSelected;

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var username = this.usernameTextBox.Text;
                var password = this.passwordTextInput.Text;

                this.usernameTextBox.Text = string.Empty;
                this.passwordTextInput.Text = string.Empty;

                this.viewModel.Login(username, password);
                this.LoggedIn?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            this.RegistrationSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
