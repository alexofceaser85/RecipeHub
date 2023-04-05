using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.RecipeTypes
{
    /// <summary>
    /// The endpoints for the recipe types
    /// </summary>
    /// <seealso cref="Desktop_Client.Endpoints.RecipeTypes.IRecipeTypesEndpoints" />
    public class RecipeTypesEndpoints : IRecipeTypesEndpoints
    {
        private const string GetAllRecipeTypesServiceMethodName = "RecipeTypes";

        private const string RecipeTypesElementName = "types";

        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesEndpoints"/> class.<br/>
        /// <br/>
        /// Precondition: None<br/>
        /// Postcondition: None
        /// </summary>
        public RecipeTypesEndpoints()
        {
            this.client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesEndpoints"/> class.<br/>
        /// <br/>
        /// Precondition: client != null<br/>
        /// Postcondition: None
        /// </summary>
        /// <param name="client">The client.</param>
        public RecipeTypesEndpoints(HttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentException(RecipeTypesErrorMessages.EndpointsCannotBeNull);
            }

            this.client = client;
        }
        
        /// <inheritdoc/>
        public string[] GetAllRecipeTypes()
        {
            var requestUri = $"{ServerSettings.ServerUri}{GetAllRecipeTypesServiceMethodName}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var recipeTypes = new List<string>();

            foreach (var recipeType in json[RecipeTypesElementName]!.AsArray())
            {
                recipeTypes.Add(recipeType!.GetValue<string>());
            }

            return recipeTypes.ToArray();
        }
    }
}
