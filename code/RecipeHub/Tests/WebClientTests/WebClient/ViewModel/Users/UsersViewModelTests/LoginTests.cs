using Moq;
using Web_Client.Service.Users;
using Web_Client.ViewModel.Users;

namespace WebClientTests.WebClient.ViewModel.Users.UsersViewModelTests
{
    public class LoginTests
    {
        [Test]
        public void ShouldLogin()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.Login("username", "password"));

            viewModel.Login("username", "password");
            service.Verify(mock => mock.Login("username", "password"), Times.Once);
        }
    }
}
