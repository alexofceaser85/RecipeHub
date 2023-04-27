using System.Text.Json.Serialization;
using Shared_Resources.Model.Recipes;

namespace Shared_Resources.Model.PlannedMeals
{
    /// <summary>
    /// Stores a meal id and a recipe associated with it.
    /// </summary>
    public struct PlannedRecipe
    {
        /// <summary>
        /// The recipe
        /// </summary>
        [JsonPropertyName("recipe")]
        public Recipe Recipe { get; set; }

        /// <summary>
        /// The id for the meal
        /// </summary>
        [JsonPropertyName("mealId")]
        public int MealId { get; set; }
    }
}
