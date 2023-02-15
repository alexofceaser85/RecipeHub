using Moq;
using Server.Controllers.Users;
using System.Net;
using Server.Data.Settings;
using Server.Service.Users;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class GetUserInfoTests
    {
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
