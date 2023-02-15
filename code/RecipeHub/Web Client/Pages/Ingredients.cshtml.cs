using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_Client.ViewModel.Ingredient;

namespace Web_Client.Pages
{
    public class IngredientsModel : PageModel
    {
        private readonly IngredientsViewModel viewModel;

        public IngredientsModel()
        {
            this.viewModel = new IngredientsViewModel();
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }

        public void OnPostRemoveIngredient(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {
            this.viewModel.RemoveIngredient(ingredient);
        }
    }
}
