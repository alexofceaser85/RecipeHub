using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;
using System.Text.RegularExpressions;

namespace Desktop_Client.View.Components.Login
{
    /// <summary>
    /// The create account form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class CreateAccountForm : UserControl
    {
        private bool isUsernameInputValid;
        private bool isPasswordInputValid;
        private bool isVerifyPasswordInputValid;
        private bool isFirstNameInputValid;
        private bool isLastNameInputValid;
        private bool isEmailInputValid;

        /// <summary>
        /// Occurs when [input changed event].
        /// </summary>
        public event EventHandler<EventArgs>? InputChangedEvent;

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

        /// <summary>
        /// Determines if all the fields are valid.
        /// </summary>
        /// <returns>Whether or not the fields are valid</returns>
        public bool DetermineIfFieldsAreValid()
        {
            return this.isUsernameInputValid
                   && this.isPasswordInputValid
                   && this.isVerifyPasswordInputValid
                   && this.isFirstNameInputValid
                   && this.isLastNameInputValid
                   && this.isEmailInputValid;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.usernameTextBox.Text == string.Empty)
            {
                this.isUsernameInputValid = false;
                this.showInputError(this.usernameTextBox, this.usernameErrorLabel, NewAccountErrorMessages.UsernameCannotBeEmpty);
            }
            else
            {
                this.isUsernameInputValid = true;
                this.showValidInput(this.usernameTextBox, this.usernameErrorLabel);
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.passwordTextBox.Text == string.Empty)
            {
                this.isPasswordInputValid = false;
                this.showInputError(this.passwordTextBox, this.passwordErrorLabel, NewAccountErrorMessages.PasswordCannotBeEmpty);
            } 
            else if (this.passwordTextBox.Text.Length < PasswordSettings.MinimumPasswordLength)
            {
                this.isPasswordInputValid = false;
                this.showInputError(this.passwordTextBox, this.passwordErrorLabel, PasswordValidationErrorMessages.PasswordIsTooShort);
            }
            else
            {
                this.isPasswordInputValid = true;
                this.showValidInput(this.passwordTextBox, this.passwordErrorLabel);
            }

            this.verifyPasswordInputsMatch();
        }

        private void verifyPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.verifyPasswordTextBox.Text == string.Empty)
            {
                this.isVerifyPasswordInputValid = false;
                this.showInputError(this.verifyPasswordTextBox, this.verifyPasswordLabel, NewAccountErrorMessages.VerifiedPasswordCannotBeEmpty);
            }
            this.verifyPasswordInputsMatch();
        }

        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.firstNameTextBox.Text == string.Empty)
            {
                this.isFirstNameInputValid = false;
                this.showInputError(this.firstNameTextBox, this.firstNameErrorLabel, NewAccountErrorMessages.FirstNameCannotBeEmpty);
            }
            else
            {
                this.isFirstNameInputValid = true;
                this.showValidInput(this.firstNameTextBox, this.firstNameErrorLabel);
            }
        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.lastNameTextBox.Text == string.Empty)
            {
                this.isLastNameInputValid = false;
                this.showInputError(this.lastNameTextBox, this.lastNameErrorLabel, NewAccountErrorMessages.LastNameCannotBeEmpty);
            }
            else
            {
                this.isLastNameInputValid = true;
                this.showValidInput(this.lastNameTextBox, this.lastNameErrorLabel);
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.emailTextBox.Text == string.Empty)
            {
                this.isEmailInputValid = false;
                this.showInputError(this.emailTextBox, this.emailErrorLabel, NewAccountErrorMessages.EmailCannotBeEmpty);
            } 
            else if (!Regex.IsMatch(this.emailTextBox.Text, NewAccountSettings.EmailFormat))
            {
                this.isEmailInputValid = false;
                this.showInputError(this.emailTextBox, this.emailErrorLabel, NewAccountErrorMessages.EmailIsInWrongFormat);
            }
            else
            {
                this.isEmailInputValid = true;
                this.showValidInput(this.emailTextBox, this.emailErrorLabel);
            }
        }

        private void verifyPasswordInputsMatch()
        {
            if (!this.verifyPasswordTextBox.Text.Equals(this.passwordTextBox.Text))
            {
                this.isVerifyPasswordInputValid = false;
                this.showInputError(this.verifyPasswordTextBox, this.verifyPasswordLabel, NewAccountErrorMessages.VerifiedPasswordMustMatchPassword);
            }
            else
            {
                this.isVerifyPasswordInputValid = true;
                this.showValidInput(this.verifyPasswordTextBox, this.verifyPasswordLabel);
            }
        }

        private void showInputError(Control inputTextBox, Control errorLabel, string errorMessage)
        {
            inputTextBox.BackColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
            errorLabel.Font = new Font(UserInterfaceSettings.FontType, UserInterfaceSettings.ErrorLabelFontSize);
            errorLabel.Text = errorMessage;
            this.InputChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void showValidInput(Control inputTextBox, Control errorLabel)
        {
            inputTextBox.BackColor = Color.White;
            errorLabel.Font = new Font(UserInterfaceSettings.FontType, 1);
            errorLabel.Text = "";
            this.InputChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
