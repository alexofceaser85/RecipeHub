using Moq;
using Server.DAL.Recipes;
using Server.DAL.RecipeTypes;
using Server.DAL.Users;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class GetRecipeStepsTests
    {
        [Test]
        public void RetrieveValidStepList()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const int userId = 0;
            var steps = new RecipeStep[] {
                new (0, "name", "instructions"),
                new (1, "name", "instructions"),
                new (2, "name", "instructions")
            };

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            recipesDal.Setup(mock => mock.GetStepsForRecipe(recipeId)).Returns(steps);
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(userId, recipeId)).Returns(true);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            var result = service.GetRecipeSteps(sessionKey, recipeId);

            Assert.Multiple(() =>
            {
                recipesDal.Verify(mock => mock.GetStepsForRecipe(recipeId), Times.Once);
                recipesDal.Verify(mock => mock.UserCanSeeRecipe(userId, recipeId), Times.Once);
                usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
                Assert.That(result, Is.EqualTo(steps));
            });
            
        }

        [Test]
        public void NullSessionKey()
        {
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().GetRecipeSteps(null!, 0));
        }

        [Test]
        public void EmptySessionKey()
        {
            Assert.Throws<UnauthorizedAccessException>(() => new RecipesService().GetRecipeSteps("", 0));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey("0")).Returns((int?)null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);
            Assert.Throws<UnauthorizedAccessException>(() => service.GetRecipeSteps("0", 0));
        }

        [Test]
        public void UserCannotSeeRecipe()
        {
            const string sessionKey = "Key";
            const int recipeId = 0;
            const int userId = 0;

            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            var recipeTypesDal = new Mock<RecipeTypesDal>();
            recipesDal.Setup(mock => mock.UserCanSeeRecipe(userId, recipeId)).Returns(false);
            usersDal.Setup(mock => mock.GetIdForSessionKey(sessionKey)).Returns(userId);

            var service = new RecipesService(recipesDal.Object, usersDal.Object, recipeTypesDal.Object);

            Assert.Multiple(() =>
            {
                Assert.Throws <ArgumentException>(() => service.GetRecipeSteps(sessionKey, recipeId));
                recipesDal.Verify(mock => mock.UserCanSeeRecipe(userId, recipeId), Times.Once);
                usersDal.Verify(mock => mock.GetIdForSessionKey(sessionKey), Times.Once);
            });
        }
    }
}
