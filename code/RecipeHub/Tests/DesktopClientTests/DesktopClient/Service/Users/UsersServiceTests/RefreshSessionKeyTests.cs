using Desktop_Client.Endpoints.Users;
using Desktop_Client.Service.Users;
using Moq;
using Shared_Resources.Data.UserData;

namespace DesktopClientTests.DesktopClient.Service.Users.UsersServiceTests
{
    public class RefreshSessionKeyTests
    {
        [Test]
        public void ShouldRefreshSessionKey()
        {
            Session.Key = "prevKey";
            var endpoints = new Mock<IUsersEndpoints>();
            endpoints.Setup(mock => mock.RefreshSessionKey("prevKey")).Returns("newKey");

            var service = new UsersService(endpoints.Object);

            service.RefreshSessionKey();

            Assert.That(Session.Key, Is.EqualTo("newKey"));
        }
    }
}
