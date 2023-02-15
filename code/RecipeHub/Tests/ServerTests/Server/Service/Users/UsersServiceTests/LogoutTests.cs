using Moq;
using Server.DAL.Users;
using Server.Service.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class LogoutTests
    {
        [Test]
        public void ShouldNotLogoutIfSessionKeyIsNull()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.Logout(null!);
            });
        }

        [Test]
        public void ShouldNotLogoutIfSessionKeyIsBlank()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.Logout("   ");
            });
        }

        [Test]
        public void ShouldLogoutWithValidSessionKey()
        {
            var userDal = new Mock<IUsersDal>();
            var service = new UsersService(userDal.Object);
            service.Logout("Key");
            userDal.Verify(mock => mock.RemoveSessionKey("Key"), Times.Once());
        }
    }
}
