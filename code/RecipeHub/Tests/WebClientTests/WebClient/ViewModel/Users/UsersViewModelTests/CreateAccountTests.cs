using Moq;
using Shared_Resources.Model.Users;
using Web_Client.Service.Users;
using Web_Client.ViewModel.Users;

namespace WebClientTests.WebClient.ViewModel.Users.UsersViewModelTests
{
    internal class CreateAccountTests
    {
        [Test]
        public void ShouldCreateAccount()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.CreateAccount(It.IsAny<NewAccount>()));

            viewModel.CreateAccount("username", "password", "password", "fname", "lname", "email@email.com");
            service.Verify(mock => mock.CreateAccount(It.IsAny<NewAccount>()), Times.Once);
        }
    }
}
