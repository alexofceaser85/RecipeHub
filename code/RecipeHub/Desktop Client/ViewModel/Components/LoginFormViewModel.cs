using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Users;
using Desktop_Client.View.Screens;
using Shared_Resources.Data.Settings;

namespace Desktop_Client.ViewModel.Components
{
    /// <summary>
    /// The viewmodel for <see cref="LoginScreen"/>
    /// </summary>
    public class LoginFormViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The error message for when the username is empty
        /// </summary>
        public const string EmptyUsernameErrorMessage = "Username cannot be empty.";

        /// <summary>
        /// The error message for when the password is empty
        /// </summary>
        public const string EmptyPasswordErrorMessage = "Password cannot be empty.";

        private readonly IUsersService service;
        private string username;
        private string password;
        private string usernameErrorMessage;
        private string passwordErrorMessage;
        private Color usernameTextBoxColor;
        private Color passwordTextBoxColor;

        /// <summary>
        /// The text displayed in the username text field.
        /// </summary>
        public string Username
        {
            get => this.username;
            set
            {
                if (value == string.Empty)
                {
                    this.UsernameErrorMessage = EmptyUsernameErrorMessage;
                    this.UsernameTextBoxColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
                }
                else
                {
                    this.UsernameErrorMessage = string.Empty;
                    this.UsernameTextBoxColor = Color.White;
                }
                this.SetField(ref this.username, value);
            }
        }
        
        /// <summary>
        /// The text displayed in the password text field.
        /// </summary>
        public string Password
        {
            get => this.password;
            set
            {
                if (value == string.Empty)
                {
                    this.PasswordErrorMessage = EmptyPasswordErrorMessage;
                    this.PasswordTextBoxColor = ColorTranslator.FromHtml(UserInterfaceSettings.ErrorColor);
                }
                else
                {
                    this.PasswordErrorMessage = string.Empty;
                    this.PasswordTextBoxColor = Color.White;
                }
                this.SetField(ref this.password, value);
            }
        }

        /// <summary>
        /// The error message to display for issues with the username
        /// </summary>
        public string UsernameErrorMessage
        {
            get => this.usernameErrorMessage;
            set => this.SetField(ref this.usernameErrorMessage, value);
        }
        
        /// <summary>
        /// The error message to display for issues with the password
        /// </summary>
        public string PasswordErrorMessage
        {
            get => this.passwordErrorMessage;
            set => this.SetField(ref this.passwordErrorMessage, value);
        }

        /// <summary>
        /// The background color for the username text box
        /// </summary>
        public Color UsernameTextBoxColor
        {
            get => this.usernameTextBoxColor;
            set => this.SetField(ref this.usernameTextBoxColor, value);
        }

        /// <summary>
        /// The background color for the password text box
        /// </summary>
        public Color PasswordTextBoxColor
        {
            get => this.passwordTextBoxColor;
            set => this.SetField(ref this.passwordTextBoxColor, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="LoginFormViewModel"/>.<br/>
        /// Uses a default <see cref="UsersService"/> for the service.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty<br/>
        /// &amp;&amp; this.UsernameErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.PasswordErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.UsernameTextBoxColor == Color.White<br/>
        /// &amp;&amp; this.PasswordTextBoxColor == Color.White
        /// </summary>
        public LoginFormViewModel() : this(new UsersService())
        {

        }

        /// <summary>
        /// Creates a default of <see cref="LoginFormViewModel"/> with a specified <see cref="IUsersService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty
        /// &amp;&amp; this.UsernameErrorMessage == string.Empty<br/>
        /// &amp;&amp; this.PasswordErrorMessage == string.Empty
        /// &amp;&amp; this.UsernameTextBoxColor == Color.White<br/>
        /// &amp;&amp; this.PasswordTextBoxColor == Color.White
        /// </summary>
        /// <param name="service"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LoginFormViewModel(IUsersService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service));
            this.username = "";
            this.password = "";
            this.usernameErrorMessage = "";
            this.passwordErrorMessage = "";
            this.usernameTextBoxColor = Color.White;
            this.passwordTextBoxColor = Color.White;
        }

        /// <summary>
        /// Attempts to log into the application with the provided credentials.<br/>
        /// Clears the Username and Password.<br/>
        /// Displays an message box with an error message if the login was not successful.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void Login()
        {
            this.service.Login(this.username, this.password);
            this.service.RefreshSessionKey();
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <inheridoc/>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <inheridoc/>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
