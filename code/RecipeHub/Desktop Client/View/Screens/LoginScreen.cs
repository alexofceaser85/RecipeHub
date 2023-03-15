using Desktop_Client.View.Dialog;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The login screen for the application.
    /// </summary>
    public partial class LoginScreen : Screen
    {
        /// <summary>
        /// Creates a default instance of <see cref="LoginScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public LoginScreen()
        {
            this.InitializeComponent();

            this.loginForm.LoggedIn += this.LoginFormOnLoggedIn;
            this.loginForm.RegistrationSelected += this.loginFormOnRegistrationSelected;
        }

        private void loginFormOnRegistrationSelected(object? sender, EventArgs e)
        {
            this.ChangeScreens(new RegistrationScreen());
        }

        private void LoginFormOnLoggedIn(object? sender, EventArgs e)
        {
            this.ChangeScreens(new RecipeListScreen());
        }
    }
}
