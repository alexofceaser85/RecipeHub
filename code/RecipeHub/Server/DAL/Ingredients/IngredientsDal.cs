using Server.DAL.Ingredient;

namespace Server.DAL.Ingredients
{
    public class IngredientsDal : IIngredientsDal
    {
        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId)
        {
            var query = "INSERT INTO ";
            //TODO: Check if ingredient is in pantry, if not add it.
            throw new System.NotImplementedException();
        }

        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {

            throw new System.NotImplementedException();
        }

        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveAllIngredientsFromPantry(int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateIngredientInPantry(int amount, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
