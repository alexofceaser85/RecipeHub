using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop_Client.Service.Users;
using Desktop_Client.ViewModel.Users;

namespace DesktopClientTests.DesktopClient.ViewModel.Users.UsersViewModelTests
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
