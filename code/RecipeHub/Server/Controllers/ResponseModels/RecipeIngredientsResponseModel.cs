using Server.ErrorMessages;
using System.Net;
using Shared_Resources.Model.Ingredients;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the login
    /// </summary>
    public class RecipeIngredientsResponseModel : BaseResponseModel
    {
        /// <summary>
        /// The list of ingredients for a recipe.
        /// </summary>
        public Ingredient[] Ingredients { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeIngredientsResponseModel"/> class.<br/>
        /// <br/>
        /// Precondition: message != null and message IS NOT empty<br/>
        /// Postcondition: this.Code == code and this.Message == message
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        /// <param name="ingredients">The list of ingredients</param>
        public RecipeIngredientsResponseModel(HttpStatusCode code, string message, Ingredient[] ingredients) 
            : base(code, message)
        {
            this.Ingredients = ingredients;
        }
    }
}
