﻿namespace Desktop_Client.View.Screens
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hamburgerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recipieNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.recipeListTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.tagsPlaceholderLabel = new System.Windows.Forms.Label();
            this.ingredientsListLabel = new System.Windows.Forms.Label();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.buttonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cookRecipeButton = new System.Windows.Forms.Button();
            this.addPlannedMealButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.recipeListTablePanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.topBar.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(20, 12);
            this.topBar.Name = "topBar";
            this.topBar.RowCount = 1;
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBar.Size = new System.Drawing.Size(673, 104);
            this.topBar.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.hamburgerButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(667, 98);
            this.tableLayoutPanel2.TabIndex = 8;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.recipieNameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.authorNameLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(103, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(461, 92);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.recipeListTablePanel.AutoScroll = true;
            this.recipeListTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.recipeListTablePanel.ColumnCount = 1;
            this.recipeListTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipeListTablePanel.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.recipeListTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeListTablePanel.Location = new System.Drawing.Point(20, 123);
            this.recipeListTablePanel.Name = "recipeListTablePanel";
            this.recipeListTablePanel.RowCount = 1;
            this.recipeListTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.recipeListTablePanel.Size = new System.Drawing.Size(673, 1189);
            this.recipeListTablePanel.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonTableLayout, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(665, 1181);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.descriptionLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tagsPlaceholderLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.ingredientsListLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.stepsLabel, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 70);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(653, 1105);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.Location = new System.Drawing.Point(4, 1);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(645, 27);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "This is the description for the recipe.";
            // 
            // tagsPlaceholderLabel
            // 
            this.tagsPlaceholderLabel.AutoSize = true;
            this.tagsPlaceholderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsPlaceholderLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tagsPlaceholderLabel.Location = new System.Drawing.Point(4, 29);
            this.tagsPlaceholderLabel.Name = "tagsPlaceholderLabel";
            this.tagsPlaceholderLabel.Size = new System.Drawing.Size(645, 27);
            this.tagsPlaceholderLabel.TabIndex = 2;
            this.tagsPlaceholderLabel.Text = "Tags go here";
            // 
            // ingredientsListLabel
            // 
            this.ingredientsListLabel.AutoSize = true;
            this.ingredientsListLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ingredientsListLabel.Location = new System.Drawing.Point(4, 57);
            this.ingredientsListLabel.Name = "ingredientsListLabel";
            this.ingredientsListLabel.Size = new System.Drawing.Size(115, 27);
            this.ingredientsListLabel.TabIndex = 3;
            this.ingredientsListLabel.Text = "Ingredients";
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stepsLabel.Location = new System.Drawing.Point(4, 85);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(61, 27);
            this.stepsLabel.TabIndex = 4;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.recipeListTablePanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.buttonTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainLayoutPanel;
        private TableLayoutPanel topBar;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel recipeListTablePanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label recipieNameLabel;
        private Label authorNameLabel;
        private Button backButton;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label descriptionLabel;
        private Label tagsPlaceholderLabel;
        private Label ingredientsListLabel;
        private Label stepsLabel;
        private Button hamburgerButton;
        private TableLayoutPanel buttonTableLayout;
        private Button cookRecipeButton;
        private Button addPlannedMealButton;
    }
}
