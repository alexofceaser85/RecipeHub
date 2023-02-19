using Moq;
using Server.Controllers.Users;
using System.Net;
using Server.Service.Users;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class CreateAccountTests
    {
        [Test]
        public void TestSuccessfulCreateAccount()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()));
            var service = new UsersController(userService.Object);

            var returnedValue =
                service.CreateAccount("username", "password", "password", "first", "lname", "email@email.com");

            userService.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(returnedValue.Message, Is.Not.Empty);
        }

        [Test]
        public void TestUnsuccessfulCreateAccount()
        {
            var userService = new Mock<IUsersService>();

            userService.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()))
                       .Throws(new ArgumentException("Sample Exception"));
            var service = new UsersController(userService.Object);

            var returnedValue =
                service.CreateAccount("username", "password", "password", "first", "lname", "email@email.com");

            userService.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once());
            Assert.That(returnedValue.Code, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(returnedValue.Message, Is.EqualTo("Sample Exception"));
        }
    }
}