
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var viewmodel = new IngredientsViewModel();
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RemoveAllButtonEnabled, Is.EqualTo(false));
                Assert.That(viewmodel.Ingredients, Has.Length.EqualTo(0));
            });
        }

        [Test]
        public void ValidOneParameterConstructor()
        {
            var viewmodel = new IngredientsViewModel(new IngredientsService());
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RemoveAllButtonEnabled, Is.EqualTo(false));
                Assert.That(viewmodel.Ingredients, Has.Length.EqualTo(0));
            });
        }

        [Test]
        public void NullIngredientsService()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new IngredientsViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
