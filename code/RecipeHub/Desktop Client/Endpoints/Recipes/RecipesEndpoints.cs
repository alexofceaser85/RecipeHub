using System.Text.Json;
using System.Xml.Linq;
using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.Recipes
{
    /// <inheritdoc/>
    public class RecipesEndpoints : IRecipesEndpoints
    {
        private const string RecipesRoute = "Recipes";
        private const string RecipesElementName = "recipes";
        
        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesEndpoints"/> class.
        /// </summary>
        public RecipesEndpoints()
        {
            this.client = new HttpClient();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesEndpoints"/> class.
        ///
        /// Precondition: client != null
        /// Postcondition: this.client == client
        /// </summary>
        /// <param name="client">The client.</param>
        public RecipesEndpoints(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client),
                RecipesEndpointsErrorMessages.ClientCannotBeNull);
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipes(string sessionKey, string searchTerm = "")
        {
            var serverMethodParameters =$"?sessionKey={sessionKey}&searchTerm={searchTerm}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var recipes = json.AsObject()[RecipesElementName].Deserialize<Recipe[]>();

            return recipes!;
        }

        /// <inheritdoc/>
        public void AddRecipe(string sessionKey, string name, string description, bool isPublic)
        {
            var serverMethodParameters = $"?sessionKey={sessionKey}&name={name}&description={description}&isPublic={isPublic}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <inheritdoc/>
        public void RemoveRecipe(string sessionKey, int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={sessionKey}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Delete, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <inheritdoc/>
        public void EditRecipe(string sessionKey, int recipeId, string name, string description, bool isPublic)
        {
            var serverMethodParameters = $"?sessionKey={sessionKey}&recipeId={recipeId}&name={name}&description={description}&isPublic={isPublic}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Put, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }
    }
}
