using Moq;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class TestRefreshSessionKey
    {
        [Test]
        public void ShouldNotRefreshNullPreviousSessionKey()
        {
            var service = new UsersService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RefreshSessionKey(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.PreviousSessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotRefreshEmptyPreviousSessionKey()
        {
            var service = new UsersService();
            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RefreshSessionKey("   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.PreviousSessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotRefreshExpiredSessionKey()
        {
            var previousSessionKey = "Key";
            var dal = new Mock<IUsersDal>();
            var service = new UsersService(dal.Object);

            dal.Setup(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>())).Returns(true);
            dal.Setup(mock => mock.GetIdForSessionKey(previousSessionKey)).Returns((int?)null);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                service.RefreshSessionKey(previousSessionKey);
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.SessionKeyCannotBeExpired));
        }

        [Test]
        public void ShouldRefreshValidSessionKey()
        {
            var previousSessionKey = "Key";
            var dal = new Mock<IUsersDal>();
            var service = new UsersService(dal.Object);

            dal.Setup(mock => mock.VerifySessionKeyDoesNotExist(It.IsAny<string>())).Returns(true);
            dal.Setup(mock => mock.GetIdForSessionKey(previousSessionKey)).Returns(1);
            dal.Setup(mock => mock.RemoveSessionKey(previousSessionKey));
            dal.Setup(mock => mock.AddUserSession(1, It.IsAny<string>(), It.IsAny<DateTime>()));

            var newSessionKey = service.RefreshSessionKey(previousSessionKey);

            dal.Verify(mock => mock.GetIdForSessionKey(previousSessionKey), Times.Once);
            dal.Verify(mock => mock.RemoveSessionKey(previousSessionKey), Times.Once);
            dal.Verify(mock => mock.AddUserSession(1, It.IsAny<string>(), It.IsAny<DateTime>()), Times.Once);
            Assert.That(newSessionKey, Is.Not.EqualTo(previousSessionKey));
        }
    }
}
