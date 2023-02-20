using Web_Client.Endpoints.RecipeTypes;

namespace Web_Client.Service.RecipeTypes
{
    public class RecipeTypesService : IRecipeTypesService
    {
        private readonly IRecipeTypesEndpoints endpoints;

        public RecipeTypesService()
        {
            this.endpoints = new RecipeTypesEndpoints();
        }

        public RecipeTypesService(IRecipeTypesEndpoints endpoints)
        {
            this.endpoints = endpoints;
        }

        public string[] GetSimilarRecipeTypes()
        {
            return this.endpoints.GetSimilarRecipeTypes();
        }
    }
}
