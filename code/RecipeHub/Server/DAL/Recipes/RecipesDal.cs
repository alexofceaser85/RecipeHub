using System.Data;
using Microsoft.Data.SqlClient;
using Server.Data.Settings;
using Shared_Resources.Model.Recipes;

namespace Server.DAL.Recipes
{
    /// <summary>
    /// Contains methods for interfacing with the Recipes table
    /// </summary>
    public class RecipeDal : IRecipesDal
    {
        /// <inheritdoc/>
        public bool RecipeWithIdExists(int recipeId)
        {
            var query = "SELECT recipeId FROM Recipes WHERE recipeId = @recipeId;";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool IsAuthorOfRecipe(int authorId, int recipeId)
        {
            var query = "SELECT authorId FROM Recipes WHERE recipeId = @recipeId AND authorId = @authorId;";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            command.Parameters.Add("@authorId", SqlDbType.Int).Value = authorId;
            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipes(int userId)
        {
            return this.GetRecipesWithName(userId, "");
        }

        /// <inheritdoc/>
        public Recipe[] GetRecipesWithName(int userId, string nameFilter)
        {
            var recipes = new List<Recipe>();
            var query = "SELECT Recipes.recipeId, CONCAT(TRIM(Users.firstName), ' ', TRIM(Users.lastName)) AS authorName, TRIM(Recipes.name) AS name, " +
                        "TRIM(Recipes.description) AS description, Recipes.isPublic FROM Recipes, Users WHERE Recipes.authorId = Users.userId " +
                        "AND name LIKE @nameFilter AND (Recipes.authorId = @userId OR Recipes.isPublic = 1);";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@nameFilter", SqlDbType.Char).Value = $"%{nameFilter}%";
            connection.Open();

            using var reader = command.ExecuteReader();
            var recipeIdOrdinal = reader.GetOrdinal("recipeId");
            var authorNameOrdinal = reader.GetOrdinal("authorName");
            var nameOrdinal = reader.GetOrdinal("name");
            var descriptionOrdinal = reader.GetOrdinal("description");
            var isPublicOrdinal = reader.GetOrdinal("isPublic");

            while (reader.Read())
            {
                var recipeId = reader.GetInt32(recipeIdOrdinal);
                var authorName = reader.GetString(authorNameOrdinal);
                var name = reader.GetString(nameOrdinal);
                var description = reader.GetString(descriptionOrdinal);
                var isPublic = reader.GetByte(isPublicOrdinal) == 1;
                recipes.Add(new Recipe(recipeId, authorName, name, description, isPublic));
            }

            //TODO Get the ingredients for a recipe
            for (var i = 0; i < recipes.Count; i++)
            {
                recipes[i].Ingredients = new List<Ingredient>();
            }

            return recipes.ToArray();
        }

        /// <inheritdoc/>
        public bool AddRecipe(int authorId, string name, string description, bool isPublic)
        {
            var query = "INSERT INTO Recipes (authorId, name, description, isPublic) VALUES (@authorId, @name, @description, @isPublic);";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@authorId", SqlDbType.Int).Value = authorId;
            command.Parameters.Add("@name", SqlDbType.Char).Value = name;
            command.Parameters.Add("@description", SqlDbType.Char).Value = description;
            command.Parameters.Add("@isPublic", SqlDbType.TinyInt).Value = isPublic;
            connection.Open();

            var rowsAffected = command.ExecuteNonQuery();
            
            return rowsAffected == 1;
        }

        /// <inheritdoc/>
        public bool RemoveRecipe(int recipeId)
        {
            var query = "DELETE FROM Recipes WHERE recipeId = @recipeId";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            connection.Open();

            var rowsAffected = command.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        /// <inheritdoc/>
        public bool EditRecipe(int recipeId, string name, string description, bool isPublic)
        {
            var query = "UPDATE Recipes SET name = @name, description = @description, isPublic = @isPublic " +
                        "WHERE recipeId = @recipeId;";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            command.Parameters.Add("@name", SqlDbType.Char).Value = name;
            command.Parameters.Add("@description", SqlDbType.Char).Value = description;
            command.Parameters.Add("@isPublic", SqlDbType.TinyInt).Value = isPublic;
            connection.Open();

            var rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        /// <inheritdoc/>
        public Ingredient[] GetIngredientsForRecipe(int recipeId)
        {
            var ingredients = new List<Ingredient>();
            var query = "SELECT RecipeIngredients.ingredientId, Ingredients.name, RecipeIngredients.amount " +
                        "FROM RecipeIngredients, Ingredients WHERE RecipeIngredients.ingredientId = Ingredients.ingredientId AND recipeId = @recipeId";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            connection.Open();

            using var reader = command.ExecuteReader();
            var ingredientIdOrdinal = reader.GetOrdinal("ingredientId");
            var nameOrdinal = reader.GetOrdinal("name");
            var amountOrdinal = reader.GetOrdinal("amount");

            while (reader.Read())
            {
                var ingredientId = reader.GetInt32(ingredientIdOrdinal);
                var name = reader.GetString(nameOrdinal);
                var amount = reader.GetInt32(amountOrdinal);
                ingredients.Add(new Ingredient()
                {
                    Id = ingredientId,
                    Name = name,
                    Amount = amount,
                });
            }

            return ingredients.ToArray();
        }

        /// <inheritdoc/>
        public RecipeStep[] GetStepsForRecipe(int recipeId)
        {
            var steps = new List<RecipeStep>();
            var query = "SELECT stepNumber, stepName, instructions FROM RecipeSteps WHERE recipeId = @recipeId";

            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            connection.Open();

            using var reader = command.ExecuteReader();
            var stepNumberOrdinal = reader.GetOrdinal("stepNumber");
            var stepNameOrdinal = reader.GetOrdinal("stepName");
            var instructionsOrdinal = reader.GetOrdinal("instructions");

            while (reader.Read())
            {
                var stepNumber = reader.GetInt32(stepNumberOrdinal);
                var name = reader.GetString(stepNameOrdinal);
                var instructions = reader.GetString(instructionsOrdinal);
                steps.Add(new RecipeStep()
                {
                    Number = stepNumber,
                    Name = name,
                    Instructions = instructions,
                });
            }

            return steps.ToArray();
        }
    }
}
