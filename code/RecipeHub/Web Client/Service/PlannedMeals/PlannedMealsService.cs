using Web_Client.Endpoints.PlannedMeals;
using Web_Client.Service.Users;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;

namespace Web_Client.Service.PlannedMeals
{
    /// <inheritdoc cref="IPlannedMealsService"/>
    public class PlannedMealsService : IPlannedMealsService
    {
        private readonly IPlannedMealsEndpoints plannedMealsEndpoints;
        private readonly IUsersService usersService;

        /// <summary>
        /// Creates a default instance of <see cref="PlannedMealsService"/>, using default <see cref="PlannedMealsEndpoints"/> and <see cref="UsersService"/><br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public PlannedMealsService() : this(new PlannedMealsEndpoints(), new UsersService())
        {

        }

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealsService"/> with a specified <see cref="IPlannedMealsEndpoints"/> and <see cref="IUsersService"/><br/>
        /// <br/>
        /// <b>Precondition: </b>plannedMealsEndpoints != null<br/>
        /// &amp;&amp; usersService != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="plannedMealsEndpoints"></param>
        /// <param name="usersService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlannedMealsService(IPlannedMealsEndpoints plannedMealsEndpoints, IUsersService usersService)
        {
            this.plannedMealsEndpoints =
                plannedMealsEndpoints ?? throw new ArgumentNullException(nameof(plannedMealsEndpoints));
            this.usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        /// <inheritdoc/>
        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId)
        {
            if (Session.Key == null)
            {
                throw new InvalidOperationException(SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new InvalidOperationException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.plannedMealsEndpoints.AddPlannedMeal(mealDate, category, recipeId);
        }

        /// <inheritdoc/>
        public void RemovePlannedMeal(int mealId)
        {
            if (Session.Key == null)
            {
                throw new InvalidOperationException(SessionKeyErrorMessages.SessionKeyCannotBeNull);
            }

            if (string.IsNullOrWhiteSpace(Session.Key))
            {
                throw new InvalidOperationException(SessionKeyErrorMessages.SessionKeyCannotBeEmpty);
            }

            this.usersService.RefreshSessionKey();
            this.plannedMealsEndpoints.RemovePlannedMeal(mealId);
        }

        /// <inheritdoc/>
        public PlannedMeal[] GetPlannedMeals()
        {
            this.usersService.RefreshSessionKey();
            return this.plannedMealsEndpoints.GetPlannedMeals();
        }
    }
}
