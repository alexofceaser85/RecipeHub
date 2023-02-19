using System.Net;
using Server.Controllers.ResponseModels;
using Server.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Controllers.ResponseModels.RecipeListResponseModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldNotCreateRecipeListResponseModelWithNullMessage()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull + " (Parameter 'value')";

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = new RecipeListResponseModel(HttpStatusCode.Continue, null!, recipes);
                })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void ShouldNotCreateRecipeListResponseModelWithEmptyMessage()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() =>
                {
                    _ = new RecipeListResponseModel(HttpStatusCode.Continue, "   ", recipes);
                })?.Message;
                Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
            });
        }

        [Test]
        public void ShouldNotSetNullMessageForRecipeListResponseModel()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };
            const string errorMessage = ResponseModelErrorMessages.MessageCannotBeNull + " (Parameter 'value')";
            var responseModel = new RecipeListResponseModel(HttpStatusCode.Continue, "message", recipes);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => { responseModel.Message = null!; })?.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void ShouldNotSetEmptyMessageForRecipeListResponseModel()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };
            var responseModel = new RecipeListResponseModel(HttpStatusCode.Continue, "message", recipes);

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>(() => { responseModel.Message = "   "; })?.Message;
                Assert.That(message, Is.EqualTo(ResponseModelErrorMessages.MessageCannotBeEmpty));
            });
        }

        [Test]
        public void ShouldSetValidMessageValueForRecipeListResponseModel()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };
            var responseModel = new RecipeListResponseModel(HttpStatusCode.Continue, "message", recipes) {
                Message = "my message"
            };
            Assert.That(responseModel.Message, Is.EqualTo("my message"));
        }

        [Test]
        public void ShouldCreateRecipeListResponseModelWithValidData()
        {
            var recipes = new Recipe[] {
                new(1, "authorName1", "name1", "description1", false),
                new(2, "authorName2", "name2", "description2", false),
                new(3, "authorName3", "name3", "description3", false)
            };
            var responseModel = new RecipeListResponseModel(HttpStatusCode.Continue, "message", recipes);

            Assert.Multiple(() =>
            {
                Assert.That(responseModel.Code, Is.EqualTo(HttpStatusCode.Continue));
                Assert.That(responseModel.Message, Is.EqualTo("message"));
                Assert.That(responseModel.Recipes, Is.EquivalentTo(recipes));
            });
        }
    }
}