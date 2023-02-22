using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;
using Moq;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.RegistrationScreenViewModelTests
{
    public class CreateAccountTests
    {
        [Test]
        public void CreateValidAccount()
        {
            var service = new Mock<IUsersService>();
            service.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()));

            var viewmodel = new RegistrationScreenViewModel(service.Object) {
                Username = "username",
                Password = "password",
                VerifyPassword = "password",
                FirstName = "first",
                LastName = "last",
                Email = "email@domain.com"
            };

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.CreateAccount());
                service.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once);
            });
        }
    }
}
