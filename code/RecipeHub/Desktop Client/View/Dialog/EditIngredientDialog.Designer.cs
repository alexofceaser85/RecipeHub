namespace Desktop_Client.View.Dialog
{
    partial class EditIngredientDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editIngredientButton = new System.Windows.Forms.Button();
            this.editTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(39, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Amount";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountTextBox.Location = new System.Drawing.Point(126, 81);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(216, 33);
            this.amountTextBox.TabIndex = 14;
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(81, 258);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.cancelButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(228, 44);
            this.cancelButton.TabIndex = 18;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editIngredientButton
            // 
            this.editIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.editIngredientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.editIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editIngredientButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editIngredientButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editIngredientButton.Location = new System.Drawing.Point(81, 200);
            this.editIngredientButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.editIngredientButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.editIngredientButton.Name = "editIngredientButton";
            this.editIngredientButton.Size = new System.Drawing.Size(228, 44);
            this.editIngredientButton.TabIndex = 17;
            this.editIngredientButton.Text = "Edit Ingredient";
            this.editIngredientButton.UseVisualStyleBackColor = false;
            this.editIngredientButton.Click += new System.EventHandler(this.editIngredientButton_Click);
            // 
            // editTitle
            // 
            this.editTitle.AutoSize = true;
            this.editTitle.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.editTitle.Location = new System.Drawing.Point(169, 27);
            this.editTitle.Name = "editTitle";
            this.editTitle.Size = new System.Drawing.Size(45, 26);
            this.editTitle.TabIndex = 19;
            this.editTitle.Text = "Edit";
            // 
            // EditIngredientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 309);
            this.Controls.Add(this.editTitle);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editIngredientButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.amountTextBox);
            this.Name = "EditIngredientDialog";
            this.Text = "EditIngredientDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private TextBox amountTextBox;
        private Button cancelButton;
        private Button editIngredientButton;
        private Label editTitle;
    }
}