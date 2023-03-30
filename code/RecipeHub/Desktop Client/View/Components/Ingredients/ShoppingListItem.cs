using System.Text;
using Shared_Resources.Model.Ingredients;
using Shared_Resources.Utils.Units;

namespace Desktop_Client.View.Components.Ingredients
{
    /// <summary>
    /// An item to display on a list of ingredients
    /// </summary>
    public partial class ShoppingListItem : UserControl
    {
        /// <summary>
        /// The name of the ingredient.
        /// </summary>
        public string IngredientName { get; }

        /// <summary>
        /// The desired quantity for the ingredient.
        /// </summary>
        public int Quantity => int.Parse(this.quantityTextBox.Text);

        /// <summary>
        /// Creates an instance of <see cref="ShoppingListItem"/> with a specified <see cref="Ingredient"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None
        /// <b>Postcondition: </b>this.Ingredient == ingredient<br/>
        /// &amp;&amp; ingredient's information is displayed on the IngredientListItem.
        /// </summary>
        /// <param name="ingredient">The ingredient to display.</param>
        public ShoppingListItem(Ingredient ingredient)
        {
            this.InitializeComponent();

            this.ingredientNameLabel.Text = ingredient.Name;
            this.IngredientName = ingredient.Name;
            this.quantityTextBox.Text = ingredient.Amount.ToString();
            this.unitLabel.Text = BaseUnitUtils.GetBaseUnitSign(ingredient.MeasurementType);
            this.Dock = DockStyle.Fill;
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            var sb = new StringBuilder(this.quantityTextBox.Text.Length);
            foreach (var character in this.quantityTextBox.Text.Where(char.IsAsciiDigit))
            {
                sb.Append(character);
            }
            this.quantityTextBox.Text = sb.ToString();
        }
    }
}
