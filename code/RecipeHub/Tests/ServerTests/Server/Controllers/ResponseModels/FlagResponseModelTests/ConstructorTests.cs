using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.ResponseModels.FlagResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateFlagResponseModelWithNullMessage()
        {
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    _ = new FlagResponseModel(HttpStatusCode.Continue, null!, false);
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void ShouldNotCreateFlagResponseModelWithEmptyMessage()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    _ = new FlagResponseModel(HttpStatusCode.Continue, "   ", false);
                })?.Message;
                Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
            });
        }

        [Test]
        public void ShouldNotSetNullMessageForFlagResponseModel()
        {
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull;
            var responseModel = new FlagResponseModel(HttpStatusCode.Continue, "message", false);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    responseModel.Message = null!;
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void ShouldNotSetEmptyMessageForFlagResponseModel()
        {
            var responseModel = new FlagResponseModel(HttpStatusCode.Continue, "message", false);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    responseModel.Message = "   ";
                })?.Message;
                Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
            });
        }

        [Test]
        public void ShouldSetValidMessageValueForFlagResponseModel()
        {
            var responseModel = new FlagResponseModel(HttpStatusCode.Continue, "message", false);
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateFlagResponseModelWithValidData()
        {
            var responseModel = new FlagResponseModel(HttpStatusCode.Continue, "message", false);

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("message"));
                Assert.That(responseModel.Flag, Is.EqualTo(false));
            });
        }
    }
}
