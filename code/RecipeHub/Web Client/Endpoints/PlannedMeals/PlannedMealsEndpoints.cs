using System.Text.Json;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Web_Client.Endpoints.PlannedMeals
{
    /// <inheritdoc cref="IPlannedMealsEndpoints"/>
    public class PlannedMealsEndpoints : IPlannedMealsEndpoints
    {
        private const string AddPlannedMealsRoute = "AddPlannedMeal";
        private const string RemovePlannedMealsRoute = "RemovePlannedMeal";
        private const string GetPlannedMealsRoute = "GetPlannedMeals";

        private const string PlannedMealsElementName = "plannedMeals";

        private readonly HttpClient client;

        /// <summary>
        /// Creates a default instance of <see cref="PlannedMealsEndpoints"/>, using a default <see cref="HttpClient"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public PlannedMealsEndpoints() : this(new HttpClient())
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealsEndpoints"/> with a specified <see cref="HttpClient"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>client != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlannedMealsEndpoints(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Adds a recipe to the active user's planned meals, using a specified <see cref="DateTime"/> and <see cref="MealCategory"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="mealDate">The date to add the meal</param>
        /// <param name="category">The category of the meal</param>
        /// <param name="recipeId">The recipe to add to the meal</param>
        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&mealDate={mealDate}&category={category}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{AddPlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <summary>
        /// Removes a recipe to the active user's planned meals.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="mealId">The date to remove the meal</param>
        public void RemovePlannedMeal(int mealId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&mealId={mealId}";
            var requestUri = $"{ServerSettings.ServerUri}{RemovePlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        /// <summary>
        /// Gets all of the planned meals for the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>All of the user's planned meals.</returns>
        public PlannedMeal[] GetPlannedMeals()
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&currentDate={DateTime.Now}";
            var requestUri = $"{ServerSettings.ServerUri}{GetPlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var meals = json[PlannedMealsElementName]!.AsArray().Deserialize<PlannedMeal[]>();

            return meals!;
        }
    }
}
