using Moq;
using Server.Controllers.Users;
using System.Net;
using Server.Data.Settings;
using Server.Service.Users;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class LogoutTests
    {
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
    }
}
