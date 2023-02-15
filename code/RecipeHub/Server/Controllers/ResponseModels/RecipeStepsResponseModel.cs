using Server.ErrorMessages;
using System.Net;
using System.Text.Json.Serialization;
using Shared_Resources.Model.Recipes;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the login
    /// </summary>
    public class RecipeStepsResponseModel : BaseResponseModel
    {
        [JsonPropertyName("steps")]
        public RecipeStep[] Steps { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResponseModel"/> class.
        ///
        /// Precondition: message != null and message IS NOT empty
        /// Postcondition: this.Code == code and this.Message == message
        /// </summary>
        /// <param name="code">The status code.</param>
        /// <param name="message">The response content.</param>
        /// <param name="steps">The steps for the recipe.</param>
        public RecipeStepsResponseModel(HttpStatusCode code, string message, RecipeStep[] steps) : base(code, message)
        {
            this.Steps = steps;
        }
    }
}
