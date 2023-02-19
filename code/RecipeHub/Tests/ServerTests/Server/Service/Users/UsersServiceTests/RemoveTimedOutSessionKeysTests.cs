using Moq;
using Server.DAL.Users;
using Server.Service.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class RemoveTimedOutSessionKeysTests
    {
        [Test]
        public void ShouldRemoveTimedOutSessionKeys()
        {
            var dal = new Mock<IUsersDal>();
            var service = new UsersService(dal.Object);

            dal.Setup(mock => mock.RemoveTimedOutSessionKeys());

            service.RemoveTimedOutSessionKeys();
            
            dal.Verify(mock => mock.RemoveTimedOutSessionKeys(), Times.Once);
        }

    }
}
