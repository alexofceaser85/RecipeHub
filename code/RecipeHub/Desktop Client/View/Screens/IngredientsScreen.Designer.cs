namespace Desktop_Client.View.Screens
{
    partial class IngredientsScreen
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
            this.userMenu1 = new Desktop_Client.View.Components.General.UserMenu();
            this.hamburgerButton1 = new Desktop_Client.View.Components.General.HamburgerButton();
            this.backButton = new System.Windows.Forms.Button();
            this.ingredientForm1 = new Desktop_Client.View.Components.Ingredient.IngredientForm();
            this.SuspendLayout();
            // 
            // userMenu1
            // 
            this.userMenu1.Location = new System.Drawing.Point(1, 93);
            this.userMenu1.Name = "userMenu1";
            this.userMenu1.Size = new System.Drawing.Size(468, 666);
            this.userMenu1.TabIndex = 0;
            this.userMenu1.Visible = false;
            // 
            // hamburgerButton1
            // 
            this.hamburgerButton1.Location = new System.Drawing.Point(356, 2);
            this.hamburgerButton1.Name = "hamburgerButton1";
            this.hamburgerButton1.Size = new System.Drawing.Size(100, 85);
            this.hamburgerButton1.TabIndex = 7;
            this.hamburgerButton1.Click += new System.EventHandler(this.hamburgerButton1_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.Location = new System.Drawing.Point(1, 2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(126, 87);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "<";
            this.backButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ingredientForm1
            // 
            this.ingredientForm1.Location = new System.Drawing.Point(1, 91);
            this.ingredientForm1.Name = "ingredientForm1";
            this.ingredientForm1.Size = new System.Drawing.Size(468, 658);
            this.ingredientForm1.TabIndex = 10;
            // 
            // IngredientsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.userMenu1);
            this.Controls.Add(this.ingredientForm1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.hamburgerButton1);
            this.Name = "IngredientsScreen";
            this.Text = "IngredientsScreen";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.General.UserMenu userMenu1;
        private Components.General.HamburgerButton hamburgerButton1;
        private Button backButton;
        private Components.Ingredient.IngredientForm ingredientForm1;
    }
}