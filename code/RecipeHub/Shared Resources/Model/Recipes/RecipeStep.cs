using System.Text.Json.Serialization;

namespace Shared_Resources.Model.Recipes
{
    /// <summary>
    /// Represents a single step for a recipe.
    /// </summary>
    public struct RecipeStep
    {
        /// <summary>
        /// The number of the step in a list of steps.
        /// </summary>
        [JsonPropertyName("stepNumber")]
        public int StepNumber { get; set; }

        /// <summary>
        /// The name for the step.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The instructions for the step.
        /// </summary>
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        /// <summary>
        /// Creates a default instance of <see cref="RecipeStep"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.StepNumber == 0<br/>
        /// &amp;&amp; this.Name == string.Empty<br/>
        /// &amp;&amp; this.Instructions == string.empty
        /// </summary>
        public RecipeStep()
        {
            this.StepNumber = 0;
            this.Name = string.Empty;
            this.Instructions = string.Empty;
        }

        /// <summary>
        /// Creates an instance of <see cref="RecipeStep"/> with a specified step number, name, and instructions.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>this.StepNumber == stepNumber<br/>
        /// &amp;&amp; this.Name == name<br/>
        /// &amp;&amp; this.Instructions == instructions
        /// </summary>
        /// <param name="stepNumber">The number of the step.</param>
        /// <param name="name">The name of the step</param>
        /// <param name="instructions">The instructions for the step.</param>
        public RecipeStep(int stepNumber, string name, string instructions)
        {
            this.StepNumber = stepNumber;
            this.Name = name;
            this.Instructions = instructions;
        }
    }
}