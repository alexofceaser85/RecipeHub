using System.Net;
using Server.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the list of recipes.
    /// </summary>
    public class RecipeListResponseModel
    {
        private string message;

        /// <summary>
        /// The response status code.
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// The response message.
        /// </summary>
        public string Message
        {
            get => this.message;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), 
                        ResponseModelErrorMessages.MessageCannotBeNull);
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ResponseModelErrorMessages.MessageCannotBeEmpty);
                }
                this.message = value;
            }
        }

        /// <summary>
        /// The list of queried recipes.
        /// </summary>
        public Recipe[]? Recipes { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="RecipeListResponseModel"/> class with a specified status code, message, and array of recipes.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsEmptyOrWhiteSpace(message)<br/>
        /// <b>Postcondition: </b>this.Code == code<br/>
        /// &amp;&amp; this.Message == message<br/>
        /// &amp;&amp; this.Recipes == recipes
        /// </summary>
        /// <param name="code">The response status code.</param>
        /// <param name="message">The message.</param>
        /// <param name="recipes">The list of recipes.</param>
        public RecipeListResponseModel(HttpStatusCode code, string message, Recipe[] recipes)
        {
            this.message = "";
            this.Code = code;
            this.Message = message;
            this.Recipes = recipes;
        }
    }
}
