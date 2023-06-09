﻿using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Web_Client.Endpoints.RecipeTypes
{
    /// <summary>
    /// The recipe types endpoints
    /// </summary>
    /// <seealso cref="Web_Client.Endpoints.RecipeTypes.IRecipeTypesEndpoints" />
    public class RecipeTypesEndpoints : IRecipeTypesEndpoints
    {
        private const string GetAllRecipeTypesServiceMethodName = "RecipeTypes";

        private const string RecipeTypesElementName = "types";

        private readonly HttpClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesEndpoints"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public RecipeTypesEndpoints()
        {
            this.client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeTypesEndpoints"/> class.
        ///
        /// Precondition: client != null
        /// Postcondition: None
        /// </summary>
        /// <param name="client">The client.</param>
        public RecipeTypesEndpoints(HttpClient client)
        {
            if (client == null)
            {
                throw new ArgumentException(RecipeTypesEndpointsErrorMessages.HttpClientCannotBeNull);
            }

            this.client = client;
        }

        /// <summary>
        /// Gets the similar recipe types.
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <returns>
        /// The recipe types
        /// </returns>
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
