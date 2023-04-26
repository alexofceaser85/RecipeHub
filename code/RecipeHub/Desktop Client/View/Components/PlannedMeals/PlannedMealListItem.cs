using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Resources.Model.PlannedMeals;
using Shared_Resources.Model.Recipes;

namespace Desktop_Client.View.Components.PlannedMeals
{
    /// <summary>
    /// An item to display in the planned meals list that contains all of the recipes for a given day.
    /// </summary>
    public partial class PlannedMealListItem : UserControl
    {
        private const string ExpandedCharacter = "V";
        private const string CollapsedCharacter = ">";

        private TableLayoutPanel[] mealTablePanels;
        private Label[] noMealsPlannedLabels;

        /// <summary>
        /// Creates an instance of <see cref="PlannedMealListItem"/> with a specified <see cref="PlannedMeal"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>All recipes in planned meal are listed, if any
        /// </summary>
        /// <param name="plannedMeals">The planned meal to display</param>
        /// <param name="tags">Key-value pairs for recipes and their tags.</param>
        public PlannedMealListItem(PlannedMeal plannedMeals, Dictionary<int, string[]> tags)
        {
            this.InitializeComponent();

            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.mealTablePanels = Array.Empty<TableLayoutPanel>();
            this.noMealsPlannedLabels = Array.Empty<Label>();
            this.PopulateControlArrays();

            this.titleLabel.Text = plannedMeals.MealDate.DayOfWeek.ToString();
            this.dateLabel.Text = plannedMeals.MealDate.ToShortDateString();
            this.PopulateRecipeList(plannedMeals, tags);
        }

        /// <summary>
        /// Occurs when the delete button is pressed on one of the recipes.
        /// </summary>
        public EventHandler<Tuple<PlannedRecipe, MealCategory>>? DeletePressed;
        
        /// <summary>
        /// Occurs when the view button is pressed on one of the recipes.
        /// </summary>
        public EventHandler<int>? ViewPressed;

        /// <summary>
        /// Occurs when the component's contents have either been collapsed or expanded
        /// </summary>
        public EventHandler? CollapseToggled;

        private void PopulateControlArrays()
        {

            this.mealTablePanels = new[] {
                this.breakfastTable,
                this.lunchTable,
                this.dinnerTable
            };
            this.noMealsPlannedLabels = new[] {
                this.noPlannedBreakfastLabel,
                this.noLunchPlannedLabel,
                this.noDinnerPlannedLabel
            };
        }

        private void PopulateRecipeList(PlannedMeal plannedMeals, Dictionary<int, string[]> tags)
        {
            bool[] mealHasRecipe = {
                false,
                false,
                false
            };

            foreach (var meal in plannedMeals.Meals)
            {
                if (meal.Recipes.Length == 0)
                {
                    continue;
                }

                var mealIndex = (int)meal.Category;
                if (!mealHasRecipe[mealIndex])
                {
                    this.mealTablePanels[mealIndex].Controls.RemoveAt(1);
                    mealHasRecipe[mealIndex] = true;
                }

                foreach (var plannedRecipe in meal.Recipes)
                {
                    var recipeTags = tags!.GetValueOrDefault(plannedRecipe.Recipe.Id, null);

                    var innerListItem = new PlannedMealRecipeListItem(plannedRecipe, recipeTags);
                    innerListItem.DeletePressed += (sender, _) =>
                    {
                        this.listItem_DeletePressed((sender as PlannedMealRecipeListItem)!, meal.Category);
                    };
                    innerListItem.ViewPressed += (_, _) => this.ViewPressed?.Invoke(this, plannedRecipe.Recipe.Id);
                    this.mealTablePanels[mealIndex].Controls.Add(innerListItem);
                }
            }
        }

        private void listItem_DeletePressed(PlannedMealRecipeListItem listItem, MealCategory category)
        {
            var recipe = listItem.PlannedRecipe;
            this.DeletePressed?.Invoke(this, new Tuple<PlannedRecipe, MealCategory>(recipe, category));
        }
        
        /// <summary>
        /// Removes a recipe from the planned meal using its id and category.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        /// <param name="recipeId">The id for the recipe</param>
        /// <param name="category">The meal category that the recipe is under</param>
        public void RemovePlannedMeal(int recipeId, MealCategory category)
        {
            var tableLayout = this.mealTablePanels[(int) category];
            for (var i = 1; i < tableLayout.Controls.Count; i++)
            {
                if (tableLayout.Controls[i] is not PlannedMealRecipeListItem listItem)
                {
                    continue;
                }

                if (listItem.PlannedRecipe.Recipe.Id != recipeId)
                {
                    continue;
                }

                tableLayout.Controls.RemoveAt(i);
                break;
            }

            if (tableLayout.Controls.Count == 1)
            {
                tableLayout.Controls.Add(this.noMealsPlannedLabels[(int) category]);
            }
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            this.mealsTableLayout.Visible = !this.mealsTableLayout.Visible;
            this.collapseButton.Text = this.mealsTableLayout.Visible ? ExpandedCharacter : CollapsedCharacter;
            this.CollapseToggled?.Invoke(this, EventArgs.Empty);
        }
    }
}
