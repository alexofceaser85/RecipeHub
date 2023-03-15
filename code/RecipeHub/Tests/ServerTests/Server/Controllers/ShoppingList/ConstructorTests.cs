using Server.Controllers.ShoppingList;
using Server.ErrorMessages;
using Server.Service.ShoppingList;

namespace ServerTests.Server.Controllers.ShoppingList
{
    public class ConstructorTests
    {
        [Test]
        public void ShouldCreateZeroParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListController();
            });
        }

        [Test]
        public void ShouldCreateOneParameterConstructor()
        {
            Assert.DoesNotThrow(() =>
            {
                _ = new ShoppingListController(new ShoppingListService());
            });
        }

        [Test]
        public void ShouldNotAllowNullService()
        {
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = new ShoppingListController(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(ShoppingListControllerErrorMessages.ShoppingListServiceCannotBeNull));
        }
    }
}
