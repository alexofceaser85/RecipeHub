using Moq;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Recipes;
using Shared_Resources.Model.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    public class GetRecipesTests
    {
        [Test]
        public void RetrieveValidRecipeList()
        {
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false),
                new(2, "author3 name3", "name3", "description3", false)
            };
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            recipesDal.Setup(mock => mock.GetRecipesWithName(0, "a")).Returns(recipes);
            usersDal.Setup(mock => mock.GetIdForSessionKey("0")).Returns(0);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            var result = service.GetRecipes("0", "a");

            usersDal.Verify(mock => mock.GetIdForSessionKey("0"), Times.Once());
            recipesDal.Verify(mock => mock.GetRecipesWithName(0, "a"), Times.Once);
            Assert.That(result, Is.EquivalentTo(recipes));
        }

        [Test]
        public void NullSessionKey()
        {
            Assert.Throws<ArgumentNullException>(() => new RecipesService().GetRecipes(null!));
        }

        [Test]
        public void EmptySessionKey()
        {
            Assert.Throws<ArgumentException>(() => new RecipesService().GetRecipes(""));
        }

        [Test]
        public void NullNameFilter()
        {
            Assert.Throws<ArgumentNullException>(() => new RecipesService().GetRecipes("Key", null!));
        }

        [Test]
        public void SessionKeyIsUnused()
        {
            var recipesDal = new Mock<IRecipesDal>();
            var usersDal = new Mock<IUsersDal>();
            usersDal.Setup(mock => mock.GetIdForSessionKey("0")).Returns((int?) null);

            var service = new RecipesService(recipesDal.Object, usersDal.Object);
            Assert.Throws<ArgumentException>(() => service.GetRecipes("0", "a"));
        }
    }
}