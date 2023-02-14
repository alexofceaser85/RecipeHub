using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// A simple server response model object.<br/>
    /// Contains only a status code and a message.
    /// </summary>
    public class StandardResponseModel
    {
        private string message;

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode Code { get; set; }
        
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>
        /// The response message.
        /// </value>
        public string Message
        {
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
        /// Initializes a new instance of the <see cref="StandardResponseModel"/> class.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(message)<br/>
        /// <b>Postcondition: </b>this.Code == code &amp;&amp; this.Message == message
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        public StandardResponseModel(HttpStatusCode code, string message)
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
        }
    }
}
