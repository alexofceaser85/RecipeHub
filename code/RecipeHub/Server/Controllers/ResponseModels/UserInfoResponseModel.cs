using System.Net;
using Shared_Resources.Model.Users;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the user info
    /// </summary>
    public class UserInfoResponseModel
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public UserInfo? UserInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoResponseModel"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="userInfo">The user information.</param>
        public UserInfoResponseModel(HttpStatusCode code, string message, UserInfo? userInfo)
        {
            //TODO Add preconditions
            this.Code = code;
            this.Message = message;
            this.UserInfo = userInfo;
        }
    }
}
