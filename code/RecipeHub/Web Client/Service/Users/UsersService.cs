using Shared_Resources.Data.IO;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;
using Shared_Resources.Utils.Hashing;
using Shared_Resources.Utils.Validation;
using System.Security.Cryptography;
using Web_Client.Endpoints.Users;

namespace Web_Client.Service.Users
{
    /// <summary>
    /// The service methods for the users
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IUsersEndpoints endpoints;

        /// <summary>
        /// The session key load file path
        /// </summary>
        public string SessionKeyLoadFile = SessionKeySettings.SaveSessionFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        public UsersService()
        {
            this.endpoints = new UsersEndpoints();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        ///
        /// Precondition: usersEndpoints != null
        /// Postcondition: None
        /// </summary>
        /// <param name="usersEndpoints">The users endpoints.</param>
        public UsersService(IUsersEndpoints usersEndpoints)
        {
            if (usersEndpoints == null)
            {
                throw new ArgumentException(UsersServiceErrorMessages.UsersEndpointsCannotBeNull);
            }

            this.endpoints = usersEndpoints;
        }

        /// <summary>
        /// Creates a new account.
        /// 
        /// Precondition: newAccount != null
        /// Postcondition: newAccount.Password == hashed password AND newAccount.VerifyPassword == hashed password
        /// </summary>
        /// <param name="newAccount">The new account.</param>
        public void CreateAccount(NewAccount newAccount)
        {
            if (newAccount == null)
            {
                throw new ArgumentException(UsersServiceErrorMessages.AccountToCreateCannotBeNull);
            }

            PasswordValidation.Validate(newAccount.Password);
            newAccount.Password = Hashes.HashToSha512(newAccount.Password);
            newAccount.VerifyPassword = Hashes.HashToSha512(newAccount.VerifyPassword);
            this.endpoints.CreateAccount(newAccount);
        }

        /// <summary>
        /// Logins the specified username and password combination.
        ///
        /// Precondition: username != null
        /// AND username IS NOT empty
        /// AND password != null
        /// AND password IS NOT empty
        /// AND SessionKeyLoadFile != null
        /// AND SessionKeyLoadFile IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public void Login(string username, string password)
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

            if (this.SessionKeyLoadFile == null)
            {
                throw new ArgumentException(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeNull);
            }

            if (this.SessionKeyLoadFile.Trim().Length == 0)
            {
                throw new ArgumentException(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeEmpty);
            }

            var hashedPassword = Hashes.HashToSha512(password);
            var previousSessionKey = SessionKeySerializers.LoadSessionKey(this.SessionKeyLoadFile);
            var sessionKey = this.endpoints.Login(username, hashedPassword, previousSessionKey);
            Session.Key = sessionKey;
            SessionKeySerializers.SaveSessionKey(sessionKey, this.SessionKeyLoadFile);
        }

        /// <summary>
        /// Logs the user out.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public void Logout()
        {
            if (Session.Key == null)
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (Session.Key.Trim().Length == 0)
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }
            this.endpoints.Logout(Session.Key);
            Session.Key = null;
        }

        /// <summary>
        /// Refreshes the session key.
        ///
        /// Precondition: None
        /// Postcondition: Session key equals the refreshed key
        /// </summary>
        public void RefreshSessionKey()
        {
            var previousSessionKey = Session.Key;

            if (previousSessionKey != null)
            {
                var newSessionKey = this.endpoints.RefreshSessionKey(previousSessionKey);
                Session.Key = newSessionKey;
            }

            if (Session.Key != null)
            {
                SessionKeySerializers.SaveSessionKey(Session.Key, this.SessionKeyLoadFile);
            }
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
            if (Session.Key == null)
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (Session.Key.Trim().Length == 0)
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }
            return this.endpoints.GetUserInfo(Session.Key);
        }
    }
}
