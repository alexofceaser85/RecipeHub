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
            this.AddedIngredient.Name = Request.Form["name"];
            this.AddedIngredient.Amount = int.Parse(Request.Form["amount"]!);
            this.AddedIngredient.MeasurementType = (MeasurementType) int.Parse(Request.Form["measurement"]!);
            this.viewModel.AddIngredient(new Ingredient(this.AddedIngredient.Name!, this.AddedIngredient.Amount, this.AddedIngredient.MeasurementType));
            return this.Page();
        }
        //public IActionResult OnPostDeleteIngredient([FromBody] string ingredientName)
        //{
        //    this.viewModel.RemoveIngredient(new Ingredient(ingredientName, 0, MeasurementType.Quantity));
        //    return this.Page();
        //}

        //public IActionResult OnPostUpdateIngredient([FromBody] string ingredientName, [FromBody] int measurementType, [FromBody] int amount)
        //{
        //    this.viewModel.EditIngredient(new Ingredient(ingredientName, amount, (MeasurementType)measurementType));
        //    return this.Page();
        //}

        //public IActionResult OnPostDeleteAllIngredients()
        //{
        //    this.viewModel.RemoveAllIngredients();
        //    return this.Page();
        //}


    }
}
