using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Model.Users
{
    /// <summary>
    /// The binding model for the new account info
    /// </summary>
    public class NewAccountInfoBindingModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [BindProperty]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [BindProperty]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the verified password.
        /// </summary>
        /// <value>
        /// The verified password.
        /// </value>
        [BindProperty]
        public string? VerifyPassword { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [BindProperty]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [BindProperty]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [BindProperty]
        public string? Email { get; set; }
    }
}
