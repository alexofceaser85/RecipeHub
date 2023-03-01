
using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class AddSelectedTagTests
    {
        [Test]
        public void AddTagToEmptySelection()
        {
            const string tag = "tag";

            var viewmodel = new RecipeListFilterViewModel();
            viewmodel.AddSelectedTag(tag);

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.SelectedTags, Does.Contain(tag));
                Assert.That(viewmodel.SelectedTags, Has.Count.EqualTo(1));
            });
        }

        [Test]
        public void AddManyTags()
        {
            const string tag1 = "tag1";
            const string tag2 = "tag2";
            const string tag3 = "tag3";

            var viewmodel = new RecipeListFilterViewModel();
            viewmodel.AddSelectedTag(tag1);
            viewmodel.AddSelectedTag(tag2);
            viewmodel.AddSelectedTag(tag3);

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.SelectedTags, Does.Contain(tag1));
                Assert.That(viewmodel.SelectedTags, Does.Contain(tag2));
                Assert.That(viewmodel.SelectedTags, Does.Contain(tag3));
                Assert.That(viewmodel.SelectedTags, Has.Count.EqualTo(3));
            });
        }

        [Test]
        public void AddDuplicateTag()
        {
            const string tag = "tag";

            var viewmodel = new RecipeListFilterViewModel();
            viewmodel.AddSelectedTag(tag);
            viewmodel.AddSelectedTag(tag);
            viewmodel.AddSelectedTag(tag);

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.SelectedTags, Does.Contain(tag));
                Assert.That(viewmodel.SelectedTags, Has.Count.EqualTo(1));
            });
        }

        [Test]
        public void AddNullTag()
        {
            const string tag = null!;

            var viewmodel = new RecipeListFilterViewModel();
            
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    viewmodel.AddSelectedTag(tag!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'newTag')"));
            });
        }
    }
}
