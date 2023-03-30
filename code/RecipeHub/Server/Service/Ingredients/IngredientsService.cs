using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Shared_Resources.Model.Ingredients;

namespace Server.Service.Ingredients
{
    /// <summary>
    /// An interface for interacting with the DAL layer for the Ingredients table.
    /// </summary>
    public class IngredientsService : IIngredientsService
    {
        private readonly IUsersDal usersDal;
        private readonly IIngredientsDal ingredientsDal;
        private readonly IRecipesDal recipesDal;

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        ///<br />
        /// Precondition: None<br />
        /// Postcondition: All fields have been assigned to default values.<br />
        /// </summary>
        public IngredientsService()
        {
            this.usersDal = new UsersDal();
            this.ingredientsDal = new IngredientsDal();
            this.recipesDal = new RecipeDal();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        ///<br />
        /// Precondition: usersDal != null<br />
        /// AND ingredientsDal != null<br />
        /// AND recipesDal != null <br />
        /// Postcondition: All fields have been assigned to specified values.<br />
        /// </summary>
        public IngredientsService(IUsersDal usersDal, IIngredientsDal ingredientsDal, IRecipesDal recipesDal)
        {
            this.usersDal = usersDal ?? throw new ArgumentNullException(nameof(usersDal));
            this.ingredientsDal = ingredientsDal ?? throw new ArgumentNullException(nameof(ingredientsDal));
            this.recipesDal = recipesDal ?? throw new ArgumentNullException(nameof(recipesDal));
        }

        /// <inheritdoc />
        public bool AddIngredientToPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(nameof(sessionKey));
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session key cannot be null");
            }
            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            if (!this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                this.ingredientsDal.AddIngredientToSystem(ingredient);
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int) userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }

            if (this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int) userId))
            {
                throw new ArgumentException("Ingredient must not be in pantry already.");
            }

            return this.ingredientsDal.AddIngredientToPantry(ingredient, (int) userId);
        }

        /// <inheritdoc />
        public void AddIngredientsToPantry(Ingredient[] ingredients, string sessionKey)
        {
            if (ingredients == null)
            {
                throw new ArgumentException("Ingredients to add cannot be null");
            }

            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException("Session key cannot be null");
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session key cannot be null");
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new UnauthorizedAccessException("User must exist in the system.");
            }

            foreach (var ingredient in ingredients)
            {
                if (this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int)userId))
                {
                    var userIngredient = this.ingredientsDal.GetIngredientsFor(userId.Value)
                        .First(x => x.Name == ingredient.Name);
                    var newIngredient = new Ingredient(userIngredient.Name, userIngredient.Amount + ingredient.Amount,
                        userIngredient.MeasurementType);
                    this.ingredientsDal.UpdateIngredientInPantry(newIngredient, userId.Value);
                }
                else
                {
                    this.ingredientsDal.AddIngredientToPantry(ingredient, userId.Value);
                }
            }
        }

        /// <inheritdoc />
        public IList<Ingredient> GetMissingIngredientsForRecipe(int recipeId, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException("Session key cannot be null");
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session key cannot be empty");
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new UnauthorizedAccessException("User must exist in the system.");
            }

            var recipeIngredients = this.recipesDal.GetIngredientsForRecipe(recipeId);
            var userIngredients = this.ingredientsDal.GetIngredientsFor(userId.Value);
            var missingIngredients = new List<Ingredient>();

            foreach (var ingredient in recipeIngredients)
            {
                var userIngredient = userIngredients.FirstOrDefault(x => x.Name == ingredient.Name);

                if (userIngredient.Amount < ingredient.Amount)
                {
                    missingIngredients.Add(new Ingredient(ingredient.Name, ingredient.Amount - userIngredient.Amount, ingredient.MeasurementType));
                }
            }

            return missingIngredients;
        }

        /// <inheritdoc />
        public bool RemoveIngredientFromPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(nameof(sessionKey));
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session Key cannot be empty");
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            if (!this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                throw new ArgumentException("Ingredient must be in system already.");
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                         throw new ArgumentException("User must exist in the system.");

            if (!this.ingredientsDal.IsIngredientInPantry(ingredient.Name, userId))
            {
                throw new ArgumentException("Ingredient must be in pantry already.");
            }

            return this.ingredientsDal.RemoveIngredientFromPantry(ingredient, userId);
        }

        /// <inheritdoc />
        public void RemoveIngredientsForRecipe(int recipeId, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException("Session key cannot be null");
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session key cannot be empty");
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            var userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new UnauthorizedAccessException("User must exist in the system.");
            }

            var recipeIngredients = this.recipesDal.GetIngredientsForRecipe(recipeId);
            var userIngredients = this.ingredientsDal.GetIngredientsFor(userId.Value);

            foreach (var ingredient in recipeIngredients)
            {
                var userIngredient = userIngredients.FirstOrDefault(x => x.Name == ingredient.Name);

                if (userIngredient.Amount == 0)
                {
                    continue;
                }

                if (userIngredient.Amount <= ingredient.Amount)
                {
                    this.ingredientsDal.RemoveIngredientFromPantry(ingredient, userId.Value);
                }
                else
                {
                    var newIngredient = new Ingredient(ingredient.Name,
                        userIngredient.Amount - ingredient.Amount, ingredient.MeasurementType);
                    this.ingredientsDal.UpdateIngredientInPantry(newIngredient, userId.Value);
                }
            }
        }

        /// <inheritdoc />
        public bool UpdateIngredientInPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(nameof(sessionKey));
            }
            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session Key cannot be empty");
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ?? 
                          throw new UnauthorizedAccessException("User must exist in the system.");

            if (!this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                throw new ArgumentException("Ingredient must be in the system.");
            }

            if (!this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int) userId))
            {
                throw new ArgumentException("Ingredient must be in the pantry.");
            }

            return this.ingredientsDal.UpdateIngredientInPantry(ingredient, (int) userId);
        }

        /// <inheritdoc />
        public bool RemoveAllIngredientsFromPantry(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(nameof(sessionKey));
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("The session key cannot be empty");
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new ArgumentException("User must exist in the system.");

            return this.ingredientsDal.RemoveAllIngredientsFromPantry((int) userId);
        }

        /// <inheritdoc />
        public IList<string> GetAllIngredientsThatMatch(string ingredientName)
        {
            if (ingredientName == null)
            {
                throw new ArgumentNullException(nameof(ingredientName));
            }

            return this.ingredientsDal.GetIngredientNamesThatMatchText(ingredientName);
        }

        /// <inheritdoc/>
        public IList<Ingredient> GetIngredientsFor(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new UnauthorizedAccessException(nameof(sessionKey));
            }

            if (sessionKey.Trim().Length == 0)
            {
                throw new UnauthorizedAccessException("Session key cannot be empty");
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new UnauthorizedAccessException("Session key must exist in the system.");
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new ArgumentException("User must exist in the system.");

            return this.ingredientsDal.GetIngredientsFor((int) userId);
        }
    }
}