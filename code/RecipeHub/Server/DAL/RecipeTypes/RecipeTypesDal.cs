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
        /// Gets the similar recipe types.
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="partialString">The partial string.</param>
        /// <returns>
        /// The similar recipe types
        /// </returns>
        public string[] GetSimilarRecipeTypes()
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
