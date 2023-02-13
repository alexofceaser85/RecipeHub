using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Users;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    internal class GetUserInfoTests
    {
        [Test]
        public void ShouldHandleSuccessfulGetUserInfo()
        {
            var json = "{\"message\":\"mysessioncode\", \"code\":\"200\", \"userInfo\":{\"userName\":\"username\",\"firstName\":\"firstname\",\"lastName\":\"lastname\",\"email\":\"email@email.com\"}}";

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
            var userInfo = endpoints.GetUserInfo("mykey");

            Assert.That(userInfo.UserName, Is.EqualTo("username"));
            Assert.That(userInfo.FirstName, Is.EqualTo("firstname"));
            Assert.That(userInfo.LastName, Is.EqualTo("lastname"));
            Assert.That(userInfo.Email, Is.EqualTo("email@email.com"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulGetUserInfo()
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
                endpoints.GetUserInfo("mysessionkey");
            })?.Message;

            Assert.That(message, Is.EqualTo("myerrormessage"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
