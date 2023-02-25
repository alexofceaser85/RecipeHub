using Desktop_Client.ViewModel.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Dialogs.RecipeListFilterViewModelTests
{
    public class RemoveSelectedTagTests
    {
        [Test]
        public void RemoveExistingTag()
        {
            const string tag = "tag";
            var viewmodel = new RecipeListFilterViewModel();

            viewmodel.AddSelectedTag(tag);
            viewmodel.RemoveSelectedTag(tag);
            
            Assert.That(viewmodel.SelectedTags, Has.Count.Zero);
        }

        [Test]
        public void RemoveFromEmptySelectedTagsList()
        {
            const string tag = "tag";
            var viewmodel = new RecipeListFilterViewModel();
            
            viewmodel.RemoveSelectedTag(tag);

            Assert.That(viewmodel.SelectedTags, Has.Count.Zero);
        }

        [Test]
        public void RemoveNullTag()
        {
            var viewmodel = new RecipeListFilterViewModel();

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    viewmodel.RemoveSelectedTag(null!))!.Message;
                Assert.That(message, Is.EqualTo("Value cannot be null. (Parameter 'tag')"));
            });
        }
    }
}
