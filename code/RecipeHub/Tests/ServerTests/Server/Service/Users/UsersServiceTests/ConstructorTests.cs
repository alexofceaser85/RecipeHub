using Server.ErrorMessages;
using Server.Service.Users;

namespace ServerTests.Server.Service.Users.UsersServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotAllowNullDataAccessLayer()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersService(null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ServerUsersServiceErrorMessages.DataAccessLayerCannotBeNull));
        }
    }
}
