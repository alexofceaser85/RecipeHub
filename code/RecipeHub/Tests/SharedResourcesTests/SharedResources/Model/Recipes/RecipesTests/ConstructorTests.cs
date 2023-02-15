using Shared_Resources.ErrorMessages;
using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipesTests
{
    public class ConstructorTests
    {
        [Test]
        public void DefaultConstructor()
        {
            const int id = 0;
            const string authorName = "";
            const string name = "";
            const string description = "";
            const bool isPublic = false;

            var recipe = new Recipe();

            Assert.Multiple(() =>
            {
                Assert.That(recipe.Id, Is.EqualTo(id));
                Assert.That(recipe.AuthorName, Is.EqualTo(authorName));
                Assert.That(recipe.Name, Is.EqualTo(name));
                Assert.That(recipe.Description, Is.EqualTo(description));
                Assert.That(recipe.IsPublic, Is.EqualTo(isPublic));
                Assert.That(recipe.Rating, Is.EqualTo(0));
            });
        }

        [Test]
        public void ValidFiveParameterConstructor()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;

            var recipe = new Recipe(id, authorName, name, description, isPublic);

            Assert.Multiple(() =>
            {
                Assert.That(recipe.Id, Is.EqualTo(id));
                Assert.That(recipe.AuthorName, Is.EqualTo(authorName));
                Assert.That(recipe.Name, Is.EqualTo(name));
                Assert.That(recipe.Description, Is.EqualTo(description));
                Assert.That(recipe.IsPublic, Is.EqualTo(isPublic));
                Assert.That(recipe.Rating, Is.EqualTo(0));
            });
        }

        [Test]
        public void AuthorNameIsNull()
        {
            const int id = 0;
            const string authorName = null!;
            const string name = "name";
            const string description = "description";
            const bool isPublic = false;
            const string errorMessage = RecipesErrorMessages.AuthorNameCannotBeNull + " (Parameter 'value')";
            
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new Recipe(id, authorName!, name, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void RecipeNameIsNull()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = null!;
            const string description = "description";
            const bool isPublic = false;
            const string errorMessage = RecipesErrorMessages.RecipeNameCannotBeNull + " (Parameter 'value')";
            
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new Recipe(id, authorName, name!, description, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }

        [Test]
        public void RecipeDescriptionIsNull()
        {
            const int id = 0;
            const string authorName = "author name";
            const string name = "name";
            const string description = null!;
            const bool isPublic = false;
            const string errorMessage = RecipesErrorMessages.RecipeDescriptionCannotBeNull + " (Parameter 'value')";
            
            Assert.Multiple(() =>
            {
                var message = Assert.Throws<ArgumentNullException>(() => 
                    _ = new Recipe(id, authorName, name, description!, isPublic))!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
            });
        }
    }
}
