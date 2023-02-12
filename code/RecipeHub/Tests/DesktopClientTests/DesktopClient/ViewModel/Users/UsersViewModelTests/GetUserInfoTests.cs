using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;
using Moq;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.UsersViewModelTests
{
    public class GetUserInfoTests
    {
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
