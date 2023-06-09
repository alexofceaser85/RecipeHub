﻿using System.Text;
using System.Text.Json;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.Recipes
{
    /// <inheritdoc/>
    public class RecipesEndpoints : IRecipesEndpoints
    {
        private const string RecipeRoute = "Recipe";
        private const string RecipeIngredientsRoute = "RecipeIngredients";
        private const string RecipeStepsRoute = "RecipeSteps";
        private const string RecipesRoute = "Recipes";
        private const string RecipesForTypeRoute = "RecipesForType";
        private const string TypesForRecipeRoute = "TypesForRecipe";

        private const string RecipeElementName = "recipe";
        private const string RecipesElementName = "recipes";
        private const string IngredientsElementName = "ingredients";
        private const string StepsElementName = "steps";
        private const string TypesElementName = "types";

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
        public Recipe[] GetRecipes(string searchTerm = "")
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&searchTerm={searchTerm}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var recipes = json.AsObject()[RecipesElementName].Deserialize<Recipe[]>();

            return recipes!;
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipesForTags(string[] tags)
        {
            var tagList = string.Join(",", tags);
            var serverMethodParameters = $"?sessionKey={Session.Key}&tags={tagList}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipesForTypeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var recipes = json.AsObject()[RecipesElementName].Deserialize<Recipe[]>();

            return recipes!;
        }

        /// <inheritdoc/>
        public Recipe GetRecipe(int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var recipe = json.AsObject()[RecipeElementName].Deserialize<Recipe>();

            return recipe!;
        }

        /// <inheritdoc/>
        public Ingredient[] GetIngredientsForRecipe(int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeIngredientsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var ingredients = new List<Ingredient>();

            foreach (var ingredient in json[IngredientsElementName]!.AsArray())
            {
                var name = ingredient!["name"]!.GetValue<string>();
                var amount = ingredient["amount"]!.GetValue<int>();
                var measurementType = ingredient["measurementType"]!.GetValue<int>();

                ingredients.Add(new Ingredient(name, amount, (MeasurementType) measurementType));
            }

            return ingredients.ToArray();
        }

        /// <inheritdoc/>
        public RecipeStep[] GetStepsForRecipe(int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeStepsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var steps = json.AsObject()[StepsElementName].Deserialize<RecipeStep[]>();

            return steps!;
        }

        /// <inheritdoc/>
        public string[] GetTypesForRecipe(int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{TypesForRecipeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var types = json.AsObject()[TypesElementName].Deserialize<string[]>();

            return types!;
        }

        /// <inheritdoc/>
        public void AddRecipe(string name, string description, bool isPublic)
        {
            var serverMethodParameters =
                $"?sessionKey={Session.Key}&name={name}&description={description}&isPublic={isPublic}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <inheritdoc/>
        public void RemoveRecipe(int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Delete, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <inheritdoc/>
        public void EditRecipe(int recipeId, string name, string description, bool isPublic)
        {
            var serverMethodParameters =
                $"?sessionKey={Session.Key}&recipeId={recipeId}&name={name}&description={description}&isPublic={isPublic}";
            var requestUri = $"{ServerSettings.ServerUri}{RecipeRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Put, requestUri, this.client);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }
    }
}