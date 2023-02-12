using Server.Controllers.Users;
using Shared_Resources.ErrorMessages;

namespace ServerTests.Server.Controllers.Users.UsersControllerTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterUsersController()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new UsersController();
            });
        }

        [Test]
        public void ShouldNotAllowNullUsersService()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersController(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersControllerErrorMessages.UsersServiceCannotBeNull));
        }
    }
}
