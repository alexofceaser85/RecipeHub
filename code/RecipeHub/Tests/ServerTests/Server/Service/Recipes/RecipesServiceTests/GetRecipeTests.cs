using Moq;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class GetRecipeTests
    {
        [Test]
        public void RetrieveValidRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const int userId = 0;
            var recipe = new Recipe(0, "name", "name", "description", true);

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            recipesDal.Setup(mock => mock.GetRecipe(recipeId)).Returns(recipe);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(userId, recipeId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            var result = service.GetRecipe(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                recipesDal.Verify(mock => mock.GetRecipe(recipeId), Times.Once);
                recipesDal.Verify(mock => mock.UserCanSeeRecipe(userId, recipeId), Times.Once);
                usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
                Assert.That(result, Is.EqualTo(recipe));
            });
            
        }

        [Test]
        public void NullSessionKey()
        {
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().GetRecipe(null!, 0));
        }

        [Test]
        public void EmptySessionKey()
        {
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().GetRecipe("", 0));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey("0")).Returns((int?)null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            Assert.Throws<UnauthorizedAccessException>(() => service.GetRecipe("0", 0));
        }

        [Test]
        public void UserCannotSeeRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const int userId = 0;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(userId, recipeId)).Returns(false);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);

            Assert.Multiple(() =>
            {
                Assert.Throws <ArgumentException>(() => service.GetRecipe(sessionKey, recipeId));
                recipesDal.Verify(mock => mock.UserCanSeeRecipe(userId, recipeId), Times.Once);
                usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            });
        }
    }
}
