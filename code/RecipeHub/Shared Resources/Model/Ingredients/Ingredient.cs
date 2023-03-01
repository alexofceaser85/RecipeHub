using System.Text.Json.Serialization;

namespace Shared_Resources.Model.Ingredients
{
    /// <summary>
    /// Represents an ingredient in the system.
    /// </summary>
    public struct Ingredient
    {
        /// <summary>
        /// Represents the name of the ingredient.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        /// Represents the amount of the ingredient.
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; }

        /// <summary>
        /// Represents how the ingredient is measured, in quantity, mass, or volume.
        /// </summary>
        [JsonPropertyName("measurementType")]
        public MeasurementType MeasurementType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient"/> struct.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="measurementType">Type of the measurement.</param>
        public Ingredient(string name, int amount, MeasurementType measurementType)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), amount, @"Amount cannot be less than 0.");
            }

            this.Name = name;
            this.Amount = amount;
            this.MeasurementType = measurementType;
        }
    }
}