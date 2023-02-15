using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Shared_Resources.ErrorMessages;
using Shared_Resources.Utils.Json;

namespace ServerTests.Utils.Json.JsonUtilsTests
{
    public class GetJsonStringTests
    {
        [Test]
        public void GetValidNodeTwoParameter()
        {
            var jsonString = "{\"key\": \"value\"}";
            var json = JsonUtils.ParseToJsonNode(jsonString);

            var result = JsonUtils.GetJsonString(json, "key");
            Assert.That(result, Is.EqualTo("value"));
        }

        [Test]
        public void GetValidNodeThreeParameter()
        {
            var jsonString = "{\"key\": {\"key\": \"value\"}}";
            var json = JsonUtils.ParseToJsonNode(jsonString);

            var result = JsonUtils.GetJsonString(json, "key", "key");
            Assert.That(result, Is.EqualTo("value"));
        }

        [Test]
        public void NullJsonNodeTwoParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(null!, "name"))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.ParsedJsonCannotBeNull));
            });
        }
        
        [Test]
        public void NullJsonElementNameTwoParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), null!))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeNull));
            });
        }

        [Test]
        public void EmptyJsonElementNameTwoParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), "   "))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty));
            });
        }

        [Test]
        public void NullJsonNodeThreeParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(null!, "name"))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.ParsedJsonCannotBeNull));
            });
        }

        [Test]
        public void NullJsonElementNameThreeParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), null!, "element"))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeNull));
            });
        }

        [Test]
        public void EmptyJsonElementNameThreeParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), "   ", "element"))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonElementNameCannotBeEmpty));
            });
        }

        [Test]
        public void NullInnerJsonElementNameThreeParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), "element", null!))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeNull));
            });
        }

        [Test]
        public void EmptyInnerJsonElementNameThreeParameter()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                    JsonUtils.GetJsonString(new JsonObject(), "element", "   "))!.Message;
                Assert.That(message, Is.EqualTo(JsonUtilsErrorMessages.JsonNestedElementNameCannotBeEmpty));
            });
        }
    }
}
