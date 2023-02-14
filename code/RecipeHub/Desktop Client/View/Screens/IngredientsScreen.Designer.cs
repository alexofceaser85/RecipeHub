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
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.removeAllIngredientsButton = new System.Windows.Forms.Button();
            this.hamburgerButton1 = new Desktop_Client.View.Components.General.HamburgerButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // addIngredientButton
            // 
            this.addIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addIngredientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.addIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredientButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addIngredientButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addIngredientButton.Location = new System.Drawing.Point(219, 85);
            this.addIngredientButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.addIngredientButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(228, 0);
            this.addIngredientButton.TabIndex = 5;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = false;
            // 
            // removeAllIngredientsButton
            // 
            this.removeAllIngredientsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.removeAllIngredientsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.removeAllIngredientsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAllIngredientsButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.removeAllIngredientsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.removeAllIngredientsButton.Location = new System.Drawing.Point(123, 722);
            this.removeAllIngredientsButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.removeAllIngredientsButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.removeAllIngredientsButton.Name = "removeAllIngredientsButton";
            this.removeAllIngredientsButton.Size = new System.Drawing.Size(228, 37);
            this.removeAllIngredientsButton.TabIndex = 6;
            this.removeAllIngredientsButton.Text = "Remove All";
            this.removeAllIngredientsButton.UseVisualStyleBackColor = false;
            // 
            // hamburgerButton1
            // 
            this.hamburgerButton1.Location = new System.Drawing.Point(356, 2);
            this.hamburgerButton1.Name = "hamburgerButton1";
            this.hamburgerButton1.Size = new System.Drawing.Size(100, 85);
            this.hamburgerButton1.TabIndex = 7;
            this.hamburgerButton1.Click += new System.EventHandler(this.hamburgerButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(467, 552);
            this.dataGridView1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 87);
            this.button1.TabIndex = 9;
            this.button1.Text = "<";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IngredientsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userMenu1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.hamburgerButton1);
            this.Controls.Add(this.removeAllIngredientsButton);
            this.Controls.Add(this.addIngredientButton);
            this.Name = "IngredientsScreen";
            this.Text = "IngredientsScreen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.General.UserMenu userMenu1;
        private Button addIngredientButton;
        private Button removeAllIngredientsButton;
        private Components.General.HamburgerButton hamburgerButton1;
        private DataGridView dataGridView1;
        private Button button1;
    }
}