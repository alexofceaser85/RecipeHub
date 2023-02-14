using Shared_Resources.Data.Settings;
using Shared_Resources.ErrorMessages;

namespace Shared_Resources.Utils.Validation
{
    /// <summary>
    /// Validates the password
    /// </summary>
    public static class PasswordValidation
    {
        /// <summary>
        /// Validates the specified password to validate.
        ///
        /// Precondition:
        /// passwordToValidate != null
        /// AND passwordToValidate.Length MORE THAN MinimumPasswordLength
        /// AND passwordToValidate.Length LESS THAN MaximumPasswordLength
        /// Postcondition: None
        /// </summary>
        /// <param name="passwordToValidate">The password to validate.</param>
        /// <exception cref="ArgumentException">If the preconditions are not met</exception>
        public static void Validate(string passwordToValidate)
        {
            if (passwordToValidate == null)
            {
                throw new ArgumentException(NewAccountErrorMessages.PasswordCannotBeNull);
            }
            if (passwordToValidate.Length < PasswordSettings.MinimumPasswordLength)
            {
                throw new ArgumentException(PasswordValidationErrorMessages.PasswordIsTooShort);
            }
            if (passwordToValidate.Length > PasswordSettings.MaximumPasswordLength)
            {
                throw new ArgumentException(PasswordValidationErrorMessages.PasswordIsTooLong);
            }
        }
    }
}
