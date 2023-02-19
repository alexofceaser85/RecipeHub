using Server.DAL.Ingredients;
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
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IngredientsService"/> class.<br />
        ///<br />
        /// Precondition: usersDal != null<br />
        /// AND ingredientsDal != null<br />
        /// Postcondition: All fields have been assigned to specified values.<br />
        /// </summary>
        public IngredientsService(IUsersDal usersDal, IIngredientsDal ingredientsDal)
        {
            this.usersDal = usersDal ?? throw new ArgumentNullException(nameof(usersDal));
            this.ingredientsDal = ingredientsDal ?? throw new ArgumentNullException(nameof(ingredientsDal));
        }

        /// <inheritdoc />
        public bool AddIngredientToPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
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
        public bool RemoveIngredientFromPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
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
        public bool UpdateIngredientInPantry(Ingredient ingredient, string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new ArgumentException("User must exist in the system.");

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
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
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
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }

            int? userId = this.usersDal.GetIdForSessionKey(sessionKey) ??
                          throw new ArgumentException("User must exist in the system.");

            return this.ingredientsDal.GetIngredientsFor((int) userId);
        }
    }
}