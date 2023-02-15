using Microsoft.Data.SqlClient;
using Server.Data.Settings;
using Shared_Resources.Model.Users;
using System.Data;

namespace Server.DAL.Users
{
    /// <summary>
    /// The users data access layer interface
    /// </summary>
    public interface IUsersDal
    {
        /// <summary>
        /// Creates an account.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="accountToCreate">The account to create.</param>
        public void CreateAccount(NewAccount accountToCreate);
        /// <summary>
        /// Verifies the user name does not exist.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>Whether or not the username exists</returns>
        public bool CheckIfUserNameExists(string userName);
        /// <summary>
        /// Verifies the session key does not exist.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>Whether or not the session key exists</returns>
        public bool VerifySessionKeyDoesNotExist(string sessionKey);
        /// <summary>
        /// Removes the session key.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        public void RemoveSessionKey(string sessionKey);
        /// <summary>
        /// Verifies the user name and password combination.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Whether or not the username and password combination exists</returns>
        public int? VerifyUserNameAndPasswordCombination(string username, string password);
        /// <summary>
        /// Adds the user session.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="sessionKey">The session key.</param>
        public void AddUserSession(int userId, string sessionKey);
        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user info for the session key</returns>
        public UserInfo? GetUserInfo(string sessionKey);

        /// <summary>
        /// Gets whether a user with a specified ID exists.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <returns>Whether a user with the specified ID exists.</returns>
        public bool UserIdExists(int userId);

        /// <summary>
        /// Gets the user ID that is currently associated with a specified session key.<br/>
        /// If none are found, null is returned.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user ID associated with the session key, if it exists. Otherwise, null.</returns>
        public int? GetIdForSessionKey(string sessionKey);
    }
}