using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Controllers.ResponseModels.PantryResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreatePantryResponseModelWithNullMessage()
        {
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    _ = new PantryResponseModel(HttpStatusCode.Continue, null!, Array.Empty<Ingredient>());
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void ShouldNotCreatePantryResponseModelWithEmptyMessage()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    _ = new PantryResponseModel(HttpStatusCode.Continue, "   ", Array.Empty<Ingredient>());
                })?.Message;
                Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
            });
        }

        [Test]
        public void ShouldNotSetNullMessageForPantryResponseModel()
        {
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull;
            var responseModel = new PantryResponseModel(HttpStatusCode.Continue, "message", Array.Empty<Ingredient>());

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
        public void ShouldNotSetEmptyMessageForPantryResponseModel()
        {
            var responseModel = new PantryResponseModel(HttpStatusCode.Continue, "message", Array.Empty<Ingredient>());

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
        public void ShouldSetValidMessageValueForPantryResponseModel()
        {
            var responseModel = new PantryResponseModel(HttpStatusCode.Continue, "message", Array.Empty<Ingredient>());
            responseModel.Message = "my message";
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreatePantryResponseModelWithValidData()
        {
            var ingredients = new Ingredient[] {
                new ("name", 1, MeasurementType.Volume)
            };
            var responseModel = new PantryResponseModel(HttpStatusCode.Continue, "message", ingredients);

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("message"));
                Assert.That(responseModel.Pantry, Is.EquivalentTo(ingredients));
            });
        }
    }
}
