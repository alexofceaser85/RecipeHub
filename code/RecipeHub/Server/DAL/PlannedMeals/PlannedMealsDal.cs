using System.Data;
using Microsoft.Data.SqlClient;
using Server.Data.Settings;
using Shared_Resources.Model.PlannedMeals;

namespace Server.DAL.PlannedMeals
{
    /// <summary>
    /// The data access layer for the planned meals
    /// </summary>
    public class PlannedMealsDal : IPlannedMealsDal
    {
        /// <summary>
        /// Adds the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was added</returns>
        public bool AddPlannedMeal(int userId, DateTime mealDate, MealCategory category, int recipeId)
        {
            const string query =
                "INSERT INTO PlannedMeals(mealDate, mealCategory, recipeId, userId) VALUES (@mealDate, @mealCategory, @recipeId, @userId)";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@mealDate", SqlDbType.DateTime).Value = mealDate;
            command.Parameters.Add("@mealCategory", SqlDbType.Int).Value = category;
            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        /// <summary>
        /// Gets the planned meal recipe ids.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <returns>The recipes for a planned meal</returns>
        public int[] GetPlannedMealRecipes(int userId, DateTime mealDate, MealCategory category)
        {
            const string query =
                "Select recipeId FROM PlannedMeals WHERE userId = @userId AND mealDate = @mealDate AND mealCategory = @mealCategory";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@mealDate", SqlDbType.Date).Value = mealDate;
            command.Parameters.Add("@mealCategory", SqlDbType.Int).Value = category;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();

            using var reader = command.ExecuteReader();
            var recipeIdOrdinal = reader.GetOrdinal("recipeId");

            var recipeIds = new List<int>();

            while (reader.Read())
            {
                recipeIds.Add(reader.GetInt32(recipeIdOrdinal));
            }

            return recipeIds.ToArray();
        }

        /// <summary>
        /// Gets all of the planned meal recipes for a user
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The recipes for a planned meal</returns>
        public int[] GetAllPlannedMealRecipes(int userId)
        {
            const string query =
                "Select recipeId FROM PlannedMeals WHERE userId = @userId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();

            using var reader = command.ExecuteReader();
            var recipeIdOrdinal = reader.GetOrdinal("recipeId");

            var recipeIds = new List<int>();

            while (reader.Read())
            {
                recipeIds.Add(reader.GetInt32(recipeIdOrdinal));
            }

            return recipeIds.ToArray();
        }

        /// <summary>
        /// Removes the planned meal.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>Whether or not the meal was removed</returns>
        public bool RemovePlannedMeal(int userId, DateTime mealDate, MealCategory category, int recipeId)
        {
            const string query =
                "DELETE FROM PlannedMeals WHERE userId = @userId AND mealDate = @mealDate AND mealCategory = @mealCategory AND recipeId = @recipeId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@mealDate", SqlDbType.DateTime).Value = mealDate;
            command.Parameters.Add("@mealCategory", SqlDbType.Int).Value = category;
            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected == 1;
        }

        /// <summary>
        /// Determines whether [is planned meal in system] [the specified user identifier].
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="mealDate">The meal date.</param>
        /// <param name="category">The category.</param>
        /// <param name="recipeId">The recipe identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is planned meal in system] [the specified user identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPlannedMealInSystem(int userId, DateTime mealDate, MealCategory category, int recipeId)
        {
            const string query =
                "Select recipeId FROM PlannedMeals WHERE userId = @userId AND mealDate = @mealDate AND mealCategory = @mealCategory AND recipeId = @recipeId";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@mealDate", SqlDbType.DateTime).Value = mealDate;
            command.Parameters.Add("@mealCategory", SqlDbType.Int).Value = category;
            command.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;
            command.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

            connection.Open();
            return command.ExecuteScalar() != null;
        }

        /// <summary>
        /// Removes the out of date meals.
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="mealDate">The meal date.</param>
        public void RemoveOutOfDateMeals(DateTime mealDate)
        {
            const string query =
                "DELETE FROM PlannedMeals WHERE mealDate < @mealDate";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@mealDate", SqlDbType.DateTime).Value = mealDate;

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
