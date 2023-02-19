using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;

namespace ServerTests.Server.Controllers.ResponseModels.BaseResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateBaseResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new BaseResponseModel(HttpStatusCode.Continue, null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateBaseResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new BaseResponseModel(HttpStatusCode.Continue, "   ");
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForBaseResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = null!; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForBaseResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = "   "; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForBaseResponseModel()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message") {
                Message = "my message"
            };
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateBaseResponseModelWithValidData()
        {
            var responseModel = new BaseResponseModel(HttpStatusCode.Continue, "message");

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
        }
    }
}