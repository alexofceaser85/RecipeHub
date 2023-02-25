using Desktop_Client.ViewModel.Components;
using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Components.Login
{
    /// <summary>
    /// The login form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class LoginForm : UserControl
    {
        private readonly LoginFormViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public LoginForm()
        {
            this.InitializeComponent();
            this.viewModel = new LoginFormViewModel();

            this.BindComponents();
        }

        private void BindComponents()
        {
            this.usernameTextBox.DataBindings.Add(new Binding("Text", this.viewModel, nameof(this.viewModel.Username)));
            this.passwordTextInput.DataBindings.Add(new Binding("Text", this.viewModel, nameof(this.viewModel.Password)));
        }

        /// <summary>
        /// Occurs when the user successfully logs into the application.
        /// </summary>
        public event EventHandler? LoggedIn;

        /// <summary>
        /// Occurs when the user selects to register an account.
        /// </summary>
        public event EventHandler? RegistrationSelected;
        
        private void createAccountButton_Click(object sender, EventArgs e)
        {
            this.RegistrationSelected?.Invoke(this, EventArgs.Empty);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewModel.Login();
                this.LoggedIn?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}