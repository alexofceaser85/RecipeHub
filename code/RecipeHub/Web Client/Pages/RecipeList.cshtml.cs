using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared_Resources.Model.Ingredients;
using Web_Client.Model.Ingredients;
using Web_Client.ViewModel.Ingredient;

namespace Web_Client.Pages
{
    public class RecipesListModel : PageModel
    {
        private readonly IngredientsViewModel viewModel;

        [BindProperty]
        public IngredientBindingModel AddedIngredient { get; set; }

        public SelectList MeasurementTypesList { get; set; }



        public RecipesListModel()
        {
            this.viewModel = new IngredientsViewModel();
            this.AddedIngredient = new IngredientBindingModel();
            this.MeasurementTypesList = new SelectList(new string[] {"Quantity", "Mass", "Volume"});
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddIngredient()
        {
            MeasurementType type;
            switch (this.MeasurementTypesList.SelectedValue)
            {
                case "Quantity":
                    type = MeasurementType.Quantity;
                    break;
                case "Mass":
                    type = MeasurementType.Mass;
                    break;
                case "Volume":
                    type = MeasurementType.Volume;
                    break;
                default:
                    type = MeasurementType.Quantity;
                    break;
            }
            this.viewModel.AddIngredient(new Ingredient(this.AddedIngredient.Name!, this.AddedIngredient.Amount, type));
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
