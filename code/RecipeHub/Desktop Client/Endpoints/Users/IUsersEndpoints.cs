using Shared_Resources.Model.Users;

namespace Desktop_Client.Endpoints.Users
{
    /// <summary>
    /// The interface for the users endpoints
    /// </summary>
    public interface IUsersEndpoints
    {
        /// <summary>
        /// Creates an account.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="accountToCreate">The account to create.</param>
        /// <returns>The create account information</returns>
        public string CreateAccount(NewAccount accountToCreate);

        /// <summary>
        /// Logins the specified username and password combination.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The login information</returns>
        public string Login(string username, string password, string previousSessionKey);

        /// <summary>
        /// Refreshes the session key.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The refreshed session key</returns>
        public string RefreshSessionKey(string previousSessionKey);

        /// <summary>
        /// Logs the user with the specified session key out of the system.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The logout information</returns>
        public string Logout(string sessionKey);

        /// <summary>
        /// Gets the user information.<br/>
        /// <br/>
        /// Precondition: None <br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public UserInfo GetUserInfo(string sessionKey);
    }
}
