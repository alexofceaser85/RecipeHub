using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace ServerTests.Utils.Json.JsonUtilsTests
{
    public class ParseToJsonNodesTests
    {
        [Test]
        public void ParseValidJsonString()
        {
            var jsonString = "{\"key\": \"value\"}";
            var json = JsonUtils.ParseToJsonNode(jsonString);

            Assert.That(json.AsObject()["key"]!.ToString(), Is.EqualTo("value"));
        }

        [Test]
        public void NullJsonString()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => JsonUtils.ParseToJsonNode(null!))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonToParseCannotBeNull));
            });
        }

        [Test]
        public void EmptyJsonString()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => JsonUtils.ParseToJsonNode("   "))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonToParseCannotBeEmpty));
            });
        }
    }
}
