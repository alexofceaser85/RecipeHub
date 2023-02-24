using Web_Client.Model.Filters;

namespace WebClientTests.WebClient.Model.Filters.FiltersBindingModelTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            var model = new FiltersBindingModel();
            Assert.Multiple(() =>
            {
                Assert.That(model.FiltersTypes, Is.EqualTo(null));
            });
        }

        [Test]
        public void ShouldSet()
        {
            var model = new FiltersBindingModel();
            var filters = new List<string> { "type1", "type2", "type3" };
            model.FiltersTypes = filters;
            Assert.Multiple(() =>
            {
                Assert.That(model.FiltersTypes, Is.EqualTo(filters));
            });
        }
    }
}
