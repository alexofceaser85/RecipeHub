using Desktop_Client.View.Components.General;

namespace Desktop_Client.View.Screens
{
    partial class RecipeScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topBar = new System.Windows.Forms.TableLayoutPanel();
            this.topBarTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.hamburgerButton = new System.Windows.Forms.Button();
            this.nameAuthorTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.recipieNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.recipeListTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.bodyTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.contentTablePanel = new Desktop_Client.View.Components.General.ScrollVisibleTableLayoutPanel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.tagsPlaceholderLabel = new System.Windows.Forms.Label();
            this.ingredientsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ingredientsListLabel = new System.Windows.Forms.Label();
            this.ingredientsTitleLabel = new System.Windows.Forms.Label();
            this.stepsTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.stepsTitleLabel = new System.Windows.Forms.Label();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.buttonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cookRecipeButton = new System.Windows.Forms.Button();
            this.addPlannedMealButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.topBarTableLayout.SuspendLayout();
            this.nameAuthorTableLayout.SuspendLayout();
            this.recipeListTablePanel.SuspendLayout();
            this.bodyTableLayout.SuspendLayout();
            this.contentTablePanel.SuspendLayout();
            this.ingredientsTableLayout.SuspendLayout();
            this.stepsTablePanel.SuspendLayout();
            this.buttonTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoScroll = true;
            this.mainLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.topBar, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.recipeListTablePanel, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.MaximumSize = new System.Drawing.Size(920, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(713, 1324);
            this.mainLayoutPanel.TabIndex = 1;
            // 
            // topBar
            // 
            this.topBar.ColumnCount = 1;
            this.topBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBar.Controls.Add(this.topBarTableLayout, 0, 0);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(20, 12);
            this.topBar.Name = "topBar";
            this.topBar.RowCount = 1;
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBar.Size = new System.Drawing.Size(673, 104);
            this.topBar.TabIndex = 0;
            // 
            // topBarTableLayout
            // 
            this.topBarTableLayout.ColumnCount = 3;
            this.topBarTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.topBarTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBarTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.topBarTableLayout.Controls.Add(this.hamburgerButton, 2, 0);
            this.topBarTableLayout.Controls.Add(this.nameAuthorTableLayout, 1, 0);
            this.topBarTableLayout.Controls.Add(this.backButton, 0, 0);
            this.topBarTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBarTableLayout.Location = new System.Drawing.Point(3, 3);
            this.topBarTableLayout.Name = "topBarTableLayout";
            this.topBarTableLayout.RowCount = 1;
            this.topBarTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBarTableLayout.Size = new System.Drawing.Size(667, 98);
            this.topBarTableLayout.TabIndex = 8;
            // 
            // hamburgerButton
            // 
            this.hamburgerButton.BackColor = System.Drawing.Color.Transparent;
            this.hamburgerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hamburgerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hamburgerButton.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hamburgerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.hamburgerButton.Location = new System.Drawing.Point(571, 5);
            this.hamburgerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hamburgerButton.Name = "hamburgerButton";
            this.hamburgerButton.Size = new System.Drawing.Size(92, 88);
            this.hamburgerButton.TabIndex = 5;
            this.hamburgerButton.Text = "☰";
            this.hamburgerButton.UseVisualStyleBackColor = false;
            this.hamburgerButton.Click += new System.EventHandler(this.hamburgerButton_Click);
            // 
            // nameAuthorTableLayout
            // 
            this.nameAuthorTableLayout.ColumnCount = 1;
            this.nameAuthorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameAuthorTableLayout.Controls.Add(this.recipieNameLabel, 0, 0);
            this.nameAuthorTableLayout.Controls.Add(this.authorNameLabel, 0, 1);
            this.nameAuthorTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameAuthorTableLayout.Location = new System.Drawing.Point(103, 3);
            this.nameAuthorTableLayout.Name = "nameAuthorTableLayout";
            this.nameAuthorTableLayout.RowCount = 2;
            this.nameAuthorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameAuthorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.nameAuthorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.nameAuthorTableLayout.Size = new System.Drawing.Size(461, 92);
            this.nameAuthorTableLayout.TabIndex = 0;
            // 
            // recipieNameLabel
            // 
            this.recipieNameLabel.AutoSize = true;
            this.recipieNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipieNameLabel.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.recipieNameLabel.Location = new System.Drawing.Point(3, 0);
            this.recipieNameLabel.Name = "recipieNameLabel";
            this.recipieNameLabel.Size = new System.Drawing.Size(455, 46);
            this.recipieNameLabel.TabIndex = 0;
            this.recipieNameLabel.Text = "Recipe Name";
            this.recipieNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.authorNameLabel.Location = new System.Drawing.Point(3, 46);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(455, 46);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Author Name";
            this.authorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 92);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // recipeListTablePanel
            // 
            this.recipeListTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.recipeListTablePanel.ColumnCount = 1;
            this.recipeListTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipeListTablePanel.Controls.Add(this.bodyTableLayout, 0, 0);
            this.recipeListTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeListTablePanel.Location = new System.Drawing.Point(20, 123);
            this.recipeListTablePanel.Name = "recipeListTablePanel";
            this.recipeListTablePanel.RowCount = 1;
            this.recipeListTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.recipeListTablePanel.Size = new System.Drawing.Size(673, 1189);
            this.recipeListTablePanel.TabIndex = 1;
            // 
            // bodyTableLayout
            // 
            this.bodyTableLayout.ColumnCount = 1;
            this.bodyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayout.Controls.Add(this.contentTablePanel, 0, 1);
            this.bodyTableLayout.Controls.Add(this.buttonTableLayout, 0, 0);
            this.bodyTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTableLayout.Location = new System.Drawing.Point(4, 4);
            this.bodyTableLayout.Name = "bodyTableLayout";
            this.bodyTableLayout.RowCount = 2;
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.bodyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTableLayout.Size = new System.Drawing.Size(665, 1181);
            this.bodyTableLayout.TabIndex = 0;
            // 
            // contentTablePanel
            // 
            this.contentTablePanel.AutoScroll = true;
            this.contentTablePanel.AutoSize = true;
            this.contentTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.contentTablePanel.ColumnCount = 1;
            this.contentTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTablePanel.Controls.Add(this.descriptionLabel, 0, 0);
            this.contentTablePanel.Controls.Add(this.tagsPlaceholderLabel, 0, 1);
            this.contentTablePanel.Controls.Add(this.ingredientsTableLayout, 0, 2);
            this.contentTablePanel.Controls.Add(this.stepsTablePanel, 0, 3);
            this.contentTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTablePanel.Location = new System.Drawing.Point(6, 70);
            this.contentTablePanel.Margin = new System.Windows.Forms.Padding(6);
            this.contentTablePanel.MaximumSize = new System.Drawing.Size(653, 1100);
            this.contentTablePanel.Name = "contentTablePanel";
            this.contentTablePanel.RowCount = 4;
            this.contentTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contentTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.contentTablePanel.Size = new System.Drawing.Size(653, 1100);
            this.contentTablePanel.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.Location = new System.Drawing.Point(4, 9);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(645, 27);
            this.descriptionLabel.TabIndex = 5;
            this.descriptionLabel.Text = "This is the description for the recipe.";
            // 
            // tagsPlaceholderLabel
            // 
            this.tagsPlaceholderLabel.AutoSize = true;
            this.tagsPlaceholderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsPlaceholderLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tagsPlaceholderLabel.Location = new System.Drawing.Point(4, 53);
            this.tagsPlaceholderLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.tagsPlaceholderLabel.Name = "tagsPlaceholderLabel";
            this.tagsPlaceholderLabel.Size = new System.Drawing.Size(645, 27);
            this.tagsPlaceholderLabel.TabIndex = 2;
            this.tagsPlaceholderLabel.Text = "Tags go here";
            // 
            // ingredientsTableLayout
            // 
            this.ingredientsTableLayout.AutoSize = true;
            this.ingredientsTableLayout.ColumnCount = 1;
            this.ingredientsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ingredientsTableLayout.Controls.Add(this.ingredientsListLabel, 0, 1);
            this.ingredientsTableLayout.Controls.Add(this.ingredientsTitleLabel, 0, 0);
            this.ingredientsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientsTableLayout.Location = new System.Drawing.Point(4, 92);
            this.ingredientsTableLayout.Name = "ingredientsTableLayout";
            this.ingredientsTableLayout.RowCount = 2;
            this.ingredientsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ingredientsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ingredientsTableLayout.Size = new System.Drawing.Size(645, 110);
            this.ingredientsTableLayout.TabIndex = 6;
            // 
            // ingredientsListLabel
            // 
            this.ingredientsListLabel.AutoSize = true;
            this.ingredientsListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientsListLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ingredientsListLabel.Location = new System.Drawing.Point(3, 75);
            this.ingredientsListLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.ingredientsListLabel.Name = "ingredientsListLabel";
            this.ingredientsListLabel.Size = new System.Drawing.Size(639, 27);
            this.ingredientsListLabel.TabIndex = 4;
            this.ingredientsListLabel.Text = "Ingredients";
            // 
            // ingredientsTitleLabel
            // 
            this.ingredientsTitleLabel.AutoSize = true;
            this.ingredientsTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ingredientsTitleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ingredientsTitleLabel.Location = new System.Drawing.Point(0, 8);
            this.ingredientsTitleLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 8);
            this.ingredientsTitleLabel.Name = "ingredientsTitleLabel";
            this.ingredientsTitleLabel.Size = new System.Drawing.Size(642, 59);
            this.ingredientsTitleLabel.TabIndex = 5;
            this.ingredientsTitleLabel.Text = "Ingredients";
            // 
            // stepsTablePanel
            // 
            this.stepsTablePanel.AutoSize = true;
            this.stepsTablePanel.ColumnCount = 1;
            this.stepsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.stepsTablePanel.Controls.Add(this.stepsTitleLabel, 0, 0);
            this.stepsTablePanel.Controls.Add(this.stepsLabel, 0, 1);
            this.stepsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsTablePanel.Location = new System.Drawing.Point(4, 209);
            this.stepsTablePanel.Name = "stepsTablePanel";
            this.stepsTablePanel.RowCount = 2;
            this.stepsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.stepsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.stepsTablePanel.Size = new System.Drawing.Size(645, 887);
            this.stepsTablePanel.TabIndex = 7;
            // 
            // stepsTitleLabel
            // 
            this.stepsTitleLabel.AutoSize = true;
            this.stepsTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsTitleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.stepsTitleLabel.Location = new System.Drawing.Point(0, 8);
            this.stepsTitleLabel.Margin = new System.Windows.Forms.Padding(0, 8, 3, 8);
            this.stepsTitleLabel.Name = "stepsTitleLabel";
            this.stepsTitleLabel.Size = new System.Drawing.Size(642, 59);
            this.stepsTitleLabel.TabIndex = 6;
            this.stepsTitleLabel.Text = "Steps";
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepsLabel.Location = new System.Drawing.Point(3, 75);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(639, 812);
            this.stepsLabel.TabIndex = 5;
            this.stepsLabel.Text = "Steps";
            // 
            // buttonTableLayout
            // 
            this.buttonTableLayout.ColumnCount = 2;
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.Controls.Add(this.cookRecipeButton, 1, 0);
            this.buttonTableLayout.Controls.Add(this.addPlannedMealButton, 0, 0);
            this.buttonTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTableLayout.Location = new System.Drawing.Point(3, 3);
            this.buttonTableLayout.Name = "buttonTableLayout";
            this.buttonTableLayout.RowCount = 1;
            this.buttonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayout.Size = new System.Drawing.Size(659, 58);
            this.buttonTableLayout.TabIndex = 2;
            // 
            // cookRecipeButton
            // 
            this.cookRecipeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cookRecipeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.cookRecipeButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cookRecipeButton.ForeColor = System.Drawing.Color.White;
            this.cookRecipeButton.Location = new System.Drawing.Point(354, 3);
            this.cookRecipeButton.MaximumSize = new System.Drawing.Size(280, 0);
            this.cookRecipeButton.Name = "cookRecipeButton";
            this.cookRecipeButton.Size = new System.Drawing.Size(280, 52);
            this.cookRecipeButton.TabIndex = 4;
            this.cookRecipeButton.Text = "Cook this Recipe";
            this.cookRecipeButton.UseVisualStyleBackColor = false;
            this.cookRecipeButton.Click += new System.EventHandler(this.cookRecipeButton_Click);
            // 
            // addPlannedMealButton
            // 
            this.addPlannedMealButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addPlannedMealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.addPlannedMealButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addPlannedMealButton.ForeColor = System.Drawing.Color.White;
            this.addPlannedMealButton.Location = new System.Drawing.Point(24, 3);
            this.addPlannedMealButton.MaximumSize = new System.Drawing.Size(280, 0);
            this.addPlannedMealButton.Name = "addPlannedMealButton";
            this.addPlannedMealButton.Size = new System.Drawing.Size(280, 52);
            this.addPlannedMealButton.TabIndex = 3;
            this.addPlannedMealButton.Text = "Add to Planned Meals";
            this.addPlannedMealButton.UseVisualStyleBackColor = false;
            this.addPlannedMealButton.Click += new System.EventHandler(this.addPlannedMeal_Click);
            // 
            // RecipeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.Name = "RecipeScreen";
            this.mainLayoutPanel.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.topBarTableLayout.ResumeLayout(false);
            this.nameAuthorTableLayout.ResumeLayout(false);
            this.nameAuthorTableLayout.PerformLayout();
            this.recipeListTablePanel.ResumeLayout(false);
            this.bodyTableLayout.ResumeLayout(false);
            this.bodyTableLayout.PerformLayout();
            this.contentTablePanel.ResumeLayout(false);
            this.contentTablePanel.PerformLayout();
            this.ingredientsTableLayout.ResumeLayout(false);
            this.ingredientsTableLayout.PerformLayout();
            this.stepsTablePanel.ResumeLayout(false);
            this.stepsTablePanel.PerformLayout();
            this.buttonTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainLayoutPanel;
        private TableLayoutPanel topBar;
        private TableLayoutPanel topBarTableLayout;
        private TableLayoutPanel recipeListTablePanel;
        private TableLayoutPanel nameAuthorTableLayout;
        private Label recipieNameLabel;
        private Label authorNameLabel;
        private Button backButton;
        private TableLayoutPanel bodyTableLayout;
        private ScrollVisibleTableLayoutPanel contentTablePanel;
        private Button hamburgerButton;
        private TableLayoutPanel buttonTableLayout;
        private Button cookRecipeButton;
        private Button addPlannedMealButton;
        private Label descriptionLabel;
        private TableLayoutPanel stepsTablePanel;
        private Label stepsTitleLabel;
        private Label stepsLabel;
        private Label tagsPlaceholderLabel;
        private TableLayoutPanel ingredientsTableLayout;
        private Label ingredientsListLabel;
        private Label ingredientsTitleLabel;
    }
}
