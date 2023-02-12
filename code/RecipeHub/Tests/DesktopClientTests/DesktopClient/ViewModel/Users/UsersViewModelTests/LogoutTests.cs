using Moq;
using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.UsersViewModelTests
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
