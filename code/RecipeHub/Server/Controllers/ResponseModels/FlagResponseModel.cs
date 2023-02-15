using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response model for requests that include a boolean flag.
    /// </summary>
    public class FlagResponseModel : BaseResponseModel
    {
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
        public FlagResponseModel(HttpStatusCode code, string message, bool? flag) : base(code, message)
        {
            this.Flag = flag;
        }
    }
}
