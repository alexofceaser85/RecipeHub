using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared_Resources.Model.Recipes
{
    public class RecipeStep
    {
        [JsonPropertyName("stepNumber")]
        public int StepNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        public RecipeStep(int stepNumber, string name, string instructions)
        {
            this.StepNumber = stepNumber;
            this.Name = name;
            this.Instructions = instructions;
        }
    }
}
