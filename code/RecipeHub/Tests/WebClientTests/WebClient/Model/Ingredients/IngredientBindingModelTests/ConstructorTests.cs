using Shared_Resources.Model.Ingredients;
using Web_Client.Model.Ingredients;

namespace WebClientTests.WebClient.Model.Ingredients.IngredientBindingModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var ingredientModel = new IngredientBindingModel();
            Assert.Multiple(() =>
            {
                Assert.That(ingredientModel.Name, Is.EqualTo(null));
                Assert.That(ingredientModel.Amount, Is.EqualTo(0));
                Assert.That(ingredientModel.MeasurementType, Is.EqualTo(MeasurementType.Quantity));
            });
        }
    }
}
