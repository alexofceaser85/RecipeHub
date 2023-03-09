using Desktop_Client.ViewModel.PlannedMeals;

namespace DesktopClientTests.DesktopClient.ViewModel.PlannedMeals.PlannedMealsViewModelTests
{
    internal class ConstructorTests
    {
        [Test]
        public void ValidConstructor()
        {
            var viewmodel = new PlannedMealsViewModel();
            Assert.That(viewmodel.PlannedMeals, Has.Length.Zero);
        }

        [Test]
        public void OneParameterConstructor()
        {
            var viewmodel = new PlannedMealsViewModel();
            Assert.That(viewmodel.PlannedMeals, Has.Length.Zero);
        }

        [Test]
        public void NullServiceThrowsException()
        {
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new PlannedMealsViewModel(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'service')"));
            });
        }
    }
}
