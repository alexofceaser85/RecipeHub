using Moq;
using Shared_Resources.Data.UserData;
using Shared_Resources.Model.Filters;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;
using Web_Client.Service.Ingredients;
using Web_Client.Service.Recipes;
using Web_Client.ViewModel.Recipes;

namespace WebClientTests.WebClient.ViewModel.Recipes.RecipeListViewModelTests
{
    public class GetRecipesTests
    {
        [Test]
        public void SuccessfullyGetUnfilteredRecipes()
        {
            Session.Key = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false),
                new(2, "author3 name3", "name3", "description3", false)
            };
            var service = new Mock<IRecipesService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);

            var viewmodel = new RecipesListViewModel(service.Object, new IngredientsService());
            viewmodel.Filters.MatchTags = null;
            viewmodel.Filters.OnlyAvailableIngredients = false;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyGetFilteredRecipes()
        {
            Session.Key = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void SuccessfullyFilterByOnlyAvailableIngredientsIfIngredientsAreNotOwned()
        {
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var owned = new Ingredient[] {
                new("Cherries", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(owned);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters = new RecipeFilters();
            viewmodel.Filters.OnlyAvailableIngredients = true;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(Array.Empty<Recipe>()));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void SuccessfullyFilterByOnlyAvailableIngredientsAllIngredientsAreOwned()
        {
            const string sessionKey = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var owned = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(owned);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters = new RecipeFilters();
            viewmodel.Filters.OnlyAvailableIngredients = true;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void SuccessfullyFilterByOnlyAvailableIngredientsSomeIngredientsAreOwned()
        {
            const string sessionKey = "Key";
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients1 = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var ingredients2 = new Ingredient[] {
                new("Cherries", 1, MeasurementType.Quantity),
                new("Apples", 1, MeasurementType.Quantity)
            };
            var owned = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients1);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients2);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(owned);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters = new RecipeFilters();
            viewmodel.Filters.OnlyAvailableIngredients = true;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(new[] { recipes[0] }));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void ShouldNotFilterRecipesIfMatchTagIsNull()
        {
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters.MatchTags = null!;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.GetRecipesForTags(It.IsAny<string[]>()), Times.Never);
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void ShouldNotFilterRecipesIfMatchTagIsEmpty()
        {
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters.MatchTags = new string[0];
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                recipesService.Verify(mock => mock.GetRecipesForTags(It.IsAny<string[]>()), Times.Never);
                Assert.That(result, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }

        [Test]
        public void ShouldGetRecipesForTags()
        {
            var tags = new string[] { "Tag1", "Tag2", "Tag3" };
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var expected = new[] { recipes[0] };
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetRecipesForTags(tags)).Returns(expected);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object);
            viewmodel.Filters.MatchTags = tags;
            var result = viewmodel.GetRecipes(searchTerm);

            Assert.Multiple(() =>
            {
                Assert.That(result[0], Is.EqualTo(expected[0]));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Exactly(2));
            });
        }
    }
}