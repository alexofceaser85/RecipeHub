using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response Model for requests that contain a list of strings.
    /// </summary>
    public class SuggestionResponseModel : BaseResponseModel
    {
        private IList<string> suggestions;
        
        /// <summary>
        /// Represents a list of suggestions to be sent back to the user.
        /// </summary>
        public IList<string>? Suggestions
        {
            get => this.suggestions;
            set => this.suggestions = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestionResponseModel"/> class.<br />
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
        public SuggestionResponseModel(HttpStatusCode code, string message, IList<string>? suggestions) : base(code, message)
        {
            this.suggestions = suggestions ?? throw new ArgumentNullException(nameof(suggestions));
        }
    }
}
