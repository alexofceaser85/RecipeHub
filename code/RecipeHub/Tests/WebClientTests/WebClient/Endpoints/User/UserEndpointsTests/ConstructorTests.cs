using Shared_Resources.ErrorMessages;
using Web_Client.Endpoints.Users;

namespace WebClientTests.WebClient.Endpoints.User.UserEndpointsTests
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
