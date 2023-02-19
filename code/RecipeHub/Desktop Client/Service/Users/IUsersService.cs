using Shared_Resources.Model.Users;

namespace Desktop_Client.Service.Users
{
    /// <summary>
    /// The interface for the users service
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Creates a new account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="newAccount">The new account.</param>
        public void CreateAccount(NewAccount newAccount);
        /// <summary>
        /// Logins the specified username.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password);
        /// <summary>
        /// Refreshes the session key.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void RefreshSessionKey();
        /// <summary>
        /// Logs the current user out.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void Logout();
        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo();
    }
}
