using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;

namespace ServerTests.Server.Service.Ingredients.IngredientsServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new IngredientsService());
        }

        [Test]
        public void NullUsersDal()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _ = new IngredientsService(null!, new IngredientsDal(), new RecipeDal()));
        }

        [Test]
        public void NullIngredientsDal()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _ = new IngredientsService(new UsersDal(), null!, new RecipeDal()));
        }

        [Test]
        public void NullRecipesDal()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _ = new IngredientsService(new UsersDal(), new IngredientsDal(), null!));
        }
    }
}