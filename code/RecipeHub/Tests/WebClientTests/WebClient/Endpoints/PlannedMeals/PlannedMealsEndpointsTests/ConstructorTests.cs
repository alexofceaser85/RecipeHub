using Web_Client.Endpoints.PlannedMeals;

namespace WebClientTests.WebClient.Endpoints.PlannedMeals.PlannedMealsEndpointsTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            Assert.DoesNotThrow(() => _ = new PlannedMealsEndpoints());
        }

        [Test]
        public void OneParameterConstructor()
        {
            Assert.DoesNotThrow(() => _ = new PlannedMealsEndpoints(new HttpClient()));
        }

        [Test]
        public void NullHttpClient()
        {
            const string errorMessage = "Value cannot be null. (Parameter 'client')";
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(
                    () => _ = new PlannedMealsEndpoints(null!))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}