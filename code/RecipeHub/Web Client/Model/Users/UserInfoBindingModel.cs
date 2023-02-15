using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Model.Users
{
    /// <summary>
    /// The binding model for the user information
    /// </summary>
    public class UserInfoBindingModel
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

    }
}
