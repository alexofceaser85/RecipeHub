using Desktop_Client.ViewModel.Users;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The create account form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class CreateAccountScreen : Form
    {
        private readonly UsersViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountScreen"/> class.
        /// </summary>
        public CreateAccountScreen()
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
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
