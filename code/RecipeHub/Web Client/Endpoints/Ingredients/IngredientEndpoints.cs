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

        private readonly string getIngredientsEndpoint = "GetIngredientsInPantry";
        private readonly string addIngredientEndpoint = "AddIngredientToPantry";
        private readonly string deleteIngredientEndpoint = "RemoveIngredientFromPantry";
        private readonly string deleteAllIngredientsEndpoint = "RemoveAllIngredientsFromPantry";
        private readonly string updateIngredientEndpoint = "UpdateIngredientInPantry";
        private readonly string getSuggestionsEndpoint = "GetSuggestions";


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
            string parameters = $"?sessionKey={Session.Key}";
            string requestUri = $"{ServerSettings.ServerUri}{this.getIngredientsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var pantry = json["pantry"];
            var ingredients = new List<Ingredient>();
            
            if (pantry != null)
            {
                foreach (var ingredient in pantry.AsArray())
                {
                    var name = ingredient!["name"]!.GetValue<string>();
                    var amount = ingredient!["amount"]!.GetValue<int>();
                    var measurementType = ingredient["measurementType"]!.GetValue<int>();

                    ingredients.Add(new Ingredient(name, amount, (MeasurementType)measurementType));
                }
            }
            
            return ingredients.ToArray();
        }

        /// <inheritdoc />
        public bool AddIngredient(Ingredient ingredient)
        {
            string parameters = $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            string requestUri = $"{ServerSettings.ServerUri}{this.addIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public bool DeleteIngredient(Ingredient ingredient)
        {
            var parameters = $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{this.deleteIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public bool UpdateIngredient(Ingredient ingredient)
        {
            var parameters = $"?name={ingredient.Name}&measurementType={(int)ingredient.MeasurementType}&amount={ingredient.Amount}&sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{this.updateIngredientEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public bool DeleteAllIngredientsForUser()
        {
            string parameters = $"?sessionKey={Session.Key}";
            string requestUri = $"{ServerSettings.ServerUri}{this.deleteAllIngredientsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            return json["flag"]!.GetValue<bool>();
        }

        /// <inheritdoc />
        public string[] GetSuggestions(string ingredientName)
        {
            string parameters = $"?text={ingredientName}";
            string requestUri = $"{ServerSettings.ServerUri}{this.getSuggestionsEndpoint}{parameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.http);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var suggestions = new List<string>();
            foreach (var suggestion in json["suggestions"]?.AsArray()!)
            {
                suggestions.Add(suggestion!.GetValue<string>());
            }

            return suggestions.ToArray();
        }
    }
}
