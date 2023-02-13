using System.Text.Json.Nodes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace SharedResourcesTests.SharedResources.Utils.Json.JsonUtilsTests
{
    public class TwoParameterGetJsonStringTests
    {
        [Test]
        public void ShouldNotGetJsonStringForNullParsedJson()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(null!, "element");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.ParsedJsonCannotBeNull));
        }

        [Test]
        public void ShouldNotGetJsonStringForNullElementName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeNull));
        }

        [Test]
        public void ShouldNotGetJsonStringForEmptyElementName()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty));
        }

        [Test]
        public void ShouldGetJsonString()
        {
            var jsonString = JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, "key");
            Assert.That(jsonString, Is.EqualTo("value"));
        }
    }
}
