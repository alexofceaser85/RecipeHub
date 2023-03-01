using Desktop_Client.Endpoints.Recipes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Filters;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.ViewModel.Recipes
{
    /// <summary>
    /// The view model for the Recipes List screen.
    /// </summary>
    public class RecipesListViewModel : INotifyPropertyChanged
    {
        private readonly IRecipesService recipesService;
        private readonly IIngredientsService ingredientsService;

        private string searchTerm;
        private Recipe[] recipes;
        private string[][] recipeTags;

        /// <summary>
        /// The name of the recipe to search for
        /// </summary>
        public string SearchTerm
        {
            get => this.searchTerm;
            set => this.SetField(ref this.searchTerm, value);
        }

        /// <summary>
        /// The list of recipes to display
        /// </summary>
        public Recipe[] Recipes
        {
            get => this.recipes;
            set => this.SetField(ref this.recipes, value);
        }

        /// <summary>
        /// The tags for the recipes
        /// </summary>
        public string[][] RecipeTags
        {
            get => this.recipeTags;
            set => this.SetField(ref this.recipeTags, value);
        }

        /// <summary>
        /// The filters for recipe queries.
        /// </summary>
        public RecipeFilters Filters { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListViewModel"/>.<br/>
        /// Uses an instances of <see cref="RecipesService"/> and <see cref="IngredientsService"/> as the endpoint by default.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.SearchTerm == string.Empty<br/>
        /// &amp;&amp; this.Recipes.Length == 0<br/>
        /// &amp;&amp; this.Filters == new RecipeFilters()
        /// </summary>
        public RecipesListViewModel() : this(new RecipesService(), new IngredientsService())
        {
        }

        /// <summary>
        /// Creates a instance of <see cref="RecipesListViewModel"/> with a specified <see cref="IRecipesEndpoints"/> object.<br/>
        /// <br/>
        /// <b>Precondition: </b>recipesService != null<br/>
        /// <b>Postcondition: </b>this.SearchTerm == string.Empty<br/>
        /// &amp;&amp; this.Recipes.Length == 0<br/>
        /// </summary>
        public RecipesListViewModel(IRecipesService recipesService, IIngredientsService ingredientsService)
        {
            this.recipesService = recipesService ?? throw new ArgumentNullException(nameof(recipesService), 
                RecipesViewModelErrorMessages.RecipesServiceCannotBeNull);
            this.ingredientsService = ingredientsService ?? throw new ArgumentNullException(nameof(ingredientsService),
                RecipesViewModelErrorMessages.IngredientsServiceCannotBeNull);
            this.Filters = new RecipeFilters();
            this.searchTerm = "";
            this.recipes = Array.Empty<Recipe>();
        }

        /// <summary>
        /// Gets the visible recipes from the server, applying any filters in this.Filters and who's name contains this.SearchTerm.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.recipes contains all visible recipes from the server that match the filters.
        /// </summary>
        public void GetRecipes()
        {
            var filteredRecipes = this.recipesService.GetRecipes(this.SearchTerm);

            if (this.Filters.OnlyAvailableIngredients)
            {
                filteredRecipes = this.getRecipesWithOwnedIngredients(filteredRecipes);
            }

            if (this.Filters.MatchTags != null && this.Filters.MatchTags.Length != 0)
            {
                filteredRecipes = this.getRecipesMatchingTags(filteredRecipes, this.Filters.MatchTags.ToArray());
            }

            this.Recipes = filteredRecipes;
            this.RecipeTags = this.GetTagsForRecipes(this.recipes);
        }

        private Recipe[] getRecipesMatchingTags(Recipe[] unfilteredRecipes, string[] tags)
        {
            var recipesMatchingTags = this.recipesService.GetRecipesForTags(tags);
            return recipesMatchingTags.Where(x => unfilteredRecipes.Any(y => y.Id == x.Id)).ToArray();
        }

        private Recipe[] getRecipesWithOwnedIngredients(IEnumerable<Recipe> visibleRecipes)
        {
            var filteredRecipes = new List<Recipe>();
            var pantryIngredients = this.ingredientsService.GetAllIngredientsForUser();
            var ingredientsCache = new Dictionary<string, int>();

            foreach (var ingredient in pantryIngredients)
            {
                ingredientsCache[ingredient.Name] = ingredient.Amount;
            }

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

        private string[][] GetTagsForRecipes(Recipe[] recipes)
        {
            var tags = new string[recipes.Length][];

            for (int i = 0; i < recipes.Length; i++)
            {
                tags[i] = this.recipesService.GetTypesForRecipe(recipes[i].Id);
            }

            return tags;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Fires this.PropertyChanged with the specified property name.<br/>
        /// Defaults to the name of the calling member, allowing for easier use within property bodies.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates a specified field, returning whether or not the value was changed.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.[field] == value
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <param name="field">The field that stores the data for the property</param>
        /// <param name="value">The new value for the field</param>
        /// <param name="propertyName">The name of the property that is being updated.</param>
        /// <returns>Whether the value of the field has changed.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}