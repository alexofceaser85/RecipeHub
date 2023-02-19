using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared_Resources.Model.Ingredients;
using Web_Client.Model.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace Web_Client.Pages
{
    public class IngredientsModel : PageModel
    {
        private readonly IngredientsViewModel viewModel;

        public bool DidErrorOccur = false;

        [BindProperty]
        public IngredientBindingModel AddedIngredient { get; set; }

        public IngredientsModel()
        {
            this.viewModel = new IngredientsViewModel();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddIngredient()
        {
            try
            {
                this.AddedIngredient.Name = Request.Form["name"];
                this.AddedIngredient.Amount = int.Parse(Request.Form["amount"]!);
                this.AddedIngredient.MeasurementType = (MeasurementType)int.Parse(Request.Form["measurement"]!);
                this.viewModel.AddIngredient(new Ingredient(this.AddedIngredient.Name!, this.AddedIngredient.Amount,
                    this.AddedIngredient.MeasurementType));
                return this.Page();
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                return RedirectToPage("/Index");
            }
        }
        public IActionResult OnPostDeleteIngredient()
        {
            try
            {
                var name = Request.Form["Name"];
                this.viewModel.RemoveIngredient(new Ingredient(name, 0, MeasurementType.Quantity));
                return this.Page();
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnPostUpdateIngredient()
        {
            try
            {
                var name = Request.Form["Name"];
                var amount = int.Parse(Request.Form["Amount"]!);
                this.viewModel.EditIngredient(new Ingredient(name.ToString(), amount, MeasurementType.Quantity));
                return this.Page();
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                return RedirectToPage("/Index");
            }
        }

        public IActionResult OnPostDeleteAllIngredients()
        {
            try
            {
                this.viewModel.RemoveAllIngredients();
                return this.Page();
            }
            catch (UnauthorizedAccessException exception)
            {
                TempData["Message"] = exception.Message;
                return RedirectToPage("/Index");
            }
        }


    }
}
