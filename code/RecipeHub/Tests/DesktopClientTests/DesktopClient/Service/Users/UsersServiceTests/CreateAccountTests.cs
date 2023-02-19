using Desktop_Client.Endpoints.Users;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.Service.Users.UsersServiceTests
{
    public class CreateAccountTests
    {
        [Test]
        public void ShouldNotCreateAccountWithNullNewAccount()
        {
            var service = new UsersService();
            var message = Assert.Throws<ArgumentException>(() => { service.CreateAccount(null!); })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.AccountToCreateCannotBeNull));
        }

        [Test]
        public void ShouldCreateAccount()
        {
            var endpoints = new Mock<IUsersEndpoints>();
            var service = new UsersService(endpoints.Object);
            var account = new NewAccount("username", "password", "password", "first", "lname", "email@email.com");
            endpoints.Setup(mock => mock.CreateAccount(account));

            service.CreateAccount(account);
            endpoints.Verify(mock => mock.CreateAccount(account), Times.Once);
        }
    }
}