using Server.ErrorMessages;
using System.Net;
using Shared_Resources.Model.Ingredients;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response Model for requests that include the pantry of ingredients.
    /// </summary>
    public class PantryResponseModel
    {
        private string message;
        private IList<Ingredient> pantry;

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
        /// Represents a pantry of ingredients, with names and amounts of each ingredient.
        /// </summary>
        public IList<Ingredient>? Pantry
        {
            get => this.pantry;
            set => this.pantry = value ?? throw new ArgumentNullException(nameof(value));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FlagResponseModel"/> class.<br />
        /// <br />
        /// Precondition: message != null<br />
        /// AND !string.IsNullOrWhitespace(message)<br />
        /// AND pantry != null<br />
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Pantry == pantry<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="pantry">The pantry being sent to the client.</param>
        /// 
        public PantryResponseModel(HttpStatusCode code, string message, IList<Ingredient> pantry)
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
            this.pantry = pantry ?? throw new ArgumentNullException(nameof(pantry));
        }
    }
}
}
