using Moq;
using Shared_Resources.Data.IO;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;
using Web_Client.Endpoints.Users;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Users
{
    public class UsersServiceTests
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
        public void ShouldNotLoginWithNullUsername()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login(null!, "password");
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptyUsername()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("   ", "password");
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsernameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithNullPassword()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptyPassword()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.PasswordCannotBeEmpty));
        }

        [Test]
        public void ShouldNotLoginWithNullSessionKeyLoadFilePath()
        {
            var service = new UsersService();
            service.SessionKeyLoadFile = null!;
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", "password");
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeNull));
        }

        [Test]
        public void ShouldNotLoginWithEmptySessionKeyLoadFilePath()
        {
            var service = new UsersService();
            service.SessionKeyLoadFile = "  ";
            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", "password");
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.SessionKeyLoadFileCannotBeEmpty));
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            var mockedEndpoints = new Mock<IUsersEndpoints>();
            const string previousSessionKey = "prevsession";
            const string hashedPassword =
                "64fcc6f6bc7a815041b4db51f00f4bea8e51c13b27f422da0a8522c94641c7e483c3f17b28d0a59add0c8a44a4e4fc1dd3a9ea48bad8cf5b707ac0f44a5f3536";

            SessionKeySerializers.SaveSessionKey(previousSessionKey, "./logintest.txt");
            mockedEndpoints.Setup(mock => mock.Login("username", hashedPassword, previousSessionKey)).Returns("newsessionkey");

            var service = new UsersService(mockedEndpoints.Object);
            service.SessionKeyLoadFile = "./logintest.txt";

            service.Login("username", "000000");
            Assert.That(Session.Key, Is.EqualTo("newsessionkey"));
        }

        [Test]
        public void TestUnsuccessfulLogin()
        {
            var mockedEndpoints = new Mock<IUsersEndpoints>();
            const string previousSessionKey = "prevsession";
            const string hashedPassword =
                "64fcc6f6bc7a815041b4db51f00f4bea8e51c13b27f422da0a8522c94641c7e483c3f17b28d0a59add0c8a44a4e4fc1dd3a9ea48bad8cf5b707ac0f44a5f3536";

            SessionKeySerializers.SaveSessionKey(previousSessionKey, "logintest.txt");
            mockedEndpoints.Setup(mock => mock.Login("username", hashedPassword, previousSessionKey))
                .Throws(new ArgumentException("testexception"));

            var service = new UsersService(mockedEndpoints.Object);
            service.SessionKeyLoadFile = "logintest.txt";

            var message = Assert.Throws<ArgumentException>(() =>
            {
                service.Login("username", "000000");
            })?.Message;
            Assert.That(message, Is.EqualTo("testexception"));
            Assert.That(Session.Key, Is.Null);
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
