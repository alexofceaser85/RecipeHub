using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Validation;

namespace ServerTests.Utils.Validation.PasswordValidationTests
{
    public class ValidateTests
    {
        [Test]
        public void ValidPassword()
        {
            Assert.DoesNotThrow(() => PasswordValidation.Validate("password"));
        }

        [Test]
        public void NullPassword()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => PasswordValidation.Validate(null!))!.Message;
                Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeNull));
            });
        }

        [Test]
        public void PasswordTooShort()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => PasswordValidation.Validate("short"))!.Message;
                Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooShort));
            });
        }

        [Test]
        public void PasswordTooLong()
        {
            Assert.Multiple(() =>
            {
                var message =
                    Assert.Throws<ArgumentException>(() => PasswordValidation.Validate("123456789012345678901"))!
                          .Message;
                Assert.That(message, Is.EqualTo(PasswordValidationErrorMessages.PasswordIsTooLong));
            });
        }
    }
}