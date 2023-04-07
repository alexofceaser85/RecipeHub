using Desktop_Client.View.Components.Ingredients;
using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.ShoppingList;
using Shared_Resources.Model.Ingredients;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class ShoppingListScreen : Screen
    {
        private readonly ShoppingListViewModel viewmodel;

        /// <summary>
        /// Creates a default instance of <see cref="ShoppingListScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public ShoppingListScreen()
        {
            this.InitializeComponent();

            this.viewmodel = new ShoppingListViewModel();
            this.BindComponents();
            this.viewmodel.GetShoppingList();
        }

        private void BindComponents()
        {
            this.viewmodel.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName != nameof(this.viewmodel.ShoppingList))
                {
                    return;
                }

                this.PopulateShoppingList(this.viewmodel.ShoppingList);
            };
        }

        private void PopulateShoppingList(Ingredient[] ingredients)
        {
            this.ClearShoppingList();
            if (ingredients.Length == 0)
            {
                this.shoppingListTablePanel.Controls.Add(this.emptyListLabel);
                return;
            }
            foreach (var ingredient in ingredients)
            {
                var listItem = new ShoppingListItem(ingredient);

                this.shoppingListTablePanel.Controls.Add(listItem);
                this.shoppingListTablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
            
            //Adds an empty label to the bottom of the list to prevent the last ingredient from expanding vertically
            this.shoppingListTablePanel.Controls.Add(new Label(){Margin = Padding.Empty, Padding = Padding.Empty});
            this.shoppingListTablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void ClearShoppingList()
        {
            this.shoppingListTablePanel.Controls.Clear();
            this.shoppingListTablePanel.RowStyles.Clear();
        }

        private void hamburgerButton_MouseClick(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.viewmodel.ShoppingList.Length == 0)
            {
                DisplayDialog(new MessageDialog("Shopping List Empty", "Your shopping list is empty."));
                return;
            }

            var dialog = new MessageDialog("Add to Pantry",
                "Are you sure you wish to add your shopping list to your pantry?", MessageBoxButtons.YesNo);
            dialog.DialogClosed += (_, _) =>
            {
                if (dialog.Exception is UnauthorizedAccessException)
                {
                    base.DisplayTimeOutDialog();
                    return;
                }
                if (dialog.Exception != null)
                {
                    base.DisplayDialog(new MessageDialog("Error Occurred", dialog.Exception.Message));
                    return;
                }
                if (dialog.DialogResult != DialogResult.Yes)
                {
                    return;
                }

                var ingredients = new List<Ingredient>();
                foreach (var control in this.shoppingListTablePanel.Controls)
                {
                    if (control is not ShoppingListItem listItem)
                    {
                        continue;
                    }

                    ingredients.Add(new Ingredient(listItem.IngredientName, listItem.Quantity, MeasurementType.Quantity));
                }
                this.viewmodel.AddIngredientsToPantry(ingredients.ToArray());
                this.viewmodel.GetShoppingList();
            };

            base.DisplayDialog(dialog);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeScreens(new PlannedMealsScreen());
            }
            catch (UnauthorizedAccessException exception)
            {
                this.DisplayTimeOutDialog(exception.Message);
            }
        }
    }
}