using Moq.Protected;
using Moq;
using System.Net;
using Desktop_Client.Endpoints.Users;
using Shared_Resources.Model.Users;

namespace DesktopClientTests.DesktopClient.Endpoints.User.UserEndpointsTests
{
    public class CreateAccountTests
    {
        [Test]
        public void ShouldHandleSuccessfulCreateAccount()
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

            Assert.That(endpoints.CreateAccount(new NewAccount("username", "password", "password", "fname", "lname", "email@email.com")), Is.EqualTo("mysessioncode"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public void ShouldHandleUnsuccessfulCreateAccount()
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
                endpoints.CreateAccount(new NewAccount("username", "password", "password", "fname", "lname", "email@email.com"));
            })?.Message;

            Assert.That(message, Is.EqualTo("myerrormessage"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
