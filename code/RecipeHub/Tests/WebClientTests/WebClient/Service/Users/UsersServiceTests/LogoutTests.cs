using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Web_Client.Endpoints.Users;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Users.UsersServiceTests
{
    public class LogoutTests
    {
        [SetUp]
        public void Setup()
        {
            Session.Key = null;
        }

        [TearDown]
        public void TearDown()
        {
            Session.Key = null;
        }

        [Test]
        public void ShouldNotLogoutIfSessionKeyIsNull()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Logout();
            })?.Message;
            Assert.That(message, Is.EqualTo(SessionKeyErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotLogoutIfSessionKeyIsEmpty()
        {
            Session.Key = "   ";
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Logout();
            })?.Message;
            Assert.That(message, Is.EqualTo(SessionKeyErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void TestSuccessfulLogout()
        {
            Session.Key = "sessionkey";
            var mockedEndpoints = new Mock<IUsersEndpoints>();

            mockedEndpoints.Setup(mock => mock.Logout(Session.Key)).Returns("newsessionkey");

            var service = new UsersService(mockedEndpoints.Object);

            service.Logout();
            Assert.That(Session.Key, Is.Null);
        }

        [Test]
        public void TestUnsuccessfulLogout()
        {
            Session.Key = "sessionkey";
            var mockedEndpoints = new Mock<IUsersEndpoints>();

            mockedEndpoints.Setup(mock => mock.Logout(Session.Key)).Throws(new ArgumentException("testexception"));

            var service = new UsersService(mockedEndpoints.Object);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Logout();
            })?.Message;

            Assert.That(message, Is.EqualTo("testexception"));
            Assert.That(Session.Key, Is.EqualTo("sessionkey"));
        }
    }
}
