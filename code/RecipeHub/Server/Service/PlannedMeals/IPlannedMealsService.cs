using Shared_Resources.Model.PlannedMeals;

namespace Server.Service.PlannedMeals
{
    /// <summary>
    /// The service for the planned meals
    /// </summary>
    public interface IPlannedMealsService
    {
        /// <summary>
        /// Adds the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was added</returns>
        public bool AddPlannedMeal(string sessionKey, DateTime mealDate, MealCategory category, int recipeId);

        /// <summary>
        /// Removes the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was added</returns>
        public bool RemovePlannedMeal(string sessionKey, DateTime mealDate, MealCategory category, int recipeId);

        /// <summary>
        /// Gets the planned meals.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="plannedMealsDate">The planned meals date</param>
        /// <returns>The planned meals</returns>
        public PlannedMeal[] GetPlannedMeals(string sessionKey, DateTime plannedMealsDate);
        /// <summary>
        /// Removes the out of date meals.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="mealDate">The meal date.</param>
        public void RemoveOutOfDateMeals(DateTime mealDate);
    }
}
