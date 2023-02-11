using System.Net;
using Moq;
using Server.Controllers.Users;
using Server.Data.Settings;
using Server.Service.Users;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Controllers.Users
{
    public class UsersControllersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldCreateZeroParameterUsersController()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new UsersController();
            });
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.Login("username", "password", "key")).Returns("loginMessage");
            var service = new UsersController(userService.Object);

            var returnedValue = service.Login("username", "password", "key");

            userService.Verify(mock => mock.Login("username", "password", "key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(returnedValue.Message, Is.Not.Empty);
        }

        [Test]
        public void TestUnsuccessfulLogin()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.Login("username", "password", "key")).Throws(new ArgumentException("Sample Exception"));
            var service = new UsersController(userService.Object);

            var returnedValue = service.Login("username", "password", "key");

            userService.Verify(mock => mock.Login("username", "password", "key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(returnedValue.Message, Is.EqualTo("Sample Exception"));
        }

        [Test]
        public void TestSuccessfulLogout()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.Logout("key"));
            var service = new UsersController(userService.Object);

            var returnedValue = service.Logout("key");

            userService.Verify(mock => mock.Logout("key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(returnedValue.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
        }

        [Test]
        public void TestUnsuccessfulLogout()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.Logout("key")).Throws(new ArgumentException("Sample message"));
            var service = new UsersController(userService.Object);

            var returnedValue = service.Logout("key");

            userService.Verify(mock => mock.Logout("key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(returnedValue.Message, Is.EqualTo("Sample message"));
        }

        [Test]
        public void TestSuccessfulGetUserInfo()
        {
            var userService = new Mock<IUsersService>();
            var userInfo = new UserInfo("username", "firstname", "lastname", "username@gmail.com");

            userService.Setup(mock => mock.GetUserInfo("key")).Returns(userInfo);
            var service = new UsersController(userService.Object);

            var returnedValue = service.GetUserInfo("key");

            userService.Verify(mock => mock.GetUserInfo("key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(returnedValue.Message, Is.EqualTo(ServerSettings.DefaultSuccessfulConnectionMessage));
            Assert.That(returnedValue.UserInfo, Is.EqualTo(userInfo));
        }

        [Test]
        public void TestUnsuccessfulGetUserInfo()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.GetUserInfo("key")).Throws(new ArgumentException("Sample message"));
            var service = new UsersController(userService.Object);

            var returnedValue = service.GetUserInfo("key");

            userService.Verify(mock => mock.GetUserInfo("key"), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(returnedValue.Message, Is.EqualTo("Sample message"));
        }
    }
}
