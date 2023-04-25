using Shared_Resources.Model.PlannedMeals;

namespace Desktop_Client.Endpoints.PlannedMeals
{
    /// <summary>
    /// The endpoints for interacting with the PlannedMeals controller on the server
    /// </summary>
    public interface IPlannedMealsEndpoints
    {
        /// <summary>
        /// Adds a planned meal to the server.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="mealDate">The date for the meal to be added</param>
        /// <param name="category">The category for the meal</param>
        /// <param name="recipeId">The recipe to be added to the meal</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddPlannedMeal(DateTime mealDate, MealCategory category, int recipeId);

        /// <summary>
        /// Removes a meal from the server.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="mealId">The id for the recipe to remove from the meal</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void RemovePlannedMeal(int mealId);

        /// <summary>
        /// Gets the planned meals for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns>The user's planned meals</returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public PlannedMeal[] GetPlannedMeals();
    }
}
