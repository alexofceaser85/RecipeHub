using System.Net;
using Shared_Resources.Model.Recipes;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model to return a single recipe.
    /// </summary>
    public class RecipeResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Gets or sets the recipe.
        /// </summary>
        public Recipe Recipe { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeResponseModel"/> class.<br/>
        ///<br/>
        /// Precondition: !string.IsNullOrWhiteSpace(message)<br/>
        /// Postcondition: this.Code == code &amp;&amp; this.Message == message
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        /// <param name="recipe">The recipe to send back to the client</param>
        public RecipeResponseModel(HttpStatusCode code, string message, Recipe recipe) : base(code, message)
        {
            this.Recipe = recipe;
        }
    }
}