using System.Text.Json.Nodes;
using Shared_Resources.Utils.Json;

namespace SharedResourcesTests.SharedResources.Utils.Json.JsonUtilsTests
{
    public class VerifyAndGetRequestInfoTests
    {
        [Test]
        public void ShouldVerifyAndGetRequestInfoForSuccessfulRequest()
        {
            var jsonString = JsonUtils.VerifyAndGetRequestInfo(JsonNode.Parse("{\"message\":\"testMessage\", \"code\":\"200\"}")!);
            Assert.That(jsonString, Is.EqualTo("testMessage"));
        }

        [Test]
        public void ShouldNotVerifyForUnsuccessfulRequest()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.VerifyAndGetRequestInfo(JsonNode.Parse("{\"message\":\"testErrorMessage\", \"code\":\"500\"}")!);
            })?.Message;
            Assert.That(message, Is.EqualTo("testErrorMessage"));
        }
    }
}
