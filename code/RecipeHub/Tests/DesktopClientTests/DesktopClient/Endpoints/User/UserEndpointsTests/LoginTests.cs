using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Users;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    public class LoginTests
    {
        [Test]
        public void ShouldHandleSuccessfulLogin()
        {
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

            Assert.That(endpoints.Login("myname", "mypassword", null!), Is.EqualTo("mysessioncode"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulLogin()
        {
            var json = "{\"message\":\"myerrormessage\", \"code\":\"500\"}";

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

            var message = Assert.Throws<ArgumentException>(() =>
            {
                endpoints.Login("myname", "mypassword", null!);
            })?.Message;

            Assert.That(message, Is.EqualTo("myerrormessage"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
