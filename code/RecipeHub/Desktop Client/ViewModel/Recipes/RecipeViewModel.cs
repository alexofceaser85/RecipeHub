using Desktop_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes screen.
    /// </summary>
    public class RecipeViewModel
    {
        private readonly IRecipesService service;

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListViewModel"/>.<br/>
        /// Uses an instance of <see cref="RecipesService"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeViewModel() : this(new RecipesService())
        {
        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesService"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>service != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipeViewModel(IRecipesService service)
        {
            this.service = service ??
                           throw new ArgumentNullException(nameof(service),
                               RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);
        }

        /// <summary>
        /// Loads a recipe from the server.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id of the recipe to load</param>
        /// <returns>The recipe information</returns>
        public Recipe LoadRecipe(int recipeId)
        {
            return this.service.GetRecipe(recipeId);
        }

        /// <summary>
        /// Loads the ingredients for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsEmptyOrWhiteSpace(sessionKey)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id of the recipe to load.</param>
        /// <returns>The recipe's ingredients</returns>
        public Ingredient[] LoadIngredients(int recipeId)
        {
            return this.service.GetIngredientsForRecipe(recipeId);
        }

        /// <summary>
        /// Loads the steps for a recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b>!string.IsEmptyOrWhiteSpace(sessionKey)<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id of the recipe to load.</param>
        /// <returns>The recipe's steps</returns>
        public RecipeStep[] LoadSteps(int recipeId)
        {
            return this.service.GetStepsForRecipe(recipeId);
        }
    }
}