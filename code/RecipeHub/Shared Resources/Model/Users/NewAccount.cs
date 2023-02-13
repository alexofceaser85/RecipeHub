using System.Text.RegularExpressions;
using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Model.Users
{
    /// <summary>
    /// Holds the information for a new account
    /// </summary>
    public class NewAccount
    {
        private string password;
        private string verifyPassword;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; }

        /// <summary>
        /// Gets or sets the password.
        ///
        /// Precondition: value != null AND value IS NOT empty
        /// Postcondition: this.password == value
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { 
            get => this.password;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(NewAccountErrorMessages.PasswordCannotBeNull);
                }

                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException(NewAccountErrorMessages.PasswordCannotBeEmpty);
                }

                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the verified password.
        ///
        /// Precondition: value != null AND value IS NOT empty
        /// Postcondition: this.verifyPassword == value
        /// </summary>
        /// <value>
        /// The verified password.
        /// </value>
        public string VerifyPassword
        {
            get => this.verifyPassword;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(NewAccountErrorMessages.VerifiedPasswordCannotBeNull);
                }

                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException(NewAccountErrorMessages.VerifiedPasswordCannotBeEmpty);
                }

                this.verifyPassword = value;
            }
        }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="NewAccount"/> class.
        ///
        /// Precondition:
        /// username != null
        /// AND username IS NOT empty
        /// AND password != null
        /// AND password IS NOT empty
        /// AND verifyPassword != null
        /// AND verifyPassword IS NOT empty
        /// AND verifiedPassword == password
        /// AND firstName != null
        /// AND firstName IS NOT empty
        /// AND lastName != null
        /// AND lastName IS NOT empty
        /// AND email != null
        /// AND email IS NOT empty
        /// AND email IS IN an email format
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="verifyPassword">The verified password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public NewAccount(string username, string password, string verifyPassword, string firstName, string lastName, string email)
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

            if (verifyPassword == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.VerifiedPasswordCannotBeNull);
            }

            if (verifyPassword.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.VerifiedPasswordCannotBeEmpty);
            }

            if (!verifyPassword.Equals(password))
            {
                throw new ArgumentException(NewAccountErrorMessages.VerifiedPasswordMustMatchPassword);
            }

            if (firstName == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.FirstNameCannotBeNull);
            }

            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.FirstNameCannotBeEmpty);
            }

            if (lastName == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.LastNameCannotBeNull);
            }

            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.LastNameCannotBeEmpty);
            }

            if (email == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.EmailCannotBeNull);
            }

            if (email.Trim().Length == 0)
            {
                throw new ArgumentException(NewAccountErrorMessages.EmailCannotBeEmpty);
            }

            if (!Regex.IsMatch(email, NewAccountSettings.EmailFormat))
            {
                throw new ArgumentException(NewAccountErrorMessages.EmailIsInWrongFormat);
            }

            this.Username = username;
            this.password = password;
            this.verifyPassword = verifyPassword;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
