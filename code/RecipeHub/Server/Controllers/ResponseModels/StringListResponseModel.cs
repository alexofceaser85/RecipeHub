using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response Model for requests that contain a list of strings.
    /// </summary>
    public class StringListResponseModel
    {
        private string message;
        private IList<string> messages;

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
        /// Represents a list of strings to be sent back to the user.
        /// </summary>
        public IList<string>? Messages
        {
            get => this.messages;
            set => this.messages = value ?? throw new ArgumentNullException(nameof(value));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FlagResponseModel"/> class.<br />
        /// <br />
        /// Precondition: message != null<br />
        /// AND !string.IsNullOrWhitespace(message)<br />
        /// AND messages != null<br />
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Messages == messages<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="messages">The list of string sent to the user.</param>
        /// 
        public StringListResponseModel(HttpStatusCode code, string message, IList<string> messages)
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
            this.messages = messages ?? throw new ArgumentNullException(nameof(messages));
        }
    }
}
