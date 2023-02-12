namespace Server.DAL.Ingredient
{
    /// <summary>
    /// Interface for the Data Access Layer to the Ingredients Table.
    /// </summary>
    public interface IIngredientsDal
    {
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(int userId);

        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient);

        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId);

        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId);

        public bool UpdateIngredientInPantry(int amount, int userId);

        public bool RemoveAllIngredientsFromPantry(int userId);
    }
}
