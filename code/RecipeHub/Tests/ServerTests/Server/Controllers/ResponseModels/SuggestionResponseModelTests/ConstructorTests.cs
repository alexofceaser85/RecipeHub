using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;

namespace ServerTests.Server.Controllers.ResponseModels.SuggestionResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateSuggestionResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new SuggestionResponseModel(HttpStatusCode.Continue, null!, new List<string>());
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateSuggestionResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new SuggestionResponseModel(HttpStatusCode.Continue, "   ", new List<string>());
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForSuggestionResponseModel()
        {
            var responseModel = new SuggestionResponseModel(HttpStatusCode.Continue, "message", new List<string>());

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = null!; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForSuggestionResponseModel()
        {
            var responseModel = new SuggestionResponseModel(HttpStatusCode.Continue, "message", new List<string>());

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = "   "; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForSuggestionResponseModel()
        {
            var suggestions = new List<string>();
            var responseModel = new SuggestionResponseModel(HttpStatusCode.Continue, "message", suggestions) {
                Message = "my message"
            };
            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("my message"));
                Assert.That(responseModel.Suggestions, Is.EquivalentTo(suggestions));
            });
        }

        [Test]
        public void ShouldCreateSuggestionResponseModelWithValidData()
        {
            var responseModel = new SuggestionResponseModel(HttpStatusCode.Continue, "message", new List<string>());

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("message"));
                Assert.That(responseModel.Suggestions, Is.EquivalentTo(new List<string>()));
            });
        }

        [Test]
        public void ShouldNotCreateSuggestionResponseModelWithNullSuggestions()
        {
            var message = Assert.Throws<ArgumentNullException>(
                () => _ = new SuggestionResponseModel(HttpStatusCode.Continue, "message", null!))!.Message;

            Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'suggestions')"));
        }

        [Test]
        public void ShouldNotSetNullSuggestionsForSuggestionResponseModel()
        {
            var responseModel = new SuggestionResponseModel(HttpStatusCode.Continue, "message", new List<string>());

            var message = Assert.Throws<ArgumentNullException>(() => { responseModel.Suggestions = null!; })?.Message;

            Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'value')"));
        }
    }
}