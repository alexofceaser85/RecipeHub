using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Components;
using Moq;

namespace DesktopClientTests.DesktopClient.ViewModel.Components.LoginFormViewModelTests
{
    public class LoginTests
    {
        [Test]
        public void ValidLogin()
        {
            const string username = "username";
            const string password = "password";

            var service = new Mock<IUsersService>();
            service.Setup(mock => mock.Login(username, password));

            var viewmodel = new LoginFormViewModel(service.Object)
            {
                Username = username,
                Password = password
            };

            Assert.Multiple(() =>
            {
                Assert.DoesNotThrow(() => viewmodel.Login());
            });
        }
    }
}
