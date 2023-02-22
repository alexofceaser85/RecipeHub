using System.Net;
using Moq;
using Server.Controllers.Users;
using Server.Service.Users;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class RefreshSessionKeyTests
    {
        [Test]
        public void ShouldSuccessfullyRefreshSessionKey()
        {
            var service = new Mock<IUsersService>();
            service.Setup(mock => mock.RefreshSessionKey("Key")).Returns("newSessionKey");

            var controller = new UsersController(service.Object);

            var response = controller.RefreshSessionKey("Key");

            service.Verify(mock => mock.RefreshSessionKey("Key"), Times.Once);
            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Message, Is.EqualTo("newSessionKey"));
        }

        [Test]
        public void ShouldNotRefreshKeyIfServiceThrowsError()
        {
            var service = new Mock<IUsersService>();
            service.Setup(mock => mock.RefreshSessionKey("Key"))
                .Throws(() => new UnauthorizedAccessException("exception"));

            var controller = new UsersController(service.Object);

            var response = controller.RefreshSessionKey("Key");

            service.Verify(mock => mock.RefreshSessionKey("Key"), Times.Once);
            Assert.That(response.Code, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Message, Is.EqualTo("exception"));
        }
    }
}
