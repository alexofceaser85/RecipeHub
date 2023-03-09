namespace Desktop_Client.View.Components.PlannedMeals
{
    partial class PlannedMealRecipeListItem
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.recipeNameLabel = new System.Windows.Forms.Label();
            this.authorNameLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.04309F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.95691F));
            this.tableLayoutPanel2.Controls.Add(this.recipeNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.authorNameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ratingLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.removeButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tagsLabel, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(555, 148);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // recipeNameLabel
            // 
            this.recipeNameLabel.AutoSize = true;
            this.recipeNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeNameLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.recipeNameLabel.Location = new System.Drawing.Point(3, 0);
            this.recipeNameLabel.Name = "recipeNameLabel";
            this.recipeNameLabel.Size = new System.Drawing.Size(371, 43);
            this.recipeNameLabel.TabIndex = 0;
            this.recipeNameLabel.Text = "Recipe Name";
            this.recipeNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // authorNameLabel
            // 
            this.authorNameLabel.AutoSize = true;
            this.authorNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.authorNameLabel.Location = new System.Drawing.Point(3, 43);
            this.authorNameLabel.Name = "authorNameLabel";
            this.authorNameLabel.Size = new System.Drawing.Size(371, 43);
            this.authorNameLabel.TabIndex = 1;
            this.authorNameLabel.Text = "Author Name";
            this.authorNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ratingLabel.Location = new System.Drawing.Point(380, 0);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(172, 43);
            this.ratingLabel.TabIndex = 2;
            this.ratingLabel.Text = "Rating: 0/5";
            this.ratingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeButton.Location = new System.Drawing.Point(380, 63);
            this.removeButton.MaximumSize = new System.Drawing.Size(0, 64);
            this.removeButton.Name = "removeButton";
            this.tableLayoutPanel2.SetRowSpan(this.removeButton, 2);
            this.removeButton.Size = new System.Drawing.Size(172, 64);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsLabel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tagsLabel.Location = new System.Drawing.Point(3, 86);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(371, 62);
            this.tagsLabel.TabIndex = 4;
            this.tagsLabel.Text = "No tags...";
            // 
            // PlannedMealRecipeListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(0, 148);
            this.Name = "PlannedMealRecipeListItem";
            this.Size = new System.Drawing.Size(555, 148);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Label recipeNameLabel;
        private Label authorNameLabel;
        private Label ratingLabel;
        private Button removeButton;
        private Label tagsLabel;
    }
}
