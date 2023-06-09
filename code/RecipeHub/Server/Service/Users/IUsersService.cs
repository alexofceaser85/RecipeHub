﻿using Server.DAL.Users;
using Shared_Resources.Model.Users;

namespace Server.Service.Users
{
    /// <summary>
    /// The interface for the users service
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Creates an account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="newAccount">The new account.</param>
        public void CreateAccount(NewAccount newAccount);
        /// <summary>
        /// Logins the specified username and password combination.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The login information</returns>
        public string Login(string username, string password, string? previousSessionKey);

        /// <summary>
        /// Removes the timed out session keys.
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void RemoveTimedOutSessionKeys();

        /// <summary>
        /// Gets the user identifier for session key.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="previousSessionKey">The previous session key</param>
        public string RefreshSessionKey(string previousSessionKey);

        /// <summary>
        /// Logs the specified session key out of the system.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        public void Logout(string sessionKey);

        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        public UserInfo? GetUserInfo(string sessionKey);
    }
}
