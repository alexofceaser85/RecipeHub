using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Components;

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

            //Forces the max size to be correct, despite what the local version of Windows Forms says it is.
            this.usernameTextBox.MaximumSize = new Size(this.usernameTextBox.MaximumSize.Width, 0);
            this.passwordTextInput.MaximumSize = new Size(this.passwordTextInput.MaximumSize.Width, 0);

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
                var curParent = this.Parent!;
                while (curParent is not Screens.Screen)
                {
                    curParent = curParent.Parent;
                };
                var screen = (Screens.Screen)curParent;

                var messageDialog = new MessageDialog("Error with logging in", ex.Message, MessageBoxButtons.OK);
                screen.DisplayDialog(messageDialog);
            }
        }
    }
}