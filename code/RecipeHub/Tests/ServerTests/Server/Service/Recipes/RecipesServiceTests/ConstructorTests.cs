using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Recipes;

namespace ServerTests.Server.Service.Recipes.RecipesServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new RecipesService());
        }

        [Test]
        public void NullRecipesDal()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesService(null!, new UsersDal()));
        }

        [Test]
        public void NullUsersDal()
        {
            Assert.Throws<ArgumentNullException>(() => _ = new RecipesService(new RecipeDal(), null!));
        }
    }
}