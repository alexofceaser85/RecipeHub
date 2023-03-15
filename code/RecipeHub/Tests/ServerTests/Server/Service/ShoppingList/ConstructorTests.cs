using Server.DAL.Ingredients;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.ShoppingList;

namespace ServerTests.Server.Service.ShoppingList
{
    public class ConstructorTests
    {
        [Test]
        public void TestZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListService();
            });
        }

        [Test]
        public void TestFourParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListService(new UsersDal(), new PlannedMealsDal(), new IngredientsDal(), new RecipeDal());
            });
        }

        [Test]
        public void ShouldNotAllowNullUsersDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ShoppingListService(null!, new PlannedMealsDal(), new IngredientsDal(), new RecipeDal());
            })?.Message;

            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.UsersDalCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullPlannedMealsDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ShoppingListService(new UsersDal(), null!, new IngredientsDal(), new RecipeDal());
            })?.Message;

            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.PlannedMealsDalCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullIngredientsDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ShoppingListService(new UsersDal(), new PlannedMealsDal(), null!, new RecipeDal());
            })?.Message;

            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.IngredientsDalCannotBeNull));
        }

        [Test]
        public void ShouldNotAllowNullRecipeDal()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ShoppingListService(new UsersDal(), new PlannedMealsDal(), new IngredientsDal(), null!);
            })?.Message;

            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.RecipesDalCannotBeNull));
        }
    }
}
