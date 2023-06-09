﻿using Shared_Resources.Model.PlannedMeals;

namespace Server.DAL.PlannedMeals
{
    /// <summary>
    /// The data access layer for the planned meals
    /// </summary>
    public interface IPlannedMealsDal
    {
        /// <summary>
        /// Adds the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was added</returns>
        public bool AddPlannedMeal(int userId, DateTime mealDate, MealCategory category, int recipeId);

        /// <summary>
        /// Removes the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was removed</returns>
        public bool RemovePlannedMeal(int userId, int mealId);

        /// <summary>
        /// Gets the planned meal recipe ids.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <returns>The recipes for a planned meal</returns>
        public int[] GetPlannedMealRecipes(int userId, DateTime mealDate, MealCategory category);

        /// <summary>
        /// Gets the planned meal ids for a specified meal.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <returns>The ids for a planned meal</returns>
        public int[] GetPlannedMealIds(int userId, DateTime mealDate, MealCategory category);

        /// <summary>
        /// Gets the recipe id associated with a specified meal id.<br/>
        /// <br/>
        /// <b>Precondition:</b> None<br/>
        /// <b>Postcondition:</b> None
        /// </summary>
        /// <param name="mealId">The id for the meal</param>
        /// <returns>The recipe id for the meal</returns>
        public int GetRecipeIdForMealId(int mealId);

        /// <summary>
        /// Gets all of the planned meal recipes for a user
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The recipes for a planned meal</returns>
        public int[] GetAllPlannedMealRecipes(int userId);

        /// <summary>
        /// Determines whether [is planned meal in system] [the specified user identifier].
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is planned meal in system] [the specified user identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPlannedMealInSystem(int userId, DateTime mealDate, MealCategory category, int recipeId);

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
