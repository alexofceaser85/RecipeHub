using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the login
    /// </summary>
    public class LoginResponseModel
    {
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The statuc code.
        /// </value>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>
        /// The response message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponseModel"/> class.
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        public LoginResponseModel(HttpStatusCode code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
    }
}
