using System.Net;

namespace Server.Controllers.ResponseModels
{
    /// <summary>
    /// The response model for the recipe types
    /// </summary>
    /// <seealso cref="Server.Controllers.ResponseModels.BaseResponseModel" />
    public class RecipeTypesResponseModel : BaseResponseModel
    {
        /// <summary>
        /// Gets or sets the recipe types.
        /// </summary>
        /// <value>
        /// The recipe types.
        /// </value>
        public string[] Types { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesResponseModel"/> class.
        ///
        /// Precondition: None
        /// Postcondition: Code == code<br />
        /// AND Message == message<br />
        /// AND Types == types<br />
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <param name="types">The types.</param>
        public RecipeTypesResponseModel(HttpStatusCode code, string message, string[] types) : base (code, message)
        {
            this.Types = types;
        }
    }
}
