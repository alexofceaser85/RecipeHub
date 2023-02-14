using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Validation;

namespace SharedResourcesTests.SharedResources.Utils.Validation.PasswordValidationTests
{
    public class ValidateTests
    {
        [Test]
        public void ShouldNotValidateNullPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                PasswordValidation.Validate(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotValidateEmptyPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                PasswordValidation.Validate("");
            })?.Message;
            Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooShort));
        }

        [Test]
        public void ShouldNotValidatePasswordOneBelowMinimum()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                PasswordValidation.Validate("12345");
            })?.Message;
            Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooShort));
        }

        [Test]
        public void ShouldValidatePasswordAtMinimum()
        {
            Assert.DoesNotThrow(() =>
            {
                PasswordValidation.Validate("123456");
            });
        }

        [Test]
        public void ShouldValidatePasswordOneAboveMinimum()
        {
            Assert.DoesNotThrow(() =>
            {
                PasswordValidation.Validate("1234567");
            });
        }

        [Test]
        public void ShouldValidatePasswordWellBetweenMinimumAndMaximum()
        {
            Assert.DoesNotThrow(() =>
            {
                PasswordValidation.Validate("12345678910");
            });
        }

        [Test]
        public void ShouldValidatePasswordOneBelowMaximum()
        {
            Assert.DoesNotThrow(() =>
            {
                PasswordValidation.Validate("1234567891234567891");
            });
        }

        [Test]
        public void ShouldValidatePasswordAtMaximum()
        {
            Assert.DoesNotThrow(() =>
            {
                PasswordValidation.Validate("12345678912345678912");
            });
        }

        [Test]
        public void ShouldValidatePasswordOneAboveMaximum()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                PasswordValidation.Validate("123456789123456789123");
            })?.Message;
            Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooLong));
        }

        [Test]
        public void ShouldValidatePasswordWellAboveMaximum()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                PasswordValidation.Validate("123456789123456789123456789");
            })?.Message;
            Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooLong));
        }
    }
}
