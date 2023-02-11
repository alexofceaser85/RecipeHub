using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;
using Moq;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users
{
    public class UsersViewModelTests
    {
        [Test]
        public void ShouldCreateZeroParameterUsersViewModel()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new UsersViewModel();
            });
        }

        [Test]
        public void ShouldNotAllowNullServer()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersViewModel(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceViewModelErrorMessages.UsersServiceCannotBeNull));
        }

        [Test]
        public void ShouldLogin()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.Login("username", "password"));

            viewModel.Login("username", "password");
            service.Verify(mock => mock.Login("username", "password"), Times.Once);
        }

        [Test]
        public void ShouldLogout()
        {
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.Logout());

            viewModel.Logout();
            service.Verify(mock => mock.Logout(), Times.Once);
        }

        [Test]
        public void ShouldGetUserInfo()
        {
            var expectedUserInfo = new UserInfo("username", "firstname", "lastname", "email@email.com");
            var service = new Mock<IUsersService>();
            var viewModel = new UsersViewModel(service.Object);
            service.Setup(mock => mock.GetUserInfo()).Returns(expectedUserInfo);

            var actualUserInfo = viewModel.GetUserInfo();
            service.Verify(mock => mock.GetUserInfo(), Times.Once);
            Assert.That(actualUserInfo, Is.EqualTo(expectedUserInfo));
        }
    }
}
