using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace SharedResourcesTests.SharedResources.Model.Users
{
    public class UserInfoTests
    {
        [Test]
        public void ShouldNotCreateUserInfoWithNullUserName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo(null!, "firstname", "lastname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.UsernameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithEmptyUserName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("   ", "firstname", "lastname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.UsernameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithNullFirstName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", null!, "lastname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.FirstNameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithEmptyFirstName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", "   ", "lastname", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.FirstNameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithNullLastName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", "firstname", null!, "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.LastNameCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithEmptyLastName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", "firstname", "   ", "email@email.com");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.LastNameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithNullEmail()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", "firstname", "lastname", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.EmailCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateUserInfoWithEmptyEmail()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UserInfo("username", "firstname", "lastname", "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(UserInfoErrorMessages.EmailCannotBeEmpty));
        }

        [Test]
        public void ShouldCreateUserInfoWithValidInfo()
        {
            var user = new UserInfo("username", "firstname", "lastname", "email@email.com");
            Assert.That(user.UserName, Is.EqualTo("username"));
            Assert.That(user.FirstName, Is.EqualTo("firstname"));
            Assert.That(user.LastName, Is.EqualTo("lastname"));
            Assert.That(user.Email, Is.EqualTo("email@email.com"));
        }
    }
}
