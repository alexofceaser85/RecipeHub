using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Client.Endpoints.PlannedMeals;
using Shared_Resources.Model.PlannedMeals;

namespace Web_Client.Service.PlannedMeals
{
    /// <summary>
    /// The service for interfacing with <see cref="IPlannedMealsEndpoints"/>
    /// </summary>
    public interface IPlannedMealsService
    {
        /// <summary>
        /// Adds a planned meal to the server.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; A recipe with recipeId exists
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
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// &amp;&amp; A recipe with recipeId exists
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="mealId">The id for the meal to remove</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void RemovePlannedMeal(int mealId);

        /// <summary>
        /// Gets the planned meals for the current user.<br/>
        /// <br/>
        /// <b>Precondition: </b>The active user's session key is valid<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public PlannedMeal[] GetPlannedMeals();
    }
}
