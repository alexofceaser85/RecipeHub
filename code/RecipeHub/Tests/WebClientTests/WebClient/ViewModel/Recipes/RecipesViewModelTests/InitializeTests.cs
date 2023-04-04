using Moq;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.Ingredients;
using Web_Client.Service.PlannedMeals;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipesViewModelTests
{
    public class InitializeTests
    {
        [Test]
        public void InitializeWithAllInformation()
        {
            const int recipeId = 0;
            const string recipeName = "name";
            const string authorName = "first last";
            const string description = "description";
            const string tagsText = "breakfast\nlunch";
            const string ingredientsText = "ingredient 1 - 1 ml\ningredient 2 - 2 g";
            const string instructionsText = "1: name 1\ninstructions 1\n\n2: name 2\ninstructions 2";
            const string userRating = "User Rating: 0/5";
            const string yourRating = "Your Rating: 0/5";

            var recipe = new Recipe(recipeId, authorName, recipeName, description, false);
            var ingredients = new Ingredient[] {
                new("ingredient 1", 1, MeasurementType.Volume),
                new("ingredient 2", 2, MeasurementType.Mass),
            };
            var instructions = new RecipeStep[] {
                new(1, "name 1", "instructions 1"),
                new(2, "name 2", "instructions 2")
            };
            var tags = new[] {
                "breakfast",
                "lunch"
            };

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipe(recipeId)).Returns(recipe);
            service.Setup(mock => mock.GetIngredientsForRecipe(recipeId)).Returns(ingredients);
            service.Setup(mock => mock.GetStepsForRecipe(recipeId)).Returns(instructions);
            service.Setup(mock => mock.GetTypesForRecipe(recipeId)).Returns(tags);

            var viewmodel = new RecipeViewModel(service.Object, new PlannedMealsService(), new IngredientsService());
            viewmodel.Initialize(recipeId);
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(recipeName));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(authorName));
                Assert.That(viewmodel.Tags, Is.EqualTo(tagsText));
                Assert.That(viewmodel.Description, Is.EqualTo(description));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(userRating));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(yourRating));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(ingredientsText));
                Assert.That(viewmodel.Instructions, Is.EqualTo(instructionsText));

                service.Verify(mock => mock.GetRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetStepsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetTypesForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void InitializeWithNoIngredients()
        {
            const int recipeId = 0;
            const string recipeName = "name";
            const string authorName = "first last";
            const string tagsText = "breakfast\nlunch";
            const string description = "description";
            const string ingredientsText = RecipeViewModel.NoIngredientsMessage;
            const string instructionsText = "1: name 1\ninstructions 1\n\n2: name 2\ninstructions 2";
            const string userRating = "User Rating: 0/5";
            const string yourRating = "Your Rating: 0/5";

            var recipe = new Recipe(recipeId, authorName, recipeName, description, false);
            var ingredients = Array.Empty<Ingredient>();
            var instructions = new RecipeStep[] {
                new(1, "name 1", "instructions 1"),
                new(2, "name 2", "instructions 2")
            };
            var tags = new[] {
                "breakfast",
                "lunch"
            };

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipe(recipeId)).Returns(recipe);
            service.Setup(mock => mock.GetIngredientsForRecipe(recipeId)).Returns(ingredients);
            service.Setup(mock => mock.GetStepsForRecipe(recipeId)).Returns(instructions);
            service.Setup(mock => mock.GetTypesForRecipe(recipeId)).Returns(tags);

            var viewmodel = new RecipeViewModel(service.Object, new PlannedMealsService(), new IngredientsService());
            viewmodel.Initialize(recipeId);
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(recipeName));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(authorName));
                Assert.That(viewmodel.Tags, Is.EqualTo(tagsText));
                Assert.That(viewmodel.Description, Is.EqualTo(description));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(userRating));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(yourRating));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(ingredientsText));
                Assert.That(viewmodel.Instructions, Is.EqualTo(instructionsText));

                service.Verify(mock => mock.GetRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetStepsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetTypesForRecipe(recipeId), Times.Once);
            });
        }

        [Test]
        public void InitializeWithNoInstructions()
        {
            const int recipeId = 0;
            const string recipeName = "name";
            const string authorName = "first last";
            const string tagsText = "breakfast\nlunch";
            const string description = "description";
            const string ingredientsText = "ingredient 1 - 1 ml\ningredient 2 - 2 g";
            const string instructionsText = RecipeViewModel.NoInstructionsMessage;
            const string userRating = "User Rating: 0/5";
            const string yourRating = "Your Rating: 0/5";

            var recipe = new Recipe(recipeId, authorName, recipeName, description, false);
            var ingredients = new Ingredient[] {
                new("ingredient 1", 1, MeasurementType.Volume),
                new("ingredient 2", 2, MeasurementType.Mass),
            };
            var instructions = Array.Empty<RecipeStep>();
            var tags = new[] {
                "breakfast",
                "lunch"
            };

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipe(recipeId)).Returns(recipe);
            service.Setup(mock => mock.GetIngredientsForRecipe(recipeId)).Returns(ingredients);
            service.Setup(mock => mock.GetStepsForRecipe(recipeId)).Returns(instructions);
            service.Setup(mock => mock.GetTypesForRecipe(recipeId)).Returns(tags);

            var viewmodel = new RecipeViewModel(service.Object, new PlannedMealsService(), new IngredientsService());
            viewmodel.Initialize(recipeId);
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(recipeName));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(authorName));
                Assert.That(viewmodel.Tags, Is.EqualTo(tagsText));
                Assert.That(viewmodel.Description, Is.EqualTo(description));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(userRating));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(yourRating));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(ingredientsText));
                Assert.That(viewmodel.Instructions, Is.EqualTo(instructionsText));

                service.Verify(mock => mock.GetRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetStepsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetTypesForRecipe(recipeId), Times.Once);
            });
        }
        
        [Test]
        public void InitializeWithNoTypes()
        {
            const int recipeId = 0;
            const string recipeName = "name";
            const string authorName = "first last";
            const string description = "description";
            const string tagsText = RecipeViewModel.NoTagsMessage;
            const string ingredientsText = "ingredient 1 - 1 ml\ningredient 2 - 2 g";
            const string instructionsText = "1: name 1\ninstructions 1\n\n2: name 2\ninstructions 2";
            const string userRating = "User Rating: 0/5";
            const string yourRating = "Your Rating: 0/5";

            var recipe = new Recipe(recipeId, authorName, recipeName, description, false);
            var ingredients = new Ingredient[] {
                new("ingredient 1", 1, MeasurementType.Volume),
                new("ingredient 2", 2, MeasurementType.Mass),
            };
            var instructions = new RecipeStep[] {
                new(1, "name 1", "instructions 1"),
                new(2, "name 2", "instructions 2")
            };
            var tags = Array.Empty<string>();

            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipe(recipeId)).Returns(recipe);
            service.Setup(mock => mock.GetIngredientsForRecipe(recipeId)).Returns(ingredients);
            service.Setup(mock => mock.GetStepsForRecipe(recipeId)).Returns(instructions);
            service.Setup(mock => mock.GetTypesForRecipe(recipeId)).Returns(tags);

            var viewmodel = new RecipeViewModel(service.Object, new PlannedMealsService(), new IngredientsService());
            viewmodel.Initialize(recipeId);
            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.RecipeName, Is.EqualTo(recipeName));
                Assert.That(viewmodel.AuthorName, Is.EqualTo(authorName));
                Assert.That(viewmodel.Tags, Is.EqualTo(tagsText));
                Assert.That(viewmodel.Description, Is.EqualTo(description));
                Assert.That(viewmodel.UserRatingText, Is.EqualTo(userRating));
                Assert.That(viewmodel.YourRatingText, Is.EqualTo(yourRating));
                Assert.That(viewmodel.Ingredients, Is.EqualTo(ingredientsText));
                Assert.That(viewmodel.Instructions, Is.EqualTo(instructionsText));

                service.Verify(mock => mock.GetRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetIngredientsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetStepsForRecipe(recipeId), Times.Once);
                service.Verify(mock => mock.GetTypesForRecipe(recipeId), Times.Once);
            });
        }
    }
}
