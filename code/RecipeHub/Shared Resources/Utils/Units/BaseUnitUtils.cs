using Shared_Resources.Model.Ingredients;

namespace Shared_Resources.Utils.Units
{
    /// <summary>
    /// Contains a series of methods useful for the base unit types of measurement.
    /// </summary>
    public static class BaseUnitUtils
    {
        /// <summary>
        /// Gets the base unit sign associated with the measurement type.<br />
        /// <br />
        /// Precondition: None<br />
        /// Postcondition: None<br />
        /// </summary>
        /// <param name="type">The measurement type.</param>
        /// <returns>the base unit sign associated with the measurement type.</returns>
        public static string GetBaseUnitSign(MeasurementType type)
        {
            switch (type)
            {
                case MeasurementType.Mass:
                    return "g";
                case MeasurementType.Volume:
                    return "ml";
                case MeasurementType.Quantity:
                    return "";
                default:
                    return "";
            }
        }
    }
}