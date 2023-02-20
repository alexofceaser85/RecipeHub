using Web_Client.Service.RecipeTypes;

namespace Desktop_Client.ViewModel.RecipeTypes
{
    public class RecipeTypesViewModel
    {
        private readonly IRecipeTypesService service;

        public RecipeTypesViewModel()
        {
            this.service = new RecipeTypesService();
        }

        public string[] GetSimilarRecipeTypes()
        {
            return this.service.GetSimilarRecipeTypes();
        }
    }
}
