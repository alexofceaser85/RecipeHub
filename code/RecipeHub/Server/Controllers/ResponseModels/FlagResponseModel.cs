using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response model for requests that include a boolean flag.
    /// </summary>
    public class FlagResponseModel
    {
        private string message;

        /// <summary>
        /// The code representing the status of the request.
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// The response message to be displayed to client.
        /// </summary>
        public string Message
        {
            get => this.message;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
                }

                this.message = value;
            }
        }

        /// <summary>
        /// Represents a flag value, an extra value that
        /// indicates whether an operation was successfully performed or not.
        /// </summary>
        public bool? Flag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlagResponseModel"/> class.<br />
        /// <br />
        /// Precondition: message != null<br />
        /// AND !string.IsNullOrWhitespace(message)<br />
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Flag == flag<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="flag">The flag.</param>
        public FlagResponseModel(HttpStatusCode code, string message, bool? flag)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
            }
            this.Code = code;
            this.message = message;
            this.Flag = flag;
        }
    }
}
