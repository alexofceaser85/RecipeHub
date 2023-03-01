using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;
using Moq;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.UsersViewModelTests
{
    internal class CreateAccountTests
    {
        [Test]
        public void ShouldCreateAccount()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()));

            viewModel.CreateAccount("username", "password", "password", "first", "lname", "email@email.com");
            service.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once);
        }
    }
}