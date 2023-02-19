using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The registration screen for the application.
    /// </summary>
    public partial class RegistrationScreen : Screen
    {
        private readonly UsersViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="RegistrationScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RegistrationScreen()
        {
            this.InitializeComponent();
            this.viewModel = new UsersViewModel();
            this.CreateAccountButton.Enabled = false;
            this.createAccountForm.InputChangedEvent += this.CreateAccountFormOnInputChangedEvent;
        }

        private void CreateAccountFormOnInputChangedEvent(object? sender, EventArgs e)
        {
            this.CreateAccountButton.Enabled = this.createAccountForm.DetermineIfFieldsAreValid();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.viewModel.CreateAccount(
                    this.createAccountForm.UsernameTextBox.Text,
                    this.createAccountForm.PasswordTextBox.Text,
                    this.createAccountForm.VerifyPasswordTextBox.Text,
                    this.createAccountForm.FirstNameTextBox.Text,
                    this.createAccountForm.LastNameTextBox.Text,
                    this.createAccountForm.EmailTextBox.Text
                );

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