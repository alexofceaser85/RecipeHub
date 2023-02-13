using Server.ErrorMessages;
using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for creating an account
    /// </summary>
    public class CreateAccountResponseModel
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
        /// Initializes a new instance of the <see cref="CreateAccountResponseModel"/> class.
        ///
        /// Precondition: message != null AND message IS NOT empty
        /// Postcondition: this.Code == code AND this.Message == message
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        public CreateAccountResponseModel(HttpStatusCode code, string message)
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
