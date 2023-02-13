using Server.DAL.Ingredient;
using Server.DAL.Ingredients;
using Server.DAL.Users;
using Shared_Resources.Model.Ingredients;

namespace Server.Service.Ingredients
{
    public class IngredientsService : IIngredientsService
    {
        private IUsersDal usersDal;
        private IIngredientsDal ingredientsDal;

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
            if (this.usersDal == null)
            {
                throw new ArgumentNullException(nameof(usersDal));
            }

            if (this.ingredientsDal == null)
            {
                throw new ArgumentNullException(nameof(ingredientsDal));
            }
            this.usersDal = usersDal;
            this.ingredientsDal = ingredientsDal;
        }

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
            if (!this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }

            if (ingredient.Name == null)
            {
                throw new ArgumentNullException(nameof(ingredient));
            }
            if (!this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                this.ingredientsDal.AddIngredientToSystem(ingredient);
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }
            if (this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int)userId))
            {
                throw new ArgumentException("Ingredient must not be in pantry already.");
            }

            return this.ingredientsDal.AddIngredientToPantry(ingredient, (int)userId);
        }

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
            if (!this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }
            if (this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                throw new ArgumentException("Ingredient must not be in system already.");
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey);

            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }
            if (this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int)userId))
            {
                throw new ArgumentException("Ingredient must be in pantry already.");
            }

            return this.ingredientsDal.RemoveIngredientFromPantry(ingredient, (int)userId);
        }

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

            if (!this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey);
            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }

            if (!this.ingredientsDal.IsIngredientInSystem(ingredient.Name))
            {
                throw new ArgumentException("Ingredient must be in the system.");
            }
            if (!this.ingredientsDal.IsIngredientInPantry(ingredient.Name, (int)userId))
            {
                throw new ArgumentException("Ingredient must be in the pantry.");
            }


            return this.ingredientsDal.UpdateIngredientInPantry(ingredient, (int)userId);
        }

        public bool RemoveAllIngredientsFromPantry(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (!this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey);
            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }

            return this.ingredientsDal.RemoveAllIngredientsFromPantry((int)userId);
        }

        public IList<string> GetAllIngredientsThatMatch(string ingredientName)
        {
            if (ingredientName == null)
            {
                throw new ArgumentNullException(nameof(ingredientName));
            }

            return this.ingredientsDal.GetIngredientNamesThatMatchText(ingredientName);
        }

        public IList<Ingredient> GetIngredientsFor(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException(nameof(sessionKey));
            }

            if (!this.usersDal.VerifySessionKeyDoesNotExist(sessionKey))
            {
                throw new ArgumentException("Session key must exist in the system.");
            }
            int? userId = this.usersDal.GetIdForSessionKey(sessionKey);
            if (!this.usersDal.UserIdExists((int)userId!))
            {
                throw new ArgumentException("User must exist in the system.");
            }

            return this.ingredientsDal.GetIngredientsFor((int)userId);
        }
    }
}
