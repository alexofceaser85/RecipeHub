using System.Net;
using Server.ErrorMessages;
using Shared_Resources.Model.Users;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the user info
    /// </summary>
    public class UserInfoResponseModel
    {
        private string message;

        /// <summary>
        /// Gets or sets the response Code.
        /// </summary>
        /// <value>
        /// The Code.
        /// </value>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { 
            get => this.message;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeNull);
                }

                if (value.Trim().Length == 0)
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
                }

                this.message = value;
            }
        }
        /// <summary>
        /// Gets or sets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public UserInfo? UserInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoResponseModel"/> class.
        /// Precondition: message != null and message IS NOT empty
        /// Postcondition: this.Code == code and this.Message == message and this.UserInfo == userInfo
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        /// <param name="userInfo">The user information.</param>
        public UserInfoResponseModel(HttpStatusCode code, string message, UserInfo? userInfo)
        {
            if (message == null)
            {
                throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeNull);
            }

            if (message.Trim().Length == 0)
            {
                throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
            }

            this.Code = code;
            this.message = message;
            this.UserInfo = userInfo;
        }
    }
}
