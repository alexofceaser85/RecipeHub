namespace Desktop_Client.View.Components.Login
{
    /// <summary>
    /// The create account form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class CreateAccountForm : UserControl
    {
        /// <summary>
        /// Gets the username text box.
        /// </summary>
        /// <value>
        /// The username text box.
        /// </value>
        public TextBox UsernameTextBox => this.usernameTextBox;
        /// <summary>
        /// Gets the password text box.
        /// </summary>
        /// <value>
        /// The password text box.
        /// </value>
        public TextBox PasswordTextBox => this.passwordTextBox;
        /// <summary>
        /// Gets the verify password text box.
        /// </summary>
        /// <value>
        /// The verify password text box.
        /// </value>
        public TextBox VerifyPasswordTextBox => this.verifyPasswordTextBox;
        /// <summary>
        /// Gets the first name text box.
        /// </summary>
        /// <value>
        /// The first name text box.
        /// </value>
        public TextBox FirstNameTextBox => this.firstNameTextBox;
        /// <summary>
        /// Gets the last name text box.
        /// </summary>
        /// <value>
        /// The last name text box.
        /// </value>
        public TextBox LastNameTextBox => this.lastNameTextBox;
        /// <summary>
        /// Gets the email text box.
        /// </summary>
        /// <value>
        /// The email text box.
        /// </value>
        public TextBox EmailTextBox => this.emailTextBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountForm"/> class.
        /// </summary>
        public CreateAccountForm()
        {
            this.InitializeComponent();
        }
    }
}
