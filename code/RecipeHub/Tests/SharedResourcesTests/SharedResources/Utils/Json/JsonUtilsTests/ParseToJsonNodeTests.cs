using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace SharedResourcesTests.SharedResources.Utils.Json.JsonUtilsTests
{
    public class ParseToJsonNodeTests
    {
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
