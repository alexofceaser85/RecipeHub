using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Users;
using Desktop_Client.View.Screens;

namespace Desktop_Client.ViewModel.Components
{
    /// <summary>
    /// The viewmodel for <see cref="LoginScreen"/>
    /// </summary>
    public class LoginFormViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private readonly IUsersService service;

        /// <summary>
        /// The text displayed in the username text field.
        /// </summary>
        public string Username
        {
            get => username;
            set => SetField(ref username, value);
        }

        /// <summary>
        /// The text displayed in the password text field.
        /// </summary>
        public string Password
        {
            get => password;
            set => SetField(ref password, value);
        }

        /// <summary>
        /// Creates a default instance of <see cref="LoginFormViewModel"/>.<br/>
        /// Uses a default <see cref="UsersService"/> for the service.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty
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
        /// </summary>
        /// <param name="service"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LoginFormViewModel(IUsersService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service));
            username = "";
            password = "";
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
            var username = Username;
            var password = Password;

            Username = string.Empty;
            Password = string.Empty;

            service.Login(username, password);
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
