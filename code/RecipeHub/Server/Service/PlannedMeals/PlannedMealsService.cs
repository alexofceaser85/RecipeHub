using System.Diagnostics.CodeAnalysis;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;
using Shared_Resources.Utils.Dates;

namespace Server.Service.PlannedMeals
{
    /// <summary>
    /// The service for the planned meals
    /// </summary>
    public class PlannedMealsService : IPlannedMealsService
    {
        private readonly IPlannedMealsDal plannedMealsDal;
        private readonly IUsersDal usersDal;
        private readonly IRecipesDal recipesDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMealsService"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public PlannedMealsService()
        {
            this.plannedMealsDal = new PlannedMealsDal();
            this.usersDal = new UsersDal();
            this.recipesDal = new RecipeDal();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlannedMealsService"/> class.
        ///
        /// Precondition: plannedMealsDal != null AND usersDal != null
        /// Postcondition: None
        /// </summary>
        /// <param name="plannedMealsDal">The planned meals dal.</param>
        /// <param name="usersDal">The users dal.</param>
        /// <param name="recipesDal">The recipes dal</param>
        public PlannedMealsService(IPlannedMealsDal plannedMealsDal, IUsersDal usersDal, IRecipesDal recipesDal)
        {
            if (plannedMealsDal == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.PlannedMealsDalCannotBeNull);
            }

            if (usersDal == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.UsersDalCannotBeNull);
            }

            if (recipesDal == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.RecipesDalCannotBeNull);
            }

            this.plannedMealsDal = plannedMealsDal;
            this.usersDal = usersDal;
            this.recipesDal = recipesDal;
        }

        /// <summary>
        /// Adds the planned meal.
        /// 
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        /// <exception cref="System.UnauthorizedAccessException">If the session is not valid</exception>
        /// <returns>Whether or not the meal was added</returns>
        public bool AddPlannedMeal(string sessionKey, DateTime mealDate, MealCategory category, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (userId == null)
            {
                throw new UnauthorizedAccessException(PlannedMealsServiceErrorMessages.InvalidSession);
            }

            if (this.plannedMealsDal.IsPlannedMealInSystem(userId.Value, mealDate, category, recipeId))
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.RecipeAlreadyInPlannedMeal);
            }

            return this.plannedMealsDal.AddPlannedMeal(userId.Value, mealDate, category, recipeId);
        }

        /// <summary>
        /// Gets the planned meals.
        ///
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="plannedMealsDate">The planned meals date</param>
        /// <returns>
        /// The planned meals
        /// </returns>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        /// <exception cref="System.UnauthorizedAccessException">If the session is not valid</exception>
        public PlannedMeal[] GetPlannedMeals(string sessionKey, DateTime plannedMealsDate)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (userId == null)
            {
                throw new UnauthorizedAccessException(PlannedMealsServiceErrorMessages.InvalidSession);
            }

            var datesForMeals = DateUtils.GenerateDateTimesFromWeekToNextWeek(plannedMealsDate);
            var plannedMeals = new List<PlannedMeal>();

            this.getPlannedMeals(datesForMeals, userId, plannedMeals);

            return plannedMeals.ToArray();
        }

        private void getPlannedMeals(DateTime[] datesForMeals, [DisallowNull] int? userId, ICollection<PlannedMeal> plannedMeals)
        {
            foreach (var date in datesForMeals)
            {
                var mealsForCategory = new List<MealsForCategory>();
                this.getCategoriesForMeal(userId, date, mealsForCategory);

                var plannedMeal = new PlannedMeal(date, mealsForCategory.ToArray());
                plannedMeals.Add(plannedMeal);
            }
        }

        private void getCategoriesForMeal([DisallowNull] int? userId, DateTime date, ICollection<MealsForCategory> mealsForCategory)
        {
            foreach (var category in Enum.GetValues(typeof(MealCategory)).Cast<MealCategory>())
            {
                var recipes = new List<Recipe>();
                var recipeIds = this.plannedMealsDal.GetPlannedMealRecipes(userId.Value, date, category);

                this.getRecipesFromId(recipeIds, recipes);

                var mealForCategory = new MealsForCategory(category, recipes.ToArray());
                mealsForCategory.Add(mealForCategory);
            }
        }

        private void getRecipesFromId(int[] recipeIds, ICollection<Recipe> recipes)
        {
            foreach (var id in recipeIds)
            {
                var recipe = this.recipesDal.GetRecipe(id);

                if (recipe != null)
                {
                    recipes.Add(recipe.Value);
                }
            }
        }

        /// <summary>
        /// Removes a planned meal.
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <exception cref="System.ArgumentException">If the preconditions are not met</exception>
        /// <exception cref="System.UnauthorizedAccessException">If the session is not valid</exception>
        /// <return>Whether or not the meal was removed</return>
        public bool RemovePlannedMeal(string sessionKey, DateTime mealDate, MealCategory category, int recipeId)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(PlannedMealsServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (userId == null)
            {
                throw new UnauthorizedAccessException(PlannedMealsServiceErrorMessages.InvalidSession);
            }

            return this.plannedMealsDal.RemovePlannedMeal(userId.Value, mealDate, category, recipeId);
        }

        /// <summary>
        /// Removes the out of date meals.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="mealDate">The meal date.</param>
        public void RemoveOutOfDateMeals(DateTime mealDate)
        {
            this.plannedMealsDal.RemoveOutOfDateMeals(mealDate);
        }
    }
}
