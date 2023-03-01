using Desktop_Client.Service.Users;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace Desktop_Client.ViewModel.Users
{
    /// <summary>
    /// The view model for the users
    /// </summary>
    public class UsersViewModel
    {
        private readonly IUsersService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
        /// </summary>
        public UsersViewModel()
        {
            this.service = new UsersService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
        ///
        /// Precondition: service != null
        /// Postcondition: None
        /// </summary>
        /// <param name="service">The service.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public UsersViewModel(IUsersService service)
        {
            this.service = service ?? 
                           throw new ArgumentException(UsersServiceViewModelErrorMessages.UsersServiceCannotBeNull);
        }

        /// <summary>
        /// Creates an account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="verifyPassword">The verify password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        public void CreateAccount(string username, string password, string verifyPassword, string firstName,
            string lastName, string email)
        {
            this.service.CreateAccount(new NewAccount(username, password, verifyPassword, firstName, lastName, email));
        }

        /// <summary>
        /// Logins the specified username and password combination.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password)
        {
            this.service.Login(username, password);
        }

        /// <summary>
        /// Logs the user out.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void Logout()
        {
            this.service.Logout();
        }

        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo()
        {
            return this.service.GetUserInfo();
        }
    }
}