using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.ResponseModels.RecipeResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateRecipeResponseModelWithNullMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeResponseModel(HttpStatusCode.Continue, null!, new Recipe());
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotCreateRecipeResponseModelWithEmptyMessage()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new RecipeResponseModel(HttpStatusCode.Continue, "   ", new Recipe());
            })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldNotSetNullMessageForRecipeResponseModel()
        {
            var responseModel = new RecipeResponseModel(HttpStatusCode.Continue, "message", new Recipe());

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = null!; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeNull));
        }

        [Test]
        public void ShouldNotSetEmptyMessageForRecipeResponseModel()
        {
            var responseModel = new RecipeResponseModel(HttpStatusCode.Continue, "message", new Recipe());

            var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = "   "; })?.Message;

            Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
        }

        [Test]
        public void ShouldSetValidMessageValueForRecipeResponseModel()
        {
            var recipe = new Recipe();
            var responseModel = new RecipeResponseModel(HttpStatusCode.Continue, "message", recipe) {
                Message = "my message"
            };
            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("my message"));
                Assert.That(responseModel.Recipe, Is.EqualTo(recipe));
            });
        }

        [Test]
        public void ShouldCreateRecipeResponseModelWithValidData()
        {
            var responseModel = new RecipeResponseModel(HttpStatusCode.Continue, "message", new Recipe());

            Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
            Assert.That(responseModel.Message, Is.EqualTo("message"));
        }
    }
}