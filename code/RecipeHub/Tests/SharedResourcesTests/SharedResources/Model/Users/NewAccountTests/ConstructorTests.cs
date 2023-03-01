using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace SharedResourcesTests.SharedResources.Model.Users.NewAccountTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateNewAccountWithNullUsername()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount(null!, "000000", "000000", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.UsernameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyUsername()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("   ", "000000", "000000", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.UsernameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithNullPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", null!, "000000", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "   ", "000000", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullPassword()
        {
            var account = new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com");

            var message = Assert.Throws<ArgumentException>(() => { account.Password = null!; })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyPassword()
        {
            var account = new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com");

            var message = Assert.Throws<ArgumentException>(() => { account.Password = "   "; })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.PasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullVerifyPassword()
        {
            var account = new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com");

            var message = Assert.Throws<ArgumentException>(() => { account.VerifyPassword = null!; })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.VerifiedPasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyVerifyPassword()
        {
            var account = new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com");

            var message = Assert.Throws<ArgumentException>(() => { account.VerifyPassword = "   "; })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.VerifiedPasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithNullVerifyPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", null!, "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.VerifiedPasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyVerifyPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "      ", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.VerifiedPasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithPasswordNotEqualToVerifyPassword()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "111111", "first", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.VerifiedPasswordMustMatchPassword));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithNullFirstName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", null!, "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.FirstNameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyFirstName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "   ", "lname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.FirstNameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithNullLastName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "first", null!, "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.LastNameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyLastName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "first", "   ", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.LastNameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithNullEmail()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "first", "lname", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.EmailCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmptyEmail()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "first", "lname", "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.EmailCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateNewAccountWithEmailInWrongFormat()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new NewAccount("username", "000000", "000000", "first", "lname", "wrongFormatEmail.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(NewAccountErrorMessages.EmailIsInWrongFormat));
        }

        [Test]
        public void ShouldCreateNewAccountWithValidInfo()
        {
            var account = new NewAccount("username", "000000", "000000", "first", "lname", "email@email.com");

            Assert.That(account.Username, Is.EqualTo("username"));
            Assert.That(account.Password, Is.EqualTo("000000"));
            Assert.That(account.VerifyPassword, Is.EqualTo("000000"));
            Assert.That(account.FirstName, Is.EqualTo("first"));
            Assert.That(account.LastName, Is.EqualTo("lname"));
            Assert.That(account.Email, Is.EqualTo("email@email.com"));
        }
    }
}