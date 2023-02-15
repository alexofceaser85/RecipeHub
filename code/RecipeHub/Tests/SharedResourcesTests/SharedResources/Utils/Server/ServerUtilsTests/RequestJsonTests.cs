using Moq;
using System.Net;
using Moq.Protected;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Server;

namespace SharedResourcesTests.SharedResources.Utils.Server.ServerUtilsTests
{
    public class RequestJsonTests
    {
        [Test]
        public void ShouldNotRequestJsonIfMethodIsNull()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                ServerUtils.RequestJson(null!, "request", new HttpClient());
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.HttpMethodCannotBeNull));
        }

        [Test]
        public void ShouldNotRequestJsonIfRequestUriIsNull()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                ServerUtils.RequestJson(HttpMethod.Get, null!, new HttpClient());
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.RequestUriCannotBeNull));
        }

        [Test]
        public void ShouldNotRequestJsonIfRequestUriIsBlank()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                ServerUtils.RequestJson(HttpMethod.Get, "   ", new HttpClient());
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.RequestUriCannotBeEmpty));
        }

        [Test]
        public void ShouldNotRequestJsonIfClientIsNull()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                ServerUtils.RequestJson(HttpMethod.Get, "request", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.HttpClientCannotBeNull));
        }

        [Test]
        public void TestValidJsonRequest()
        {
            var httpMethod = HttpMethod.Get;
            var requestUri = "https://www.example.com";
            var json = "{\"key\":\"value\"}";

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

            var result = ServerUtils.RequestJson(httpMethod, requestUri, httpClient);

            Assert.That(result["key"]?.ToString(), Is.EqualTo("value"));

            mockHttpMessageHandler
                .Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>());
        }
    }
}
