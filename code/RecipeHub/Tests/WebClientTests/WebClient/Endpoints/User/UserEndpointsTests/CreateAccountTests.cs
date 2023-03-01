using Moq.Protected;
using Moq;
using System.Net;
using Shared_Resources.Model.Users;
using Web_Client.Endpoints.Users;

namespace WebClientTests.WebClient.Endpoints.User.UserEndpointsTests
{
    public class CreateAccountTests
    {
        [Test]
        public void ShouldHandleSuccessfulCreateAccount()
        {
            const string json = "{\"message\":\"mySessionCode\", \"code\":\"200\"}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new UsersEndpoints(httpClient);

            Assert.That(
                endpoints.CreateAccount(new NewAccount("username", "password", "password", "first", "lname",
                    "email@email.com")), Is.EqualTo("mySessionCode"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulCreateAccount()
        {
            const string json = "{\"message\":\"myErrorMessage\", \"code\":\"500\"}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new UsersEndpoints(httpClient);

            var message = Assert.Throws<ArgumentException>(() =>
            {
                endpoints.CreateAccount(new NewAccount("username", "password", "password", "first", "lname",
                    "email@email.com"));
            })?.Message;

            Assert.That(message, Is.EqualTo("myErrorMessage"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
        }
    }
}