﻿using Desktop_Client.Service.Ingredients;
using Desktop_Client.Service.Recipes;
using Desktop_Client.ViewModel.Recipes;
using Moq;
using Shared_Resources.Model.Filters;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Model.Recipes;

namespace DesktopClientTests.DesktopClient.ViewModel.Recipes.RecipesListViewModelTests
{
    public class GetRecipesTests
    {
        [SetUp]
        [TearDown]
        public void ResetFilters()
        {
            RecipesListViewModel.Filters = new RecipeFilters();
        }

        [Test]
        public void SuccessfullyGetUnfilteredRecipes()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false),
                new(2, "author3 name3", "name3", "description3", false)
            };
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyGetRecipesWithMatchingIngredients()
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

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                OnlyAvailableIngredients = true
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(0), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(1), Times.Once);
                ingredientsService.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
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

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters {
                OnlyAvailableIngredients = true
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(Array.Empty<Recipe>()));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(0), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(1), Times.Once);
                ingredientsService.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyFilterByOnlyAvailableIngredientsAllIngredientsAreOwned()
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
                new("Apples", 1, MeasurementType.Quantity)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(0)).Returns(ingredients);
            recipesService.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(ingredients);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(owned);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters {
                OnlyAvailableIngredients = true
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(0), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(1), Times.Once);
                ingredientsService.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
            });
        }

        [Test]
        public void SuccessfullyFilterByOnlyAvailableIngredientsSomeIngredientsAreOwned()
        {
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

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters {
                OnlyAvailableIngredients = true
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(new [] { recipes[0] }));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(0), Times.Once);
                recipesService.Verify(mock => mock.GetIngredientsForRecipe(1), Times.Once);
                ingredientsService.Verify(mock => mock.GetAllIngredientsForUser(), Times.Once);
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
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters= new RecipeFilters() {
                MatchTags = null
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipesForTags(It.IsAny<string[]>()), Times.Never);
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void ShouldNotFilterRecipesIfMatchTagIsEmpty()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "a";
            var recipes = new Recipe[] {
                new(0, "author1 name1", "name1", "description1", false),
                new(1, "author2 name2", "name2", "description2", false)
            };
            var recipesService = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            recipesService.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm,
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                MatchTags = Array.Empty<string>()
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                recipesService.Verify(mock => mock.GetRecipesForTags(It.IsAny<string[]>()), Times.Never);
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void ShouldGetRecipesForTags()
        {
            var tags = new [] { "Tag1", "Tag2", "Tag3" };
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
            recipesService.Setup(mock => mock.GetRecipesForTags(tags)).Returns(new[] { recipes[0] });
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(recipesService.Object, ingredientsService.Object) {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters(){
                MatchTags = tags
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(expected));
                recipesService.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void NoRecipesFoundWithoutFilters()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "";
            var recipes = Array.Empty<Recipe>();
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                OnlyAvailableIngredients = false
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                Assert.That(viewmodel.NoRecipesLabelText, Is.EqualTo(RecipesListViewModel.NoRecipesUploaded));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void NoRecipesFoundWithNameSearch()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "a";
            var recipes = Array.Empty<Recipe>();
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                OnlyAvailableIngredients = false
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                Assert.That(viewmodel.NoRecipesLabelText, Is.EqualTo(RecipesListViewModel.NoRecipesWithName));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void NoRecipesFoundWithTagSearch()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "";
            var recipes = Array.Empty<Recipe>();
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                OnlyAvailableIngredients = false,
                MatchTags = new[] {"a"}
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                Assert.That(viewmodel.NoRecipesLabelText, Is.EqualTo(RecipesListViewModel.NoRecipesWithTags));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void NoRecipesFoundWithOwnedIngredients()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string searchTerm = "a";
            var recipes = Array.Empty<Recipe>();
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Returns(recipes);
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };
            RecipesListViewModel.Filters = new RecipeFilters() {
                OnlyAvailableIngredients = true,
            };
            viewmodel.GetRecipes();

            Assert.Multiple(() =>
            {
                Assert.That(viewmodel.Recipes, Is.EqualTo(recipes));
                Assert.That(viewmodel.NoRecipesLabelText, Is.EqualTo(RecipesListViewModel.NoRecipesWithOwnedIngredients));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }
        
        [Test]
        public void UnsuccessfullyGetRecipes()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string errorMessage = "error message";
            const string searchTerm = "";
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Throws(new Exception(errorMessage));
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<Exception>(() => viewmodel.GetRecipes())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }

        [Test]
        public void InvalidSessionKey()
        {
            var ingredients = new Ingredient[] {
                new("Apples", 1, MeasurementType.Quantity)
            };
            const string errorMessage = "error message";
            const string searchTerm = "";
            var service = new Mock<IRecipesService>();
            var ingredientsService = new Mock<IIngredientsService>();
            service.Setup(mock => mock.GetRecipes(searchTerm)).Throws(new UnauthorizedAccessException(errorMessage));
            ingredientsService.Setup(mock => mock.GetAllIngredientsForUser()).Returns(ingredients);

            var viewmodel = new RecipesListViewModel(service.Object, ingredientsService.Object)
            {
                SearchTerm = searchTerm
            };

            Assert.Multiple(() =>
            {
                var message = Assert.Throws<UnauthorizedAccessException>(() => viewmodel.GetRecipes())!.Message;
                Assert.That(message, Is.EqualTo(errorMessage));
                service.Verify(mock => mock.GetRecipes(searchTerm), Times.Once);
            });
        }
    }
}