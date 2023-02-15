namespace Desktop_Client.View.Components.Ingredient
{
    partial class IngredientForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.removeAllIngredientsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 78);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(667, 938);
            this.dataGridView1.TabIndex = 9;
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addIngredientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.addIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredientButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addIngredientButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addIngredientButton.Location = new System.Drawing.Point(358, 0);
            this.addIngredientButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.addIngredientButton.MaximumSize = new System.Drawing.Size(429, 0);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(326, 75);
            this.addIngredientButton.TabIndex = 10;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = false;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // removeAllIngredientsButton
            // 
            this.removeAllIngredientsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.removeAllIngredientsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.removeAllIngredientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAllIngredientsButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeAllIngredientsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.removeAllIngredientsButton.Location = new System.Drawing.Point(168, 1033);
            this.removeAllIngredientsButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.removeAllIngredientsButton.MaximumSize = new System.Drawing.Size(429, 0);
            this.removeAllIngredientsButton.Name = "removeAllIngredientsButton";
            this.removeAllIngredientsButton.Size = new System.Drawing.Size(326, 298);
            this.removeAllIngredientsButton.TabIndex = 11;
            this.removeAllIngredientsButton.Text = "Remove All";
            this.removeAllIngredientsButton.UseVisualStyleBackColor = false;
            this.removeAllIngredientsButton.Click += new System.EventHandler(this.removeAllIngredientsButton_Click);
            // 
            // IngredientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeAllIngredientsButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IngredientForm";
            this.Size = new System.Drawing.Size(1220, 1395);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button addIngredientButton;
        private Button removeAllIngredientsButton;
    }
}
