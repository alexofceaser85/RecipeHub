
using Desktop_Client.Service.Ingredients;
using Desktop_Client.ViewModel.Ingredients;
using Moq;
using Shared_Resources.Model.Ingredients;

namespace DesktopClientTests.DesktopClient.ViewModel.Ingredients.IngredientsViewModelTests
{
    public class GetAllIngredientsForUserTests
    {
        [Test]
        public void SuccessfullyGetManyIngredients()
        {
            var ingredients = new Ingredient[] {
                new ("name1", 1, MeasurementType.Quantity),
                new ("name2", 5, MeasurementType.Mass)
            };

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new IngredientsViewModel(service.Object);
            viewmodel.GetAllIngredientsForUser();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Ingredients, Is.EquivalentTo(ingredients));
                Assert.That(viewmodel.RemoveAllButtonEnabled, Is.EqualTo(true));
                service.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyGetNoIngredients()
        {
            var ingredients = Array.Empty<Ingredient>();

            var service = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new IngredientsViewModel(service.Object);
            viewmodel.GetAllIngredientsForUser();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Ingredients, Is.EquivalentTo(ingredients));
                Assert.That(viewmodel.RemoveAllButtonEnabled, Is.EqualTo(false));
                service.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }
    }
}
