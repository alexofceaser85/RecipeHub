using Desktop_Client.Service.RecipeTypes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.Filters;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class InitializeTests
    {
        [Test]
        public void SuccessfullyInitializes()
        {
            var filters = new RecipeFilters() {
                OnlyAvailableIngredients = false,
                MatchTags = new[] {
                    "Breakfast",
                    "Lunch"
                }
            };
            var tags = new[] {
                "Breakfast",
                "Lunch",
                "Dinner"
            };

            var service = new Mock<IRecipeTypesService>();
            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(tags);

            var viewmodel = new RecipeListFilterViewModel(service.Object);
            viewmodel.Initialize(filters);

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.FilterForAvailableIngredients, Is.EqualTo(filters.OnlyAvailableIngredients));
                Assert.That(viewmodel.SelectedTags, Is.EquivalentTo(filters.MatchTags));
                Assert.That(viewmodel.FilteredTags, Is.EquivalentTo(tags));
                service.Verify(mock => mock.GetAllRecipeTypes(), Times.Once);
            });
        }
    }
}
