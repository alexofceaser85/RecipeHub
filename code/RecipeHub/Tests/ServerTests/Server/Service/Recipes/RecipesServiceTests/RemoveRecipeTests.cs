using Moq;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class RemoveRecipeTests
    {
        [Test]
        public void SuccessfullyRemoveRecipe()
        {
            const int recipeId = 1;
            const int authorId = 1;
            const string sessionKey = "Key";
            const bool expected = true;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            recipesDal.Setup(mock => mock.RemoveRecipe(recipeId)).Returns(expected);
            recipesDal.Setup(mock => mock.IsAuthorOfRecipe(authorId, recipeId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(authorId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            var result = service.RemoveRecipe(sessionKey, recipeId);

            Assert.That(result, Is.EqualTo(expected));
            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            recipesDal.Verify(mock => mock.RemoveRecipe(recipeId), Times.Once);
            recipesDal.Verify(mock => mock.IsAuthorOfRecipe(authorId, recipeId), Times.Once);
        }

        [Test]
        public void NullSessionKey()
        {
            const string sessionKey = null!;
            const int recipeId = 1;
            Assert.Throws<ArgumentNullException>(() => new RecipesService().RemoveRecipe(sessionKey!, recipeId));
        }
        
        [Test]
        public void EmptySessionKey()
        {
            const string sessionKey = "";
            const int recipeId = 1;
            Assert.Throws<ArgumentException>(() => new RecipesService().RemoveRecipe(sessionKey, recipeId));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            const string sessionKey = "Key";
            const int recipeId = 1;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns((int?)null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            Assert.Throws<ArgumentException>(() => service.RemoveRecipe(sessionKey, recipeId));
            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
        }

        [Test]
        public void UserNotAuthorOfRecipe()
        {
            const int recipeId = 1;
            const int authorId = 1;
            const string sessionKey = "Key";

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            recipesDal.Setup(mock => mock.IsAuthorOfRecipe(authorId, recipeId)).Returns(false);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(authorId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);

            Assert.Throws<ArgumentException>(() => service.RemoveRecipe(sessionKey, recipeId));
            usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once());
            recipesDal.Verify(mock => mock.IsAuthorOfRecipe(authorId, recipeId), Times.Once);
        }
    }
}
