using System.Text.Json.Nodes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace SharedResourcesTests.SharedResources.Utils.Json.JsonUtilsTests
{
    public class ThreeParameterGetJsonStringTests
    {
        [Test]
        public void ShouldNotAllowNullParsedJsonForGettingNestedJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(null!, "key", "nestedkey");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.ParsedJsonCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullFirstElementNameForGettingNestedJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, null!, "nestedkey");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowEmptyFirstElementNameForGettingNestedJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, "   ", "nestedkey");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAllowNullSecondElementNameForGettingNestedJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":{\"nestedKey\":\"value\"}}")!, "key", null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowEmptySecondElementNameForGettingNestedJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":{\"nestedKey\":\"value\"}}")!, "key", "   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeEmpty));
        }

        [Test]
        public void ShouldGetNestedJsonStringWithNullSecondElement()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":null}")!, "key", "null");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.RequestContentNodeCannotBeNull));
        }

        [Test]
        public void ShouldGetNestedJsonString()
        {
            var jsonString = JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":{\"nestedKey\":\"value\"}}")!, "key", "nestedKey");
            Assert.That(jsonString, Is.EqualTo("value"));
        }

        [Test]
        public void ShouldGetNonExistentJsonString()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.GetJsonString(JsonNode.Parse("{\"key\":\"value\"}")!, "notkey");
            })?.Message;

            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.RequestContentNodeCannotBeNull));
        }
    }
}
