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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hamburgerButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.recipieNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.recipeListTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.userRatingLabel = new System.Windows.Forms.Label();
            this.yourRatingLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.tabsPlaceholderLabel = new System.Windows.Forms.Label();
            this.ingredientsListLabel = new System.Windows.Forms.Label();
            this.stepsLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pevImageButton = new System.Windows.Forms.Button();
            this.nextImageButton = new System.Windows.Forms.Button();
            this.mainLayoutPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.recipeListTablePanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
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
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
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
            this.topBar.Size = new System.Drawing.Size(673, 143);
            this.topBar.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.hamburgerButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(667, 137);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // hamburgerButton
            // 
            this.hamburgerButton.BackColor = System.Drawing.Color.Transparent;
            this.hamburgerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hamburgerButton.Font = new System.Drawing.Font("Segoe UI Black", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hamburgerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.hamburgerButton.Location = new System.Drawing.Point(502, 3);
            this.hamburgerButton.Name = "hamburgerButton";
            this.hamburgerButton.Size = new System.Drawing.Size(162, 131);
            this.hamburgerButton.TabIndex = 2;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(169, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 131);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // recipieNameLabel
            // 
            this.recipieNameLabel.AutoSize = true;
            this.recipieNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipieNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipieNameLabel.Location = new System.Drawing.Point(3, 0);
            this.recipieNameLabel.Name = "recipieNameLabel";
            this.recipieNameLabel.Size = new System.Drawing.Size(321, 65);
            this.recipieNameLabel.TabIndex = 0;
            this.recipieNameLabel.Text = "Recipe Name";
            this.recipieNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.authorNameLabel.Location = new System.Drawing.Point(3, 65);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(321, 66);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Author Name";
            this.authorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(160, 131);
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
            this.recipeListTablePanel.Location = new System.Drawing.Point(20, 162);
            this.recipeListTablePanel.Name = "recipeListTablePanel";
            this.recipeListTablePanel.RowCount = 1;
            this.recipeListTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.recipeListTablePanel.Size = new System.Drawing.Size(673, 1150);
            this.recipeListTablePanel.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(665, 1142);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.descriptionLabel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tabsPlaceholderLabel, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.ingredientsListLabel, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.stepsLabel, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.commentsLabel, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 366);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(653, 770);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.userRatingLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.yourRatingLabel, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(645, 77);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // userRatingLabel
            // 
            this.userRatingLabel.AutoSize = true;
            this.userRatingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userRatingLabel.Location = new System.Drawing.Point(3, 0);
            this.userRatingLabel.Name = "userRatingLabel";
            this.userRatingLabel.Size = new System.Drawing.Size(639, 38);
            this.userRatingLabel.TabIndex = 0;
            this.userRatingLabel.Text = "User Ratings: 0/5";
            this.userRatingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yourRatingLabel
            // 
            this.yourRatingLabel.AutoSize = true;
            this.yourRatingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yourRatingLabel.Location = new System.Drawing.Point(3, 38);
            this.yourRatingLabel.Name = "yourRatingLabel";
            this.yourRatingLabel.Size = new System.Drawing.Size(639, 39);
            this.yourRatingLabel.TabIndex = 1;
            this.yourRatingLabel.Text = "Your Rating: 0/5";
            this.yourRatingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLabel.Location = new System.Drawing.Point(4, 85);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(645, 106);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "This is the description for the recipe.";
            // 
            // tabsPlaceholderLabel
            // 
            this.tabsPlaceholderLabel.AutoSize = true;
            this.tabsPlaceholderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsPlaceholderLabel.Location = new System.Drawing.Point(4, 192);
            this.tabsPlaceholderLabel.Name = "tabsPlaceholderLabel";
            this.tabsPlaceholderLabel.Size = new System.Drawing.Size(645, 93);
            this.tabsPlaceholderLabel.TabIndex = 2;
            this.tabsPlaceholderLabel.Text = "Tags go here";
            // 
            // ingredientsListLabel
            // 
            this.ingredientsListLabel.AutoSize = true;
            this.ingredientsListLabel.Location = new System.Drawing.Point(4, 286);
            this.ingredientsListLabel.Name = "ingredientsListLabel";
            this.ingredientsListLabel.Size = new System.Drawing.Size(101, 25);
            this.ingredientsListLabel.TabIndex = 3;
            this.ingredientsListLabel.Text = "Ingredients";
            // 
            // stepsLabel
            // 
            this.stepsLabel.AutoSize = true;
            this.stepsLabel.Location = new System.Drawing.Point(4, 476);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(55, 25);
            this.stepsLabel.TabIndex = 4;
            this.stepsLabel.Text = "Steps";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(4, 696);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(99, 25);
            this.commentsLabel.TabIndex = 5;
            this.commentsLabel.Text = "Comments";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.Controls.Add(this.pevImageButton, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.nextImageButton, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(659, 354);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // pevImageButton
            // 
            this.pevImageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pevImageButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pevImageButton.Location = new System.Drawing.Point(11, 11);
            this.pevImageButton.Name = "pevImageButton";
            this.pevImageButton.Size = new System.Drawing.Size(74, 332);
            this.pevImageButton.TabIndex = 0;
            this.pevImageButton.Text = "<";
            this.pevImageButton.UseVisualStyleBackColor = true;
            // 
            // nextImageButton
            // 
            this.nextImageButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nextImageButton.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nextImageButton.Location = new System.Drawing.Point(573, 11);
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(75, 332);
            this.nextImageButton.TabIndex = 1;
            this.nextImageButton.Text = ">";
            this.nextImageButton.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label userRatingLabel;
        private Label yourRatingLabel;
        private Label descriptionLabel;
        private Label tabsPlaceholderLabel;
        private Button pevImageButton;
        private Button nextImageButton;
        private Label ingredientsListLabel;
        private Label stepsLabel;
        private Label commentsLabel;
        private Button hamburgerButton;
    }
}
