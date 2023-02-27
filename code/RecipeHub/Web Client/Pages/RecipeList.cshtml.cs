using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared_Resources.Model.Recipes;
using Web_Client.Model.Filters;
using Web_Client.ViewModel.Recipes;
using Web_Client.ViewModel.RecipeTypes;

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
        /// Gets or sets a value indicating whether [only available ingredients].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [only available ingredients]; otherwise, <c>false</c>.
        /// </value>
        public bool OnlyAvailableIngredients { 
            get => this.viewModel.Filters.OnlyAvailableIngredients;
            set => this.viewModel.Filters.OnlyAvailableIngredients = value;
        }

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
            this.viewModel.Filters.OnlyAvailableIngredients = true;

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
        /// <returns>the current page.</returns>
        public void OnPostSubmit(FiltersBindingModel bindingModel)
        {
            this.BindingModel = bindingModel;
            this.viewModel.Filters.MatchTags = bindingModel.FiltersTypes.ToArray();
            var request = Request.Form;
            bool onlyAvailableIngredients = Request.Form.ContainsKey("only-available-ingredients");
            this.viewModel.Filters.OnlyAvailableIngredients = onlyAvailableIngredients;
            var filteredRecipes = this.viewModel.GetRecipes();
            this.Recipes = filteredRecipes;

            ModelState.Clear();
            ModelState.SetModelValue("BindingModel.FiltersTypes",
                new ValueProviderResult(bindingModel.FiltersTypes.ToArray()));
            ModelState.SetModelValue("OnlyAvailableIngredients", new ValueProviderResult(onlyAvailableIngredients.ToString()));
        }
    }
}