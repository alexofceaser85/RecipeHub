using Server.DAL.Users;
using Server.ErrorMessages;
using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;
using Shared_Resources.Utils.Hashing;

namespace Server.Service.Users
{
    /// <summary>
    /// Holds the service methods for the user
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUsersDal dataAccessLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        public UsersService()
        {
            this.dataAccessLayer = new UsersDal();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        ///
        /// Precondition dataAccessLayer != null
        /// Postcondition: None
        /// </summary>
        /// <param name="dataAccessLayer">The data access layer.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public UsersService(IUsersDal dataAccessLayer)
        {
            if (dataAccessLayer == null)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.DataAccessLayerCannotBeNull);
            }

            this.dataAccessLayer = dataAccessLayer;
        }

        /// <summary>
        /// Creates the account.
        ///
        /// Precondition: accountToCreate != null and accountToCreate.UserName does not exist
        /// Postcondition: None
        /// </summary>
        /// <param name="accountToCreate">The account to create.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public void CreateAccount(NewAccount accountToCreate)
        {
            if (accountToCreate == null)
            {
                throw new ArgumentException(UsersServiceServerErrorMessages.AccountToCreateCannotBeNull);
            }

            if (!this.dataAccessLayer.VerifyUserNameDoesNotExist(accountToCreate.Username))
            {
                throw new ArgumentException(UsersServiceServerErrorMessages.UserNameAlreadyExists);
            }

            this.dataAccessLayer.CreateAccount(accountToCreate);
        }

        /// <summary>
        /// Logins the specified username and password combination.
        ///
        /// Precondition:
        /// username != null
        /// AND username.IsEmpty() == false
        /// AND password != null
        /// AND password.IsEmpty() == false
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="previousSessionKey">The previous session key.</param>
        /// <returns>The new session key for the user</returns>
        /// <exception cref="System.ArgumentException">user name and password combo is wrong</exception>
        public string Login(string username, string password, string? previousSessionKey)
        {
            if (username == null)
            {
                throw new ArgumentException(UsersServiceErrorMessages.UsernameCannotBeNull);
            }
            if (username.Trim().Length == 0)
            {
                throw new ArgumentException(UsersServiceErrorMessages.UsernameCannotBeEmpty);
            }
            if (password == null)
            {
                throw new ArgumentException(UsersServiceErrorMessages.PasswordCannotBeNull);
            }
            if (password.Trim().Length == 0)
            {
                throw new ArgumentException(UsersServiceErrorMessages.PasswordCannotBeEmpty);
            }
            if (previousSessionKey != null && previousSessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.PreviousSessionKeyCannotBeEmpty);
            }

            var userId = this.dataAccessLayer.VerifyUserNameAndPasswordCombination(username, password);
            if (userId == null)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.UsernameAndPasswordCombinationIsWrong);
            }

            var sessionKey = this.generateNewSessionKey();
            if (previousSessionKey != null)
            {
                this.dataAccessLayer.RemoveSessionKey(previousSessionKey);
            }

            this.dataAccessLayer.AddUserSession(userId.Value, sessionKey);

            return sessionKey;
        }

        /// <summary>
        /// Log outs the specified user's session.
        ///
        /// Precondition: sessionKey != null
        /// AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public void Logout(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.dataAccessLayer.RemoveSessionKey(sessionKey);
        }

        /// <summary>
        /// Gets the user information.
        ///
        /// Precondition: sessionKey != null
        /// AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The user information</returns>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public UserInfo? GetUserInfo(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(ServerUsersServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            return this.dataAccessLayer.GetUserInfo(sessionKey);
        }

        private string generateNewSessionKey()
        {
            var random = new Random();

            var randomKey = new string(Enumerable.Repeat(SessionKeySettings.SessionKeyCharacters, SessionKeySettings.SessionKeyLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var hashedKey = Hashes.HashToSha512(randomKey);

            if (!this.dataAccessLayer.VerifySessionKeyDoesNotExist(hashedKey))
            {
                return this.generateNewSessionKey();
            }

            return hashedKey;
        }
    }
}
