using Desktop_Client.ViewModel.RecipeTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Data.UserData;
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
        public Recipe[] Recipes { get; set; }
        public string[] RecipeTypes { get; set; }

        public FiltersBindingModel BindingModel { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListModel"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListModel()
        {
            Recipes = new Recipe[0];
            RecipeTypes = new string[0];

            try
            {
                this.viewModel = new RecipesListViewModel();
                Recipes = this.viewModel.GetRecipes("");
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                Response.Redirect("/Index");
            }

            this.BindingModel = new FiltersBindingModel();

            var recipeTagsViewModel = new RecipeTypesViewModel();
            RecipeTypes = recipeTagsViewModel.GetSimilarRecipeTypes();
        }

        public void OnPostSubmit(FiltersBindingModel bindingModel)
        {
            this.BindingModel = bindingModel;
            this.viewModel.filters.MatchTag = bindingModel.FiltersTypes;
            var filteredRecipes = this.viewModel.GetRecipes("");
            Recipes = filteredRecipes;
        }
    }
}