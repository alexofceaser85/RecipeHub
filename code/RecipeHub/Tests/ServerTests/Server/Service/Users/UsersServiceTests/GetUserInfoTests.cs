using Moq;
using Server.DAL.Users;
using Server.Service.Users;
using Shared_Resources.Model.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class GetUserInfoTests
    {
        [Test]
        public void ShouldNotGetUserInfoIfSessionKeyIsNull()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.GetUserInfo(null!);
            });
        }

        [Test]
        public void ShouldNotGetUserInfoIfSessionKeyIsBlank()
        {
            var server = new UsersService();
            Assert.Throws<ArgumentException>(() =>
            {
                server.GetUserInfo("   ");
            });
        }

        [Test]
        public void ShouldReturnUserInfoIfServerRetrievedServerInfo()
        {
            var userInfo = new UserInfo("username", "firstname", "lastname", "username@gmail.com");

            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.GetUserInfo("Key")).Returns(userInfo);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.GetUserInfo("Key");

            userDal.Verify(mock => mock.GetUserInfo("Key"), Times.Once());
            Assert.That(returnedValue, Is.EqualTo(userInfo));
        }

        [Test]
        public void ShouldNotReturnUserInfoIfServerCouldNotRetrieveServerInfo()
        {
            var userDal = new Mock<IUsersDal>();

            userDal.Setup(mock => mock.GetUserInfo("Key")).Returns((UserInfo)null!);

            var service = new UsersService(userDal.Object);

            var returnedValue = service.GetUserInfo("Key");

            userDal.Verify(mock => mock.GetUserInfo("Key"), Times.Once());
            Assert.That(returnedValue, Is.EqualTo(null!));
        }
    }
}
