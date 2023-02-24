using System.Data;
using Microsoft.Data.SqlClient;
using Server.Data.Settings;

namespace Server.DAL.RecipeTypes
{
    /// <summary>
    /// The data access layer for the recipe types
    /// </summary>
    public class RecipeTypesDal : IRecipeTypesDal
    {
        /// <summary>
        /// Gets the recipe identifier for type identifier.
        /// </summary>
        /// <param name="typeIds">The type identifier.</param>
        /// <returns>
        /// The recipe id
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int[] GetRecipeIdsForTypeIds(int[] typeIds)
        {
            string typeIdsList = string.Join(",", typeIds);
            var query = $"SELECT recipeId FROM RecipeTypes WHERE typeId IN ({typeIdsList}) GROUP BY recipeId HAVING COUNT(DISTINCT typeId) = @typeIdLength;";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@typeIdLength", SqlDbType.Int).Value = typeIds.Length;
            connection.Open();
            using var reader = command.ExecuteReader();
            var typeOrdinal = reader.GetOrdinal("recipeId");
            var recipeIds = new List<int>();

            while (reader.Read())
            {
                recipeIds.Add(reader.GetInt32(typeOrdinal));
            }

            return recipeIds.ToArray();
        }

        /// <summary>
        /// Gets the name of the type identifier.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>
        /// The name of the type
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int? GetTypeIdForTypeName(string typeName)
        {
            var query = "select typeId from Type where typeName = @typeName";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add("@typeName", SqlDbType.VarChar).Value = typeName;
            connection.Open();
            using var reader = command.ExecuteReader();
            var typeOrdinal = reader.GetOrdinal("typeId");

            while (reader.Read())
            {
                return reader.GetInt32(typeOrdinal);
            }

            return null;
        }

        /// <summary>
        /// Gets the similar recipe types.
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="partialString">The partial string.</param>
        /// <returns>
        /// The similar recipe types
        /// </returns>
        public string[] GetAllRecipeTypes()
        {
            var query = "select typeName from Type";
            using var connection = new SqlConnection(DatabaseSettings.ConnectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();
            using var reader = command.ExecuteReader();
            var typeOrdinal = reader.GetOrdinal("typeName");
            var types = new List<string>();

            while (reader.Read())
            {
                types.Add(reader.GetString(typeOrdinal));
            }

            return types.ToArray();
        }
    }
}
