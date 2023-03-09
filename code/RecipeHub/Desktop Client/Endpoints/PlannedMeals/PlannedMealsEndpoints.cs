using System.Text.Json;
using Shared_Resources.Data.Settings;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Utils.Json;
using Shared_Resources.Utils.Server;

namespace Desktop_Client.Endpoints.PlannedMeals
{
    public class PlannedMealsEndpoints : IPlannedMealsEndpoints
    {
        public const string AddPlannedMealsRoute = "AddPlannedMeal";
        public const string RemovePlannedMealsRoute = "RemovePlannedMeal";
        public const string GetPlannedMealsRoute = "GetPlannedMeals";

        public const string PlannedMealsElementName = "plannedMeals";

        private readonly HttpClient client;

        public PlannedMealsEndpoints() : this(new HttpClient())
        {

        }

        public PlannedMealsEndpoints(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&mealDate={mealDate}&category={category}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{AddPlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        public void RemovePlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}&mealDate={mealDate}&category={category}&recipeId={recipeId}";
            var requestUri = $"{ServerSettings.ServerUri}{RemovePlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Post, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);
        }

        public PlannedMeal[] GetPlannedMeals()
        {
            var serverMethodParameters = $"?sessionKey={Session.Key}";
            var requestUri = $"{ServerSettings.ServerUri}{GetPlannedMealsRoute}{serverMethodParameters}";
            var json = ServerUtils.RequestJson(HttpMethod.Get, requestUri, this.client);
            JsonUtils.VerifyAndGetRequestInfo(json);

            var meals = json[PlannedMealsElementName]!.AsArray().Deserialize<PlannedMeal[]>();

            return meals!;
        }
    }
}
