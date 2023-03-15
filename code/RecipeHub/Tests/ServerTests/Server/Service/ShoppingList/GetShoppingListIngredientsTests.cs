using Moq;
using Server.DAL.Ingredients;
using Server.DAL.PlannedMeals;
using Server.DAL.Recipes;
using Server.DAL.Users;
using Server.ErrorMessages;
using Server.Service.ShoppingList;
using Shared_Resources.Model.Ingredients;

namespace ServerTests.Server.Service.ShoppingList
{
    public class GetShoppingListIngredientsTests
    {
        [Test]
        public void ShouldNotGetShoppingListIngredientsWithNullSessionKey()
        {
            var service = new ShoppingListService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = service.GetShoppingListIngredients(null!);
            })?.Message;
            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.SessionKeyCannotBeNull));
        }

        [Test]
        public void ShouldNotGetShoppingListIngredientsWithEmptySessionKey()
        {
            var service = new ShoppingListService();
            var message = Assert.Throws<ArgumentException>(() =>
            {
                _ = service.GetShoppingListIngredients("   ");
            })?.Message;
            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.SessionKeyCannotBeEmpty));
        }

        [Test]
        public void ShouldNotAllowInvalidSession()
        {
            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns((int?)null!);

            var message = Assert.Throws<UnauthorizedAccessException>(() =>
            {
                _ = service.GetShoppingListIngredients("key");
            })?.Message;

            Assert.That(message, Is.EqualTo(ShoppingListServiceErrorMessages.InvalidSessionKeyErrorMessage));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasNoIngredientsOrRecipes()
        {
            var expectedIngredients = new Ingredient[] { };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(new List<Ingredient>());
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new int[] { });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasNoRecipes()
        {
            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new int[]
            {

            };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(ingredients);
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new int[] { });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasNoIngredients()
        {
            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new[]
            {
                new Ingredient("Flour", 8, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 20, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity)
            };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(new List<Ingredient>());
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new [] {1,2,3});
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(new[] { ingredients[0], ingredients[1], ingredients[2] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(2))
                .Returns(new[] { ingredients[3], ingredients[4], ingredients[5] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(3))
                .Returns(new[] { ingredients[6], ingredients[7], ingredients[8] });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasSomeIngredients()
        {
            var userIngredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Oranges", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
            };

            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Water", 20, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity)
            };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(userIngredients);
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new[] { 1, 2, 3 });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(new[] { ingredients[0], ingredients[1], ingredients[2] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(2))
                .Returns(new[] { ingredients[3], ingredients[4], ingredients[5] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(3))
                .Returns(new[] { ingredients[6], ingredients[7], ingredients[8] });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasAllIngredientsInTooLittleQuantity()
        {
            var userIngredients = new[]
            {
                new Ingredient("Flour", 1, MeasurementType.Mass),
                new Ingredient("Peaches", 1, MeasurementType.Quantity),
                new Ingredient("Milk", 5, MeasurementType.Volume),
                new Ingredient("Apples", 1, MeasurementType.Quantity),
                new Ingredient("Water", 5, MeasurementType.Volume),
                new Ingredient("Chocolate", 1, MeasurementType.Mass),
                new Ingredient("StrawBerry", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 10, MeasurementType.Mass),
                new Ingredient("StrawBerry", 20, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new[]
            {
                new Ingredient("Flour", 7, MeasurementType.Mass),
                new Ingredient("Peaches", 1, MeasurementType.Quantity),
                new Ingredient("Milk", 5, MeasurementType.Volume),
                new Ingredient("Apples", 1, MeasurementType.Quantity),
                new Ingredient("Water", 15, MeasurementType.Volume),
                new Ingredient("Chocolate", 9, MeasurementType.Mass),
                new Ingredient("StrawBerry", 18, MeasurementType.Quantity)
            };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(userIngredients);
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new[] { 1, 2, 3 });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(new[] { ingredients[0], ingredients[1], ingredients[2] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(2))
                .Returns(new[] { ingredients[3], ingredients[4], ingredients[5] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(3))
                .Returns(new[] { ingredients[6], ingredients[7], ingredients[8] });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasAllIngredientsInExactQuantity()
        {
            var userIngredients = new[]
            {
                new Ingredient("Flour", 8, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Chocolate", 10, MeasurementType.Mass),
                new Ingredient("StrawBerry", 20, MeasurementType.Quantity),
                new Ingredient("Water", 20, MeasurementType.Volume)
            };

            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 10, MeasurementType.Mass),
                new Ingredient("StrawBerry", 20, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new Ingredient[] { };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(userIngredients);
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new[] { 1, 2, 3 });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(new[] { ingredients[0], ingredients[1], ingredients[2] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(2))
                .Returns(new[] { ingredients[3], ingredients[4], ingredients[5] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(3))
                .Returns(new[] { ingredients[6], ingredients[7], ingredients[8] });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }

        [Test]
        public void ShouldGetMissingIngredientsIfUserHasAllIngredientsInMoreThanEnoughQuantity()
        {
            var userIngredients = new[]
            {
                new Ingredient("Flour", 80, MeasurementType.Mass),
                new Ingredient("Peaches", 20, MeasurementType.Quantity),
                new Ingredient("Milk", 100, MeasurementType.Volume),
                new Ingredient("Apples", 20, MeasurementType.Quantity),
                new Ingredient("Chocolate", 100, MeasurementType.Mass),
                new Ingredient("StrawBerry", 200, MeasurementType.Quantity),
                new Ingredient("Water", 200, MeasurementType.Volume)
            };

            var ingredients = new[]
            {
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Peaches", 2, MeasurementType.Quantity),
                new Ingredient("Milk", 10, MeasurementType.Volume),
                new Ingredient("Flour", 4, MeasurementType.Mass),
                new Ingredient("Apples", 2, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume),
                new Ingredient("Chocolate", 10, MeasurementType.Mass),
                new Ingredient("StrawBerry", 20, MeasurementType.Quantity),
                new Ingredient("Water", 10, MeasurementType.Volume)
            };

            var expectedIngredients = new Ingredient[] { };

            var usersDal = new Mock<IUsersDal>();
            var plannedMealDal = new Mock<IPlannedMealsDal>();
            var ingredientsDal = new Mock<IIngredientsDal>();
            var recipesDal = new Mock<IRecipesDal>();

            var service = new ShoppingListService(usersDal.Object, plannedMealDal.Object, ingredientsDal.Object,
                recipesDal.Object);

            usersDal.Setup(mock => mock.GetIdForSessionKey("key")).Returns(1);
            ingredientsDal.Setup(mock => mock.GetIngredientsFor(1)).Returns(userIngredients);
            plannedMealDal.Setup(mock => mock.GetAllPlannedMealRecipes(1)).Returns(new[] { 1, 2, 3 });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(1)).Returns(new[] { ingredients[0], ingredients[1], ingredients[2] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(2))
                .Returns(new[] { ingredients[3], ingredients[4], ingredients[5] });
            recipesDal.Setup(mock => mock.GetIngredientsForRecipe(3))
                .Returns(new[] { ingredients[6], ingredients[7], ingredients[8] });

            var shoppingList = service.GetShoppingListIngredients("key");

            Assert.That(shoppingList, Is.EquivalentTo(expectedIngredients));
        }
    }
}
