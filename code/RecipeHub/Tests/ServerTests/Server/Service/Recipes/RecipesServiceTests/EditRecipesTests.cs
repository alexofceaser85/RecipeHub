using Moq;
using Server.DAL.Recipes;
using Server.DAL.RecipeTypes;
using Server.DAL.Users;
using Server.Service.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class EditRecipeTests
    {
        [Test]
        public void SuccessfullyModifyRecipe()
        {
            const int authorId = 1;
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            const string sessionKey = "Key";
            const bool expected = true;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            recipesDal.Setup(mock => mock.EditRecipe(recipeId, name, description, isPublic)).Returns(expected);
            recipesDal.Setup(mock => mock.IsAuthorOfRecipe(authorId, recipeId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(authorId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var result = service.EditRecipe(sessionKey, recipeId, name, description, isPublic);

            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            recipesDal.Verify(mock => mock.IsAuthorOfRecipe(authorId, recipeId), Times.Once());
            recipesDal.Verify(mock => mock.EditRecipe(recipeId, name, description, isPublic), Times.Once);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().EditRecipe(sessionKey!, recipeId, name, description, isPublic));
        }

        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().EditRecipe(sessionKey!, recipeId, name, description, isPublic));
        }

        [Test]
        public void NullRecipeName()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = null!;
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<ArgumentNullException>(() =>
                new RecipesService().EditRecipe(sessionKey, recipeId, name!, description, isPublic));
        }

        [Test]
        public void EmptyRecipeName()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "";
            const string description = "description";
            const bool isPublic = false;
            Assert.Throws<ArgumentException>(() =>
                new RecipesService().EditRecipe(sessionKey, recipeId, name, description, isPublic));
        }

        [Test]
        public void NullRecipeDescription()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = null!;
            const bool isPublic = false;
            Assert.Throws<ArgumentNullException>(() =>
                new RecipesService().EditRecipe(sessionKey, recipeId, name, description!, isPublic));
        }

        [Test]
        public void EmptyRecipeDescription()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "";
            const bool isPublic = false;
            Assert.Throws<ArgumentException>(() =>
                new RecipesService().EditRecipe(sessionKey, recipeId, name, description, isPublic));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?) null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            Assert.Throws<UnauthorizedAccessException>(() => service.EditRecipe(sessionKey!, recipeId, name, description, isPublic));
            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
        }

        [Test]
        public void UserNotAuthorOfRecipe()
        {
            const string sessionKey = "Key";
            const int authorId = 1;
            const int recipeId = 1;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            recipesDal.Setup(mock => mock.IsAuthorOfRecipe(authorId, recipeId)).Returns(false);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(authorId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);

            Assert.Throws<ArgumentException>(
                () => service.EditRecipe(sessionKey, recipeId, name, description, isPublic));
            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            recipesDal.Verify(mock => mock.IsAuthorOfRecipe(authorId, recipeId), Times.Once);
        }
    }
}