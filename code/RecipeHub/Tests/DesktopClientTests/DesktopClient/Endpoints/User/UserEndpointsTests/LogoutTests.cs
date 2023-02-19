using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Users;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    public class LogoutTests
    {
        [Test]
        public void ShouldHandleSuccessfulLogout()
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

            Assert.That(endpoints.Logout("myKey"), Is.EqualTo("mySessionCode"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulLogout()
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

            var message = Assert.Throws<ArgumentException>(() => { endpoints.Logout("mySessionKey"); })?.Message;

            Assert.That(message, Is.EqualTo("myErrorMessage"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>());
        }
    }
}