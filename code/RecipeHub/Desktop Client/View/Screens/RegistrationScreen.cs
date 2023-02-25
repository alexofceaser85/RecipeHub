using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The registration screen for the application.
    /// </summary>
    public partial class RegistrationScreen : Screen
    {
        private readonly RegistrationScreenViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="RegistrationScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RegistrationScreen()
        {
            this.InitializeComponent();
            this.viewModel = new RegistrationScreenViewModel();
            this.CreateAccountButton.Enabled = false;
            this.BindComponents();
            this.createAccountForm.InputChangedEvent += this.CreateAccountFormOnInputChangedEvent;
        }

        private void BindComponents()
        {
            this.createAccountForm.UsernameTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Username)));
            this.createAccountForm.PasswordTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Password)));
            this.createAccountForm.VerifyPasswordTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.VerifyPassword)));
            this.createAccountForm.FirstNameTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.FirstName)));
            this.createAccountForm.LastNameTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.LastName)));
            this.createAccountForm.EmailTextBox.DataBindings.Add(new Binding("Text", this.viewModel,
                nameof(this.viewModel.Email)));
        }

        private void CreateAccountFormOnInputChangedEvent(object? sender, EventArgs e)
        {
            this.CreateAccountButton.Enabled = this.createAccountForm.DetermineIfFieldsAreValid();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewModel.CreateAccount();
                ChangeScreens(new LoginScreen());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ChangeScreens(new LoginScreen());
        }
    }
}