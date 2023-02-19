using Shared_Resources.Model.Recipes;

namespace SharedResourcesTests.SharedResources.Model.Recipes.RecipeStepsTests;

public class ConstructorTests
{
    [Test]
    public void DefaultConstructor()
    {
        var step = new RecipeStep();
        Assert.Multiple(() =>
        {
            Assert.That(step.StepNumber, Is.EqualTo(0));
            Assert.That(step.Name, Is.EqualTo(string.Empty));
            Assert.That(step.Instructions, Is.EqualTo(string.Empty));
        });
    }

    [Test]
    public void ThreeParameterConstructor()
    {
        const int stepNumber = 1;
        const string name = "name";
        const string instructions = "instructions";

        var step = new RecipeStep(stepNumber, name, instructions);
        Assert.Multiple(() =>
        {
            Assert.That(step.StepNumber, Is.EqualTo(stepNumber));
            Assert.That(step.Name, Is.EqualTo(name));
            Assert.That(step.Instructions, Is.EqualTo(instructions));
        });
    }
}