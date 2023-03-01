
using Desktop_Client.Service.RecipeTypes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.Filters;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class ApplySearchTermFilterTests
    {
        [Test]
        public void EmptyTagString()
        {
            var tags = new[] {
                "Breakfast",
                "Lunch",
                "Dinner"
            };


            var service = new Mock<IRecipeTypesService>();
            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(tags);

            var viewmodel = new RecipeListFilterViewModel(service.Object);
            viewmodel.Initialize(new RecipeFilters());
            viewmodel.ApplySearchTermFilter();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.FilteredTags, Is.EquivalentTo(tags));
            });
        }

        [Test]
        public void NoMatchingTags()
        {
            var tags = new[] {
                "Breakfast",
                "Lunch",
                "Dinner"
            };
            const string searchTerm = "z";

            var service = new Mock<IRecipeTypesService>();
            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(tags);

            var viewmodel = new RecipeListFilterViewModel(service.Object);
            viewmodel.Initialize(new RecipeFilters());
            viewmodel.SearchTerm = searchTerm;
            viewmodel.ApplySearchTermFilter();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.FilteredTags, Has.Count.Zero);
            });
        }

        [Test]
        public void AllTagsMatchSearchTerm()
        {
            var tags = new[] {
                "Lunch",
                "Dinner"
            };
            const string searchTerm = "n";


            var service = new Mock<IRecipeTypesService>();
            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(tags);

            var viewmodel = new RecipeListFilterViewModel(service.Object);
            viewmodel.Initialize(new RecipeFilters());
            viewmodel.SearchTerm = searchTerm;
            viewmodel.ApplySearchTermFilter();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.FilteredTags, Is.EquivalentTo(tags));
                foreach (var tag in viewmodel.FilteredTags)
                {
                    Assert.That(tag.Contains(searchTerm));
                }
            });
        }

        [Test]
        public void SomeTagsMatchSearchTerm()
        {
            var tags = new[] {
                "Breakfast",
                "Lunch",
                "Dinner"
            };
            const string searchTerm = "n";


            var service = new Mock<IRecipeTypesService>();
            service.Setup(mock => mock.GetAllRecipeTypes()).Returns(tags);

            var viewmodel = new RecipeListFilterViewModel(service.Object);
            viewmodel.Initialize(new RecipeFilters());
            viewmodel.SearchTerm = searchTerm;
            viewmodel.ApplySearchTermFilter();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.FilteredTags, Has.Count.EqualTo(2));
                foreach (var tag in viewmodel.FilteredTags)
                {
                    Assert.That(tag.Contains(searchTerm));
                }
            });
        }
    }
}
