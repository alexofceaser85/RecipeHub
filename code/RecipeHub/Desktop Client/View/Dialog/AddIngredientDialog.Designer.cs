namespace Desktop_Client.View.Dialog
{
    partial class AddIngredientDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addIngredient1 = new Desktop_Client.View.Components.Ingredient.AddIngredient();
            this.SuspendLayout();
            // 
            // addIngredient1
            // 
            this.addIngredient1.Location = new System.Drawing.Point(2, 0);
            this.addIngredient1.Name = "addIngredient1";
            this.addIngredient1.Size = new System.Drawing.Size(386, 251);
            this.addIngredient1.TabIndex = 0;
            // 
            // AddIngredientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 253);
            this.Controls.Add(this.addIngredient1);
            this.Name = "AddIngredientDialog";
            this.Text = "AddIngredientDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.Ingredient.AddIngredient addIngredient1;
    }
}