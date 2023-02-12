using Desktop_Client.Endpoints.Users;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterUserEndpoints()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new UsersEndpoints();
            });
        }

        [Test]
        public void ShouldNotAllowNullHttpClient()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new UsersEndpoints(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(UsersEndpointsErrorMessages.ClientCannotBeNull));
        }
    }
}
