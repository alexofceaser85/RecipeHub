namespace Desktop_Client.View.Components.Recipes
{
    partial class RecipeListItem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.tagsPlaceholderLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tagsPlaceholderLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 146);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.91623F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.08377F));
            this.tableLayoutPanel2.Controls.Add(this.recipeNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.authorNameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ratingLabel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(764, 90);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeNameLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.recipeNameLabel.Location = new System.Drawing.Point(3, 0);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(574, 45);
            this.recipeNameLabel.TabIndex = 0;
            this.recipeNameLabel.Text = "Recipe Name";
            this.recipeNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.recipeNameLabel.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.authorNameLabel.Location = new System.Drawing.Point(3, 45);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(574, 45);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Author Name";
            this.authorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.authorNameLabel.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ratingLabel.Location = new System.Drawing.Point(583, 0);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(178, 45);
            this.ratingLabel.TabIndex = 2;
            this.ratingLabel.Text = "Rating: 0/5";
            this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ratingLabel.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // tagsPlaceholderLabel
            // 
            this.tagsPlaceholderLabel.AutoSize = true;
            this.tagsPlaceholderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tagsPlaceholderLabel.Location = new System.Drawing.Point(3, 96);
            this.tagsPlaceholderLabel.Name = "tagsPlaceholderLabel";
            this.tagsPlaceholderLabel.Size = new System.Drawing.Size(113, 50);
            this.tagsPlaceholderLabel.TabIndex = 1;
            this.tagsPlaceholderLabel.Text = "Tags go here";
            this.tagsPlaceholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tagsPlaceholderLabel.Click += new System.EventHandler(this.childControlMouseClick);
            // 
            // RecipeListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(0, 158);
            this.Name = "RecipeListItem";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(782, 158);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label recipeNameLabel;
        private Label authorNameLabel;
        private Label ratingLabel;
        private Label tagsPlaceholderLabel;
    }
}
