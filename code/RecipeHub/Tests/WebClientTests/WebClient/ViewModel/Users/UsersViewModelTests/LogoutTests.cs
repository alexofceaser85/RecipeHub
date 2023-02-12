using Moq;
using Web_Client.Service.Users;
using Web_Client.ViewModel.Users;

namespace WebClientTests.WebClient.ViewModel.Users.UsersViewModelTests
{
    public class LogoutTests
    {
        [Test]
        public void ShouldLogout()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.Logout());

            viewModel.Logout();
            service.Verify(mock => mock.Logout(), Times.Once);
        }
    }
}
