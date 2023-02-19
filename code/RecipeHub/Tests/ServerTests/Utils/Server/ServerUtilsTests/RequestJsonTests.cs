using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Server;

namespace ServerTests.Utils.Server.ServerUtilsTests
{
    public class RequestJsonTests
    {
        [Test]
        public void NullHttpMethod()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => ServerUtils.RequestJson(null!, "str", new HttpClient()))!.Message;
                Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.HttpMethodCannotBeNull));
            });
        }

        [Test]
        public void NullRequestUri()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => ServerUtils.RequestJson(new HttpMethod("get"), null!, new HttpClient()))!.Message;
                Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.RequestUriCannotBeNull));
            });
        }

        [Test]
        public void EmptyRequestUri()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => ServerUtils.RequestJson(new HttpMethod("get"), "   ", new HttpClient()))!.Message;
                Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.RequestUriCannotBeEmpty));
            });
        }

        [Test]
        public void NullHttpClient()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(
                    () => ServerUtils.RequestJson(new HttpMethod("get"), "str", null!))!.Message;
                Assert.That(message, Is.EqualTo(ServerUtilsErrorMessages.HttpClientCannotBeNull));
            });
        }
    }
}