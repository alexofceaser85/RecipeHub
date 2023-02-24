using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class GetFiltersTests
    {
        [Test]
        public void GetDefaultFilters()
        {
            var viewmodel = new RecipeListFilterViewModel();
            var filters = viewmodel.Filters;

            Assert.Multiple(() =>
            {
                Assert.That(filters.OnlyAvailableIngredients, Is.EqualTo(true));
                Assert.That(filters.MatchTags, Has.Length.Zero);
            });
        }

        [Test]
        public void SetOnlyAvailableIngredientsFilter()
        {
            var viewmodel = new RecipeListFilterViewModel {
                FilterForAvailableIngredients = false
            };
            var filters = viewmodel.Filters;

            Assert.Multiple(() =>
            {
                Assert.That(filters.OnlyAvailableIngredients, Is.EqualTo(false));
                Assert.That(filters.MatchTags, Has.Length.Zero);
            });
        }

        [Test]
        public void SetOnlyMatchedTags()
        {
            var viewmodel = new RecipeListFilterViewModel();
            viewmodel.AddSelectedTag("tag1");
            viewmodel.AddSelectedTag("tag2");

            var filters = viewmodel.Filters;

            Assert.Multiple(() =>
            {
                Assert.That(filters.OnlyAvailableIngredients, Is.EqualTo(true));
                Assert.That(filters.MatchTags, Has.Length.EqualTo(2));
                Assert.That(filters.MatchTags, Does.Contain("tag1"));
                Assert.That(filters.MatchTags, Does.Contain("tag2"));
            });
        }

        [Test]
        public void SetMatchedTagsAndAvailableIngredientsFilter()
        {
            var viewmodel = new RecipeListFilterViewModel
            {
                FilterForAvailableIngredients = false
            };
            viewmodel.AddSelectedTag("tag1");
            viewmodel.AddSelectedTag("tag2");

            var filters = viewmodel.Filters;

            Assert.Multiple(() =>
            {
                Assert.That(filters.OnlyAvailableIngredients, Is.EqualTo(false));
                Assert.That(filters.MatchTags, Has.Length.EqualTo(2));
                Assert.That(filters.MatchTags, Does.Contain("tag1"));
                Assert.That(filters.MatchTags, Does.Contain("tag2"));
            });
        }
    }
}
