using Web_Client.Endpoints.Recipes;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Filters;
using Shared_Resources.Model.Recipes;

namespace Web_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes List screen.
    /// </summary>
    public class RecipesListViewModel
    {
        private readonly IRecipesService recipesService;
        private readonly IIngredientsService ingredientsService;

        /// <summary>
        /// Gets or sets the Filters.
        /// </summary>
        /// <value>
        /// The Filters.
        /// </value>
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
            this.Filters = new RecipeFilters();
        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesEndpoints"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>recipesService != null<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListViewModel(IRecipesService recipesService, IIngredientsService ingredientsService)
        {
            this.recipesService = recipesService ??
                                  throw new ArgumentNullException(nameof(recipesService),
                                      RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);
            this.ingredientsService = ingredientsService ??
                                      throw new ArgumentNullException(nameof(ingredientsService),
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
            var allRecipes = this.recipesService.GetRecipes(searchTerm);
            var filteredRecipes = allRecipes;

            if (this.Filters.OnlyAvailableIngredients)
            {
                filteredRecipes = this.getFilteredRecipes(filteredRecipes, searchTerm);
            }

            if (this.Filters.MatchTags != null && this.Filters.MatchTags.Length > 1)
            {
                filteredRecipes = this.GetRecipesMatchingTags(filteredRecipes, this.Filters.MatchTags);
            }

            return filteredRecipes;
        }

        private Recipe[] GetRecipesMatchingTags(Recipe[] recipes, string[] tags)
        {
            var recipesMatchingTags = this.recipesService.GetRecipesForTags(tags);
            return recipesMatchingTags.Where(x => recipes.Any(y => y.Id == x.Id)).ToArray();
        }


        private Recipe[] getFilteredRecipes(Recipe[] visibleRecipes, string searchTerm = "")
        {
            var filteredRecipes = new List<Recipe>();
            var pantryIngredients = this.ingredientsService.GetAllIngredientsForUser();
            var ingredientsCache = new Dictionary<string, int>();

            foreach (var ingredient in pantryIngredients)
            {
                ingredientsCache[ingredient.Name] = ingredient.Amount;
            }

            visibleRecipes = this.recipesService.GetRecipes(searchTerm);
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