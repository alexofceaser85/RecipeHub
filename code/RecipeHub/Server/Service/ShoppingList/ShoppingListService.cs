using Server.DAL.Ingredients;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace Server.Service.ShoppingList
{
    /// <summary>
    /// The service for the shopping list
    /// </summary>
    public class ShoppingListService : IShoppingListService
    {
        private readonly IUsersDal usersDal;
        private readonly IPlannedMealsDal plannedMealsDal;
        private readonly IIngredientsDal ingredientsDal;
        private readonly IRecipesDal recipesDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListService"/> class.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        public ShoppingListService()
        {
            this.usersDal = new UsersDal();
            this.plannedMealsDal = new PlannedMealsDal();
            this.ingredientsDal = new IngredientsDal();
            this.recipesDal = new RecipeDal();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingListService"/> class.
        ///
        /// Precondition:
        /// usersDal != null
        /// AND plannedMealsDal != null
        /// AND ingredientsDal != null
        /// AND recipesDal != null
        /// Postcondition: None
        /// </summary>
        /// <param name="usersDal">The data access layer for the users</param>
        /// <param name="plannedMealsDal">The data access layer for the planned meals</param>
        /// <param name="ingredientsDal">The data access layer for the ingredients</param>
        /// <param name="recipesDal">The data access layer for the recipes</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public ShoppingListService(IUsersDal usersDal, IPlannedMealsDal plannedMealsDal, IIngredientsDal ingredientsDal, IRecipesDal recipesDal)
        {
            if (usersDal == null)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.UsersDalCannotBeNull);
            }

            if (plannedMealsDal == null)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.PlannedMealsDalCannotBeNull);
            }

            if (ingredientsDal == null)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.IngredientsDalCannotBeNull);
            }

            if (recipesDal == null)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.RecipesDalCannotBeNull);
            }

            this.usersDal = usersDal;
            this.plannedMealsDal = plannedMealsDal;
            this.ingredientsDal = ingredientsDal;
            this.recipesDal = recipesDal;
        }

        /// <summary>
        /// Gets the shopping list ingredients.
        ///
        /// Precondition: sessionKey != null AND sessionKey IS NOT empty
        /// Postcondition: None
        /// </summary>
        /// <param name="sessionKey">The session key.</param>
        /// <returns>The shopping list ingredients</returns>
        public Ingredient[] GetShoppingListIngredients(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.SessionKeyCannotBeNull);
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new ArgumentException(ShoppingListServiceErrorMessages.SessionKeyCannotBeEmpty);
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (userId == null)
            {
                throw new UnauthorizedAccessException(ShoppingListServiceErrorMessages.InvalidSessionKeyErrorMessage);
            }

            var plannedMealIngredients = this.populatePlannedMealRecipes(userId.Value);
            var missingIngredients = new List<Ingredient>();
            var userIngredients = this.ingredientsDal.GetIngredientsFor(userId.Value);
            this.populatePlannedMealRecipes(userId.Value);

            foreach (var plannedMealIngredient in plannedMealIngredients)
            {
                missingIngredients.AddRange(this.addIngredientsUserNeedsForMeal(plannedMealIngredient, userIngredients));
            }

            return groupIngredientsByAmount(missingIngredients);
        }

        private List<Ingredient> populatePlannedMealRecipes(int userId)
        {
            var plannedMealIngredients = new List<Ingredient>();
            var plannedMealRecipes = this.plannedMealsDal.GetAllPlannedMealRecipes(userId);

            foreach (var recipe in plannedMealRecipes)
            {
                plannedMealIngredients.AddRange(this.recipesDal.GetIngredientsForRecipe(recipe));
            }

            return plannedMealIngredients;
        }

        private IList<Ingredient> addIngredientsUserNeedsForMeal(Ingredient plannedMealIngredient, IList<Ingredient> userIngredients)
        {
            var missingIngredients = new List<Ingredient>();
            var userIngredientIndex = this.findIndex(userIngredients, plannedMealIngredient);

            if (this.userHasIngredient(userIngredients, plannedMealIngredient))
            {
                missingIngredients.AddRange(addIngredientPresentInUsersIngredients(plannedMealIngredient, userIngredients, userIngredientIndex));
            }
            else
            {
                missingIngredients.Add(plannedMealIngredient);
            }

            return missingIngredients;
        }

        private bool userHasIngredient(IList<Ingredient> userIngredients, Ingredient plannedMealIngredient)
        {
            var userIngredientIndex = this.findIndex(userIngredients, plannedMealIngredient);
            return userIngredientIndex != -1;
        }

        private static IList<Ingredient> addIngredientPresentInUsersIngredients(Ingredient plannedMealIngredient, IList<Ingredient> userIngredients, int userIngredientIndex)
        {
            IList<Ingredient> missingIngredients = new List<Ingredient>();
            var currentUserIngredient = userIngredients[userIngredientIndex];

            if (currentUserIngredient.Amount >= plannedMealIngredient.Amount)
            {
                deductIngredientFromUsersIngredients(plannedMealIngredient, userIngredients, userIngredientIndex, currentUserIngredient);
            }
            else
            {
                missingIngredients.Add(deductFromUsersIngredientsAndGetRemainder(plannedMealIngredient, userIngredients, userIngredientIndex, currentUserIngredient));
            }

            return missingIngredients;
        }

        private static void deductIngredientFromUsersIngredients(Ingredient plannedMealIngredient, IList<Ingredient> userIngredients,
            int userIngredientIndex, Ingredient currentUserIngredient)
        {
            var updatedIngredient = new Ingredient(
                currentUserIngredient.Name,
                currentUserIngredient.Amount - plannedMealIngredient.Amount,
                plannedMealIngredient.MeasurementType);
            userIngredients[userIngredientIndex] = updatedIngredient;
        }

        private static Ingredient deductFromUsersIngredientsAndGetRemainder(Ingredient plannedMealIngredient,
            IList<Ingredient> userIngredients, int userIngredientIndex, Ingredient currentUserIngredient)
        {
            var updatedUserIngredient = new Ingredient(
                currentUserIngredient.Name,
                0,
                plannedMealIngredient.MeasurementType);
            var updatedIngredient = new Ingredient(
                currentUserIngredient.Name,
                plannedMealIngredient.Amount - currentUserIngredient.Amount,
                plannedMealIngredient.MeasurementType);
            userIngredients[userIngredientIndex] = updatedUserIngredient;
            return updatedIngredient;
        }

        private static Ingredient[] groupIngredientsByAmount(List<Ingredient> missingIngredients)
        {
            var groups = missingIngredients
                .GroupBy(item => item.Name)
                .Select(group => new
                {
                    group.Key,
                    Sum = group.Sum(item => item.Amount),
                    group.FirstOrDefault().MeasurementType
                })
                .ToList();

            var result = groups
                .Select(group => new Ingredient(group.Key, group.Sum, group.MeasurementType))
                .ToArray();

            return result;
        }

        private int findIndex(IList<Ingredient> userIngredients, Ingredient plannedMealIngredient)
        {
            var matchedPlannedMealIngredientIndex = -1;
            for (int i = 0; i < userIngredients.Count; i++)
            {
                if (userIngredients[i].Name == plannedMealIngredient.Name)
                {
                    matchedPlannedMealIngredientIndex = i;
                    break;
                }
            }

            return matchedPlannedMealIngredientIndex;
        }
    }
}
