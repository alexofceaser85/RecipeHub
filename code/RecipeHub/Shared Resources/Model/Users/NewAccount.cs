using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Model.Users
{
    /// <summary>
    /// Holds the information for a new account
    /// </summary>
    public class NewAccount
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; }

        /// <summary>
        /// Gets or sets the verified password.
        /// </summary>
        /// <value>
        /// The verified password.
        /// </value>
        public string VerifiedPassword { get; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; }

        
        public NewAccount(string username, string password, string verifiedPassword, string firstName, string lastName, string email)
        {
            if (username == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.UsernameCannotBeNull);
            }

            if (username.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.UsernameCannotBeEmpty);
            }

            if (password == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.PasswordCannotBeNull);
            }

            if (password.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.PasswordCannotBeEmpty);
            }

            //TODO COMPLETE THE REST
            this.Username = username;
            this.Password = password;
            this.VerifiedPassword = verifiedPassword;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
