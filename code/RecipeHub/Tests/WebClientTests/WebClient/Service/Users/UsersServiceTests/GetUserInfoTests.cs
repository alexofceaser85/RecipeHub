using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;
using Web_Client.Endpoints.Users;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Users.UsersServiceTests
{
    public class GetUserInfoTests
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
        public void ShouldNotGetUserInfoIfSessionKeyIsNull()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetUserInfo();
            })?.Message;
            Assert.That(message, Is.EqualTo(SessionKeyErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotGetUserInfoIfSessionKeyIsEmpty()
        {
            Session.Key = "   ";
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetUserInfo();
            })?.Message;
            Assert.That(message, Is.EqualTo(SessionKeyErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void TestSuccessfulGetUserInfo()
        {
            Session.Key = "sessionkey";
            var mockedEndpoints = new Mock<IUsersEndpoints>();
            var expectedUserInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");

            mockedEndpoints.Setup(mock => mock.GetUserInfo(Session.Key)).Returns(expectedUserInfo);

            var service = new UsersService(mockedEndpoints.Object);

            var actualUserInfo = service.GetUserInfo();
            Assert.That(expectedUserInfo, Is.EqualTo(actualUserInfo));
        }

        [Test]
        public void TestUnsuccessfulGetUserInfo()
        {
            Session.Key = "sessionkey";
            var mockedEndpoints = new Mock<IUsersEndpoints>();

            mockedEndpoints.Setup(mock => mock.GetUserInfo(Session.Key)).Throws(new ArgumentException("testexception"));

            var service = new UsersService(mockedEndpoints.Object);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.GetUserInfo();
            })?.Message;

            Assert.That(message, Is.EqualTo("testexception"));
        }
    }
}
