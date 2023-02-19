using Desktop_Client.Endpoints.Recipes;
using Desktop_Client.Model;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.View.Dialog;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes List screen.
    /// </summary>
    public class RecipesListViewModel
    {
        private readonly IRecipesService recipesService;
        private readonly IIngredientsService ingredientsService;

        /// <summary>
        /// The filters for recipe queries.
        /// </summary>
        public RecipeFilters Filters { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListViewModel"/>.<br/>
        /// Uses an instance of <see cref="RecipesEndpoints"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListViewModel() : this(new RecipesService(), new IngredientsService())
        {
        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesEndpoints"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>recipesService != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListViewModel(IRecipesService recipesService, IIngredientsService ingredientsService)
        {
            this.recipesService = recipesService ?? throw new ArgumentNullException(nameof(recipesService), 
                RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);
            this.ingredientsService = ingredientsService ?? throw new ArgumentNullException(nameof(ingredientsService),
                RecipesViewModelErrorMessages.IngredientsServiceCannotBeNull);
            this.Filters = new RecipeFilters();
        }

        /// <summary>
        /// Gets the visible recipes from the server.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="searchTerm">The search term to query for.</param>
        /// <returns></returns>
        public Recipe[] GetRecipes(string searchTerm = "")
        {
            if (this.Filters.OnlyAvailableIngredients)
            {
                return this.getFilteredRecipes(searchTerm);
            }
            return this.recipesService.GetRecipes(searchTerm);
        }

        private Recipe[] getFilteredRecipes(string searchTerm = "")
        {
            var filteredRecipes = new List<Recipe>();
            var pantryIngredients = this.ingredientsService.GetAllIngredientsForUser();
            var ingredientsCache = new Dictionary<string, int>();

            foreach (var ingredient in pantryIngredients)
            {
                ingredientsCache[ingredient.Name] = ingredient.Amount;
            }

            var visibleRecipes = this.recipesService.GetRecipes(searchTerm);
            foreach (var recipe in visibleRecipes)
            {
                var requiredIngredients = this.recipesService.GetIngredientsForRecipe(recipe.Id);
                var canMake = true;
                foreach (var ingredient in requiredIngredients)
                {
                    if (!ingredientsCache.ContainsKey(ingredient.Name))
                    {
                        canMake = false;
                        break;
                    }
                }

                if (canMake)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes.ToArray();
        }

        /// <summary>
        /// Opens a dialog for selecting the recipe Filters. <br/>
        /// Updates the displayed recipes if changes are saved.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>Selected Filters reflect changes in the dialog, if saved.
        /// </summary>
        public void OpenFiltersDialog()
        {
            var filtersDialog = new RecipeListFilterDialog(this.Filters);
            if (filtersDialog.ShowDialog() == DialogResult.OK)
            {
                this.Filters = filtersDialog.Filters;
            }
        }

        /// <summary>
        /// Adds a recipe authored by the active user.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is publicly viewable or not.</param>
        public void AddRecipe(string name, string description, bool isPublic)
        {
            this.recipesService.AddRecipe(name, description, isPublic);
        }

        /// <summary>
        /// Removes a recipe from the database, if the user is the author of the recipe.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to remove.</param>
        public void RemoveRecipe(int recipeId)
        {
            this.recipesService.RemoveRecipe(recipeId);
        }

        /// <summary>
        /// Edits a recipe, updating the name, description, and public status.<br/>
        /// <br/>
        /// <b>Precondition: </b> !string.IsNullOrWhiteSpace(sessionKey)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(name)<br/>
        /// &amp;&amp; !string.IsNullOrWhiteSpace(description)<br/>
        /// <b>Postcondition: </b> None
        /// </summary>
        /// <param name="recipeId">The ID for the recipe to update.</param>
        /// <param name="name">The name of the recipe.</param>
        /// <param name="description">The description of the recipe.</param>
        /// <param name="isPublic">Whether the recipe is public or not.</param>
        public void EditRecipe(int recipeId, string name, string description, bool isPublic)
        {
            this.recipesService.EditRecipe(recipeId, name, description, isPublic);
        }
    }
}