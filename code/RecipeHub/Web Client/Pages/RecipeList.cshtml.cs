using System.Diagnostics;
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
        public Recipe[] Recipes => this.viewModel.Recipes;
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
            get => RecipesListViewModel.Filters.OnlyAvailableIngredients;
            set => RecipesListViewModel.Filters.OnlyAvailableIngredients = value;
        }

        /// <summary>
        /// Gets the recipe tags.
        /// </summary>
        /// <value>
        /// The recipe tags.
        /// </value>
        public string[][] RecipeTags => this.viewModel.RecipeTags;

        /// <summary>
        /// Creates a default instance of <see cref="RecipesListModel"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public RecipesListModel()
        {
            this.RecipeTypes = Array.Empty<string>();
            this.viewModel = new RecipesListViewModel();

            try
            {
                this.viewModel.GetRecipes();
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
        /// Called when filters are applied.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: Filters are applied<br />
        /// </summary>
        /// <param name="bindingModel">The binding model.</param>
        /// <returns>the current page.</returns>
        public void OnPostSubmit(FiltersBindingModel bindingModel)
        {
            this.BindingModel = bindingModel;
            if (this.BindingModel.FiltersTypes!.Contains(null!))
            {
                this.BindingModel.FiltersTypes.Remove(null!);
            }
            RecipesListViewModel.Filters.MatchTags = bindingModel.FiltersTypes.ToArray();
            this.viewModel.Filters.MatchTags = bindingModel.FiltersTypes.ToArray();
            bool onlyAvailableIngredients = Request.Form.ContainsKey("only-available-ingredients");
            string searchText = Request.Form["SearchText"][0]!;
            RecipesListViewModel.Filters.OnlyAvailableIngredients = onlyAvailableIngredients;
            this.viewModel.SearchTerm = searchText;
            this.viewModel.GetRecipes();

            ModelState.Clear();
            ModelState.SetModelValue("BindingModel.FiltersTypes",
                new ValueProviderResult(bindingModel.FiltersTypes.ToArray()));
            ModelState.SetModelValue("OnlyAvailableIngredients", new ValueProviderResult(onlyAvailableIngredients.ToString()));
            ModelState.SetModelValue("SearchText", new ValueProviderResult(searchText));
        }

    }
}