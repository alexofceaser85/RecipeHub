using Shared_Resources.ErrorMessages;
using Web_Client.Service.Users;

namespace WebClientTests.WebClient.Service.Users.UsersServiceTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotAllowNullUsersEndpoints()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersService(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UsersEndpointsCannotBeNull));
        }
    }
}
