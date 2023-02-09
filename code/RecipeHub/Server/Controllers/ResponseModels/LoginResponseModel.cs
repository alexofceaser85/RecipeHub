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
        /// Gets or sets the response content.
        /// </summary>
        /// <value>
        /// The response content.
        /// </value>
        public string Content { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginResponseModel"/> class.
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="content">The response content.</param>
        public LoginResponseModel(HttpStatusCode code, string content)
        {
            this.Code = code;
            this.Content = content;
        }
    }
}
