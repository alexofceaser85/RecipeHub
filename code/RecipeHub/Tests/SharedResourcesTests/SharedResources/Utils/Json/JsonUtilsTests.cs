using System.Text.Json.Nodes;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace SharedResourcesTests.SharedResources.Utils.Json
{
    public class JsonUtilsTests
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

        [Test]
        public void ShouldNotAllowJsonToParseToBeNull()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.ParseToJsonNode(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonToParseCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowJsonToParseToBeEmpty()
        {

            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.ParseToJsonNode("   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonToParseCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAllowParsedJsonToBeNull()
        {

            var message = Assert.Throws<ArgumentException>(() =>
            {
                JsonUtils.ParseToJsonNode("null");
            })?.Message;
            Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.ParsedJsonCannotBeNull));
        }
    }
}
