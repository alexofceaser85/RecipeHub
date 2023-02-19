using System.Data;
using Microsoft.Data.SqlClient;
using Server.DAL.Ingredient;
using Server.DAL.Users;
using Server.Data.Settings;
using Shared_Resources.Model.Ingredients;

namespace Server.DAL.Ingredients
{
    /// <summary>
    /// Data Access Layer to the Ingredients Table in the Database.
    /// </summary>
    /// <seealso cref="IIngredientsDal" />
    public class IngredientsDal : IIngredientsDal
    {
        
        /// <inheritdoc />
        public bool AddIngredientToPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId)
        {
            var query = "INSERT INTO PantryItems (userId, ingredientId, amount) VALUES (@userId, @ingredientId, @amount)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@ingredientId", SqlDbType.Int).Value = (int)this.GetIngredientIdFor(ingredient.Name)!;
            command.Parameters.Add("@amount", SqlDbType.Int).Value = ingredient.Amount;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        /// <inheritdoc />
        public bool AddIngredientToSystem(Shared_Resources.Model.Ingredients.Ingredient ingredient)
        {
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
            var query = "SELECT name FROM Ingredients WHERE name LIKE @name";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@name", SqlDbType.Char).Value = $"%{ingredientName}%";
            connection.Open();
            using var reader = command.ExecuteReader();
            var ingredientNames = new List<string>();
            while (reader.Read())
            {
                string name = reader.GetString("name").Trim();
                ingredientNames.Add(name);
            }
            return ingredientNames;
        }

        /// <inheritdoc />
        public IList<Shared_Resources.Model.Ingredients.Ingredient> GetIngredientsFor(int userId)
        {
            var query = "SELECT Ingredients.name, Ingredients.measurementType, PantryItems.amount FROM Ingredients, PantryItems WHERE PantryItems.ingredientId = Ingredients.ingredientId AND PantryItems.userId = @userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            using var reader = command.ExecuteReader();
            var ingredients = new List<Shared_Resources.Model.Ingredients.Ingredient>();
            while (reader.Read())
            {
                string name = reader.GetString("name").Trim();
                MeasurementType type = (MeasurementType) reader.GetInt32("measurementType") - 1;
                int amount = reader.GetInt32("amount");
                var ingredient = new Shared_Resources.Model.Ingredients.Ingredient(name, amount, type);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        /// <inheritdoc />
        public bool UpdateIngredientInPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId)
        {
            var query =
                "UPDATE PantryItems SET amount = @amount WHERE userId = @userId AND ingredientId = @ingredientId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@ingredientId", SqlDbType.Int).Value = (int)this.GetIngredientIdFor(ingredient.Name)!;
            command.Parameters.Add("@amount", SqlDbType.Int).Value = ingredient.Amount;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        /// <inheritdoc />
        public bool RemoveAllIngredientsFromPantry(int userId)
        {
            var query = "DELETE FROM PantryItems WHERE userId = @userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected >= 1;
        }

        /// <inheritdoc />
        public bool IsIngredientInSystem(string ingredientName)
        {
            var query = "SELECT COUNT(*) as 'count' FROM Ingredients WHERE name = @name";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = ingredientName;
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                int count = reader.GetInt32("count");
                return count == 1;
            }
            return false;
        }

        /// <inheritdoc />
        public bool IsIngredientInPantry(string ingredientName, int userId)
        {
            var query = "SELECT COUNT(*) as 'count' FROM Ingredients, PantryItems WHERE Ingredients.ingredientId = PantryItems.ingredientId AND PantryItems.userId = @userId AND Ingredients.name = @name";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = ingredientName;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32("count") == 1;
            }
            return false;
        }

        /// <inheritdoc />
        public bool RemoveIngredientFromPantry(Shared_Resources.Model.Ingredients.Ingredient ingredient, int userId)
        {
            var query =
                "DELETE FROM PantryItems WHERE userId = @userId AND ingredientId IN (SELECT ingredientId FROM Ingredients WHERE name = @name)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = ingredient.Name;
            connection.Open();

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        /// <inheritdoc />
        public int? GetIngredientIdFor(string ingredientName)
        {
            var query = "SELECT ingredientId FROM Ingredients WHERE name = @name";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = ingredientName;
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return reader.GetInt32("ingredientId");
            }
            return null;
        }
    }
}
