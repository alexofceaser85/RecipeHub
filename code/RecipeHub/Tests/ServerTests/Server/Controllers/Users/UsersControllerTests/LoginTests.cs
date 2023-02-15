using Moq;
using Server.Controllers.Users;
using System.Net;
using Server.Service.Users;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class LoginTests
    {
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
    }
}
