using Newtonsoft.Json;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Web_Client.Endpoints.Ingredients
{
    /// <summary>
    /// Endpoints for the Ingredients Functionality.
    /// </summary>
    public class IngredientEndpoints : IIngredientEndpoints
    {
        private readonly HttpClient http;

        private const string GetIngredientsEndpoint = "GetIngredientsInPantry";
        private const string AddIngredientEndpoint = "AddIngredientToPantry";
        private const string AddIngredientsEndpoint = "AddIngredientsToPantry";
        private const string DeleteIngredientEndpoint = "RemoveIngredientFromPantry";
        private const string DeleteAllIngredientsEndpoint = "RemoveAllIngredientsFromPantry";
        private const string UpdateIngredientEndpoint = "UpdateIngredientInPantry";
        private const string GetSuggestionsEndpoint = "GetSuggestions";
        private const string GetMissingIngredientsForRecipeEndpoint = "GetMissingIngredientsForRecipe";
        private const string RemoveIngredientsForRecipeEndpoint = "RemoveIngredientsForRecipe";

        private const string IngredientsElementName = "ingredients";

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientEndpoints"/> class.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: All values have been set to default values.
        /// </summary>
        public IngredientEndpoints()
        {
            this.http = new HttpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientEndpoints"/> class.<br />
        /// <br />
        /// Precondition: http != null<br />
        /// Postcondition: All values have been set to default values.
        /// </summary>
        /// <param name="http">The HTTP.</param>
        /// <exception cref="System.ArgumentNullException">http</exception>
        public IngredientEndpoints(HttpClient http)
        {
            this.http = http ?? throw new ArgumentNullException(nameof(http));
        }

        /// <inheritdoc />
        public Ingredient[] GetAllIngredientsForUser()
        {
            var parameters = $"?sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{GetIngredientsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var pantry = json["pantry"];
            var ingredients = new List<Ingredient>();

            if (pantry == null)
            {
                return ingredients.ToArray();
            }

            foreach (var ingredient in pantry.AsArray())
            {
                var name = ingredient!["name"]!.GetValue<string>();
                var amount = ingredient["amount"]!.GetValue<int>();
                var measurementType = ingredient["measurementType"]!.GetValue<int>();

                ingredients.Add(new Ingredient(name, amount, (MeasurementType)measurementType));
            }

            return ingredients.ToArray();
        }

        /// <inheritdoc />
        public bool AddIngredient(Ingredient ingredient)
        {
            var parameters =
                $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{AddIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc/>
        public void AddIngredients(Ingredient[] ingredients)
        {
            var ingredientsJson = JsonConvert.SerializeObject(ingredients);
            var parameters = $"?ingredientsJson={ingredientsJson}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{AddIngredientsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);

            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <inheritdoc />
        public bool DeleteIngredient(Ingredient ingredient)
        {
            var parameters =
                $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{DeleteIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public bool UpdateIngredient(Ingredient ingredient)
        {
            var parameters =
                $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{UpdateIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public bool DeleteAllIngredientsForUser()
        {
            var parameters = $"?sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{DeleteAllIngredientsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public string[] GetSuggestions(string ingredientName)
        {
            var parameters = $"?text={ingredientName}";
            var requestUri = $"{ServerSettings.ServerUri}{GetSuggestionsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.http);

            JsonUtils.VerifyAndGetRequestInfo(json);

            var suggestions = new List<string>();
            foreach (var suggestion in json["suggestions"]?.AsArray()!)
            {
                suggestions.Add(suggestion!.GetValue<string>());
            }

            return suggestions.ToArray();
        }

        /// <inheritdoc/>
        public Ingredient[] GetMissingIngredientsForRecipe(int recipeId)
        {
            var parameters = $"?recipeId={recipeId}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{GetMissingIngredientsForRecipeEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var missingIngredients = json[IngredientsElementName];
            var ingredients = new List<Ingredient>();

            if (missingIngredients == null)
            {
                return ingredients.ToArray();
            }

            foreach (var ingredient in missingIngredients.AsArray())
            {
                var name = ingredient!["name"]!.GetValue<string>();
                var amount = ingredient["amount"]!.GetValue<int>();
                var measurementType = ingredient["measurementType"]!.GetValue<int>();

                ingredients.Add(new Ingredient(name, amount, (MeasurementType)measurementType));
            }

            return ingredients.ToArray();
        }

        /// <inheritdoc/>
        public void RemoveIngredientsForRecipe(int recipeId)
        {
            var parameters = $"?recipeId={recipeId}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{RemoveIngredientsForRecipeEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }
    }
}