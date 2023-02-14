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
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.viewModel = new UsersViewModel();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                var username = this.usernameTextBox.Text;
                var password = this.passwordTextInput.Text;

                this.usernameTextBox.Text = string.Empty;
                this.passwordTextInput.Text = string.Empty;

                this.viewModel.Login(username, password);
                var infoScreen = new IngredientsScreen();
                infoScreen.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            var createAccountScreen = new CreateAccountScreen();
            createAccountScreen.ShowDialog();
        }
    }
}
