using Desktop_Client.Endpoints.PlannedMeals;
using Desktop_Client.Service.Users;
using Shared_Resources.Model.PlannedMeals;
using System.Xml.Linq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;

namespace Desktop_Client.Service.PlannedMeals
{
    public class PlannedMealsService : IPlannedMealsService
    {
        private readonly IPlannedMealsEndpoints plannedMealsEndpoints;
        private readonly IUsersService usersService;

        public PlannedMealsService() : this(new PlannedMealsEndpoints(), new UsersService())
        {

        }

        public PlannedMealsService(IPlannedMealsEndpoints plannedMealsEndpoints, IUsersService usersService)
        {
            this.plannedMealsEndpoints =
                plannedMealsEndpoints ?? throw new ArgumentNullException(nameof(plannedMealsEndpoints));
            this.usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key));
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.plannedMealsEndpoints.AddPlannedMeal(mealDate, category, recipeId);
        }

        public void RemovePlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            if (Session.Key == null)
            {
                throw new ArgumentNullException(nameof(Session.Key));
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new ArgumentException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.plannedMealsEndpoints.RemovePlannedMeal(mealDate, category, recipeId);
        }

        public PlannedMeal[] GetPlannedMeals()
        {
            this.usersService.RefreshSessionKey();
            return this.plannedMealsEndpoints.GetPlannedMeals();
        }
    }
}
