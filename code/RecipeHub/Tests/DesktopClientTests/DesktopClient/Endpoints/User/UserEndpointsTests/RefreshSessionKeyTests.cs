using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Users;
using Shared_Resources.Data.UserData;
using Shared_Resources.ErrorMessages;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    public class RefreshSessionKeyTests
    {
        [Test]
        public void ShouldHandleSuccessfulRefreshSessionKey()
        {
            Session.Key = "prevSessionKey";
            var json = "{\"message\":\"mysessioncode\", \"code\":\"200\"}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new UsersEndpoints(httpClient);

            Assert.That(endpoints.RefreshSessionKey("prevSessionKey"), Is.EqualTo("mysessioncode"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulRefreshSessionKey()
        {
            Session.Key = "prevSessionKey";
            var json = "{\"message\":\"myerrormessage\", \"code\":\"401\"}";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent(json)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var endpoints = new UsersEndpoints(httpClient);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                endpoints.RefreshSessionKey("prevSessionKey");
            })?.Message;

            Assert.That(message, Is.EqualTo(UsersServiceErrorMessages.UnauthorizedAccessErrorMessage));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
