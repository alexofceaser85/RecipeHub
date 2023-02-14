using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Ingredients;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.ViewModel.Ingredients
{
    /// <summary>
    /// 
    /// </summary>
    public class AddIngredientsViewModel
    {
        private readonly IIngredientsService service;

        public AddIngredientsViewModel()
        {
            this.service = new IngredientsService();
        }

        public AddIngredientsViewModel(IIngredientsService service)
        {
            this.service = service;
        }

        public bool AddIngredient(Ingredient ingredient)
        {
            try
            {
                return this.service.AddIngredient(ingredient);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string[] GetSuggestions(string ingredientName)
        {
            return this.service.GetSuggestions(ingredientName);
        }
    }
}
