using Server.DAL.Ingredients;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.Service.Ingredients;
using Server.Service.Recipes;

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
        public void NullRecipesDal()
        {
            Assert.Throws<ArgumentNullException>(() => 
                _ = new IngredientsService(null!, new IngredientsDal()));
        }
        
        [Test]
        public void NullUsersDal()
        {
            Assert.Throws<ArgumentNullException>(() => 
                _ = new IngredientsService(new UsersDal(), null!));
        }
    }
}
