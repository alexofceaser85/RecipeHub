using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Users;
using Desktop_Client.View.Screens;
using Shared_Resources.Model.Users;

namespace Desktop_Client.ViewModel.Users
{
    /// <summary>
    /// The viewmodel for <see cref="RegistrationScreen"/>
    /// </summary>
    public class RegistrationScreenViewModel : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private string verifyPassword;
        private string firstName;
        private string lastName;
        private string email;
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
        /// The text to be displayed in the verify password text field.
        /// </summary>
        public string VerifyPassword
        {
            get => this.verifyPassword;
            set => this.SetField(ref this.verifyPassword, value);
        }

        /// <summary>
        /// The text to be displayed in the first name text field.
        /// </summary>
        public string FirstName
        {
            get => this.firstName;
            set => this.SetField(ref this.firstName, value);
        }

        /// <summary>
        /// The text to be displayed in the last name text field.
        /// </summary>
        public string LastName
        {
            get => this.lastName;
            set => this.SetField(ref this.lastName, value);
        }

        /// <summary>
        /// The text to be displayed in the email.
        /// </summary>
        public string Email
        {
            get => this.email;
            set => this.SetField(ref this.email, value);
        }
        
        /// <summary>
        /// Creates a default instance of <see cref="RegistrationScreenViewModel"/>.<br/>
        /// Uses a default <see cref="UsersService"/> for the service.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty
        /// </summary>
        public RegistrationScreenViewModel() : this(new UsersService())
        {

        }

        /// <summary>
        /// Creates a default of <see cref="RegistrationScreenViewModel"/> with a specified <see cref="IUsersService"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>this.Username == string.Empty<br/>
        /// &amp;&amp; this.Password == string.Empty
        /// </summary>
        /// <param name="service"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public RegistrationScreenViewModel(IUsersService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service));
            this.username = "";
            this.password = "";
            this.verifyPassword = "";
            this.firstName = "";
            this.lastName = "";
            this.email = "";
        }

        /// <summary>
        /// Attempts to create an account using the provided information.<br/>
        /// <br/>
        /// <b>Precondition: </b>username != null<br/>
        /// &amp;&amp; this.Username != string.Empty<br/>
        /// &amp;&amp; this.Password != string.Empty<br/>
        /// &amp;&amp; this.VerifyPassword != string.Empty<br/>
        /// &amp;&amp; this.VerifiedPassword == this.Password<br/>
        /// &amp;&amp; this.FirstName != string.Empty<br/>
        /// &amp;&amp; this.LastName != string.Empty<br/>
        /// &amp;&amp; this.Email != string.Empty<br/>
        /// &amp;&amp; this.Email IS IN an email format<br/>
        /// <b>Postcondition: </b>None
        /// <exception cref="ArgumentException"></exception>
        /// </summary>
        public void CreateAccount()
        {
            var account = new NewAccount(this.Username, this.Password, this.VerifyPassword, this.FirstName,
                this.LastName, this.Email);
            this.service.CreateAccount(account);
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
