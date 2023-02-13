using System.Data;
using Microsoft.Data.SqlClient;
using Server.DAL.Ingredient;
using Server.Data.Database;

namespace Server.DAL.Ingredients
{
    /// <summary>
    /// Data Access Layer to the Ingredients Table in the Database.
    /// </summary>
    /// <seealso cref="Server.DAL.Ingredient.IIngredientsDal" />
    public class IngredientsDal : IIngredientsDal
    {

        /// <inheritdoc />
        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey)
        {
            //TODO: Check if ingredient is in pantry, if not add it.
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {
            if (this.IsIngredientInSystem(ingredient.Name))
            {
                throw new ArgumentException("Ingredient must not be in system already.");
            }
            var query = "INSERT INTO Ingredients (name, measurementType) VALUES (@name, @measurementType)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = ingredient.Name;
            command.Parameters.Add("@measurementType", SqlDbType.Int).Value = (int) ingredient.MeasurementType + 1;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        /// <inheritdoc />
        public IList<string> GetIngredientNamesThatMatchText(string ingredientName)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(string sessionKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool UpdateIngredientInPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool RemoveAllIngredientsFromPantry(string sessionKey)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool IsIngredientInSystem(string ingredientName)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, string sessionKey)
        {
            throw new NotImplementedException();
        }
    }
}
