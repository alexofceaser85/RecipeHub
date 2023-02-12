using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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
        public string Name { get; }

        /// <summary>
        /// Represents the amount of the ingredient.
        /// </summary>
        public int Amount { get; }
        /// <summary>
        /// Represents how the ingredient is measured, in quantity, mass, or volume.
        /// </summary>
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
                throw new ArgumentOutOfRangeException("Amount cannot be less than zero.");
            }
            this.Name = name;
            this.Amount = amount;
            this.MeasurementType = measurementType;
        }
    }
}
