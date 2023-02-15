using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response Model for requests that contain a list of strings.
    /// </summary>
    public class SuggestionResponseModel
    {
        private string message;
        private IList<string> suggestions;

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
        /// Represents a list of suggestions to be sent back to the user.
        /// </summary>
        public IList<string>? Suggestions
        {
            get => this.suggestions;
            set => this.suggestions = value ?? throw new ArgumentNullException(nameof(value));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FlagResponseModel"/> class.<br />
        /// <br />
        /// Precondition: message != null<br />
        /// AND !string.IsNullOrWhitespace(message)<br />
        /// AND suggestions != null<br />
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Suggestions == suggestions<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="suggestions">The list of suggestions sent to the user.</param>
        /// 
        public SuggestionResponseModel(HttpStatusCode code, string message, IList<string>? suggestions)
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
            this.suggestions = suggestions ?? throw new ArgumentNullException(nameof(suggestions));
        }
    }
}
