using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Model.Users
{
    /// <summary>
    /// Holds the user information
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; }
        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; }
        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; }
        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfo"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        public UserInfo(string userName, string firstName, string lastName, string email)
        {
            if (userName == null)
            {
                throw new ArgumentException(UserInfoErrorMessages.UsernameCannotBeNull);
            }

            if (userName.Trim().Length == 0)
            {
                throw new ArgumentException(UserInfoErrorMessages.UsernameCannotBeEmpty);
            }

            if (firstName == null)
            {
                throw new ArgumentException(UserInfoErrorMessages.FirstNameCannotBeNull);
            }

            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(UserInfoErrorMessages.FirstNameCannotBeEmpty);
            }

            if (lastName == null)
            {
                throw new ArgumentException(UserInfoErrorMessages.LastNameCannotBeNull);
            }

            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(UserInfoErrorMessages.LastNameCannotBeEmpty);
            }

            if (email == null)
            {
                throw new ArgumentException(UserInfoErrorMessages.EmailCannotBeNull);
            }

            if (email.Trim().Length == 0)
            {
                throw new ArgumentException(UserInfoErrorMessages.EmailCannotBeEmpty);
            }

            this.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}
