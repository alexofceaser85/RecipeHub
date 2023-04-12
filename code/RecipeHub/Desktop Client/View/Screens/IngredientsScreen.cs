using Desktop_Client.View.Dialog;
using Desktop_Client.ViewModel.Ingredients;
using Shared_Resources.Model.Ingredients;
using Desktop_Client.View.Components.Ingredients;
using System;

namespace Desktop_Client.View.Screens
{
    /// <summary>
    /// The base class for all screens for the application.<br/>
    /// Should not be created directly and should only be extended from.
    /// </summary>
    public partial class IngredientsScreen : Screen
    {
        private readonly IngredientsViewModel viewModel;

        /// <summary>
        /// Creates a default instance of <see cref="IngredientsScreen"/>.<br/>
        /// <br/>
        /// <b>Precondition: </b>None<br/>
        /// <b>Postcondition: </b>None
        /// </summary>
        public IngredientsScreen()
        {
            this.InitializeComponent();
            
            this.viewModel = new IngredientsViewModel();
            this.BindComponents();
            this.DelayGettingIngredients();
        }

        private async void DelayGettingIngredients()
        {
            await Task.Delay(100);
            this.viewModel.GetAllIngredientsForUser();
        }

        private void BindComponents()
        {
            this.removeAllButton.DataBindings.Add(new Binding("Enabled", this.viewModel,
                nameof(this.viewModel.RemoveAllButtonEnabled)));
            this.viewModel.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName != nameof(this.viewModel.Ingredients))
                {
                    return;
                }

                this.PopulateIngredientsList(this.viewModel.Ingredients);
            };
        }

        private void PopulateIngredientsList(ICollection<Ingredient> ingredients)
        {
            this.ingredientListTableLayout.Controls.Clear();

            if (ingredients.Count == 0)
            {
                this.ingredientListTableLayout.Controls.Add(this.noIngredientsLabel);
                this.AdjustScroll();
                return;
            }
            foreach (var ingredient in ingredients)
            {
                var item = new IngredientListItem(ingredient);
                this.ingredientListTableLayout.Controls.Add(item);
                this.ingredientListTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
                item.EditSelected += (_, selectedIngredient) =>
                {
                    var dialog = new EditIngredientDialog(selectedIngredient);

                    dialog.DialogClosed += (_, _) =>
                    {
                        if (dialog.Exception is UnauthorizedAccessException exception)
                        {
                            base.DisplayTimeOutDialog(exception.Message);
                        }
                        else if (dialog.Exception != null)
                        {
                            var messageDialog =
                                new MessageDialog("Error occurred", dialog.Exception.Message, MessageBoxButtons.OK);
                            base.DisplayDialog(messageDialog);
                        }
                        else if (dialog.DialogResult == DialogResult.OK)
                        {
                            this.viewModel.GetAllIngredientsForUser();
                        }
                    };

                    base.DisplayDialog(dialog);
                };
                item.RemoveSelected += (_, selectedIngredient) =>
                {
                    var ingredientName = selectedIngredient.Name;
                    var dialog = new MessageDialog("Remove ingredient",
                        $"Are you sure that you want to remove {ingredientName} from your pantry?",
                        MessageBoxButtons.YesNo);

                    dialog.DialogClosed += (_, _) =>
                    {
                        if (dialog.Exception is UnauthorizedAccessException exception)
                        {
                            base.DisplayTimeOutDialog(exception.Message);
                        }
                        else if (dialog.Exception != null)
                        {
                            var messageDialog =
                                new MessageDialog("Error occurred", dialog.Exception.Message);
                            base.DisplayDialog(messageDialog);
                        }
                        else if (dialog.DialogResult == DialogResult.Yes)
                        {
                            this.viewModel.RemoveIngredient(selectedIngredient);
                            this.viewModel.GetAllIngredientsForUser();
                            this.AdjustScroll();
                        }
                    };

                    base.DisplayDialog(dialog);
                };
            }
            this.AdjustScroll();
        }
        
        private void AdjustScroll()
        {
            // Reset row styles
            this.ingredientListTableLayout.RowStyles.Clear();
            for (int i = 0; i < this.ingredientListTableLayout.RowCount; i++)
            {
                this.ingredientListTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // Recalculate row heights
            this.ingredientListTableLayout.AutoScroll = false;
            this.ingredientListTableLayout.AutoScroll = true;
        }
        
        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            base.ToggleHamburgerMenu();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                base.ChangeScreens(new RecipeListScreen());
            }
            catch (ArgumentException exception)
            {
                var messageDialog =
                    new MessageDialog("Error occurred", exception.Message);
                base.DisplayDialog(messageDialog);
            }
            catch (UnauthorizedAccessException exception)
            {
                this.DisplayTimeOutDialog(exception.Message);
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            var dialog = new AddIngredientDialog();

            dialog.DialogClosed += (o, args) =>
            {
                if (dialog.Exception is UnauthorizedAccessException exception)
                {
                    base.DisplayTimeOutDialog(exception.Message);
                }
                else if (dialog.Exception != null)
                {
                    var messageDialog =
                        new MessageDialog("Error occurred", dialog.Exception.Message);
                    base.DisplayDialog(messageDialog);
                }
                else if (dialog.DialogResult == DialogResult.OK)
                {
                    this.viewModel.GetAllIngredientsForUser();
                }
            };

            base.DisplayDialog(dialog);
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            var dialog = new MessageDialog("Remove all ingredients",
                "Are you sure that you want to remove all ingredients?", MessageBoxButtons.YesNo);

            dialog.DialogClosed += (o, args) =>
            {
                if (dialog.Exception is UnauthorizedAccessException exception)
                {
                    base.DisplayTimeOutDialog(exception.Message);
                }
                else if (dialog.Exception != null)
                {
                    var messageDialog =
                        new MessageDialog("Error occurred", dialog.Exception.Message);
                    base.DisplayDialog(messageDialog);
                }
                else if (dialog.DialogResult == DialogResult.Yes)
                {
                    this.viewModel.RemoveAllIngredients();
                    this.viewModel.GetAllIngredientsForUser();
                    this.AdjustScroll();
                }
            };

            base.DisplayDialog(dialog);
        }
    }
}