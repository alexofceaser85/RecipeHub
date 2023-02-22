using Desktop_Client.ViewModel.RecipeTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Model.Recipes;
using Web_Client.Model.Filters;
using Web_Client.ViewModel.Recipes;

namespace Web_Client.Pages
{
    /// <summary>
    /// The model for the recipes web page
    /// </summary>
    public class RecipesListModel : PageModel
    {
        private RecipesListViewModel viewModel;
        /// <summary>
        /// Gets or sets the recipes.
        /// </summary>
        /// <value>
        /// The recipes.
        /// </value>
        public Recipe[] Recipes { get; set; }
        /// <summary>
        /// Gets or sets the recipe types.
        /// </summary>
        /// <value>
        /// The recipe types.
        /// </value>
        public string[] RecipeTypes { get; set; }
        /// <summary>
        /// Gets or sets the binding model.
        /// </summary>
        /// <value>
        /// The binding model.
        /// </value>
        public FiltersBindingModel BindingModel { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListModel"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListModel()
        {
            this.Recipes = new Recipe[0];
            this.RecipeTypes = new string[0];
            this.viewModel = new RecipesListViewModel();

            try
            {
                this.Recipes = this.viewModel.GetRecipes();
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                Response.Redirect("/Index");
            }

            this.BindingModel = new FiltersBindingModel();

            var recipeTagsViewModel = new RecipeTypesViewModel();
            this.RecipeTypes = recipeTagsViewModel.GetAllRecipeTypes();
        }

        /// <summary>
        /// Called when [post submit].
        /// </summary>
        /// <param name="bindingModel">The binding model.</param>
        public void OnPostSubmit(FiltersBindingModel bindingModel)
        {
            this.BindingModel = bindingModel;
            this.viewModel.Filters.MatchTags = bindingModel.FiltersTypes.ToArray();
            var filteredRecipes = this.viewModel.GetRecipes();
            this.Recipes = filteredRecipes;
        }
    }
}