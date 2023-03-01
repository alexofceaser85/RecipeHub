using Shared_Resources.Model.Ingredients;

namespace SharedResourcesTests.SharedResources.Model.Ingredients.IngredientsTests
{
    public class ConstructorTests
    {
        [Test]
        public void ValidConstructor()
        {
            const string name = "name";
            const int amount = 0;
            const MeasurementType type = MeasurementType.Mass;

            Assert.Multiple(() =>
            {
                var ingredient = new Ingredient(name, amount, type);
                Assert.That(ingredient.Name, Is.EqualTo(name));
                Assert.That(ingredient.Amount, Is.EqualTo(amount));
                Assert.That(ingredient.MeasurementType, Is.EqualTo(type));
            });
        }

        [Test]
        public void NameIsNull()
        {
            const string name = null!;
            const int amount = 0;
            const MeasurementType type = MeasurementType.Mass;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>((
                    ) => _ =new Ingredient(name!, amount, type))!.Message;
                Assert.That(message, Is.EqualTo("Name cannot be null or empty."));
            });
        }
        
        [Test]
        public void NameIsEmpty()
        {
            const string name = "   ";
            const int amount = 0;
            const MeasurementType type = MeasurementType.Mass;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentException>((
                ) => _ = new Ingredient(name, amount, type))!.Message;
                Assert.That(message, Is.EqualTo("Name cannot be null or empty."));
            });
        }

        [Test]
        public void AmountIsNegative()
        {
            const string name = "name";
            const int amount = -1;
            const MeasurementType type = MeasurementType.Mass;

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentOutOfRangeException>((
                ) => _ = new Ingredient(name, amount, type))!.Message;
                Assert.That(message, Is.EqualTo("Amount cannot be less than 0. (Parameter 'amount')\r\nActual value was -1."));
            });
        }
    }
}
