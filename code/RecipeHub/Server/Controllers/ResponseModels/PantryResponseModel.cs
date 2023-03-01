using System.Net;
using Shared_Resources.Model.Ingredients;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// Response Model for requests that include the pantry of ingredients.
    /// </summary>
    public class PantryResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Represents a pantry of ingredients, with names and amounts of each ingredient.
        /// </summary>
        public Ingredient[]? Pantry { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PantryResponseModel"/> class.<br />
        /// <br />
        /// Precondition: message != null<br />
        /// AND !string.IsNullOrWhitespace(message)<br />
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Pantry == pantry<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="pantry">The pantry being sent to the client.</param>
        public PantryResponseModel(HttpStatusCode code, string message, Ingredient[]? pantry) : base(code, message)
        {
            this.Pantry = pantry;
        }
    }
}