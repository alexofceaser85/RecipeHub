using Shared_Resources.Model.Ingredients;

namespace Server.Service.Ingredients
{
    public interface IIngredientsService
    {
        //TODO: Add documentation.
        public bool AddIngredientToPantry(Ingredient ingredient, string sessionKey);

        public bool RemoveIngredientFromPantry(Ingredient ingredient, string sessionKey);

        public bool UpdateIngredientInPantry(Ingredient ingredient, string sessionKey);

        public bool RemoveAllIngredientsFromPantry(string sessionKey);

        public IList<string> GetAllIngredientsThatMatch(string ingredientName);

        public IList<Ingredient> GetIngredientsFor(string sessionKey);
    }
}
