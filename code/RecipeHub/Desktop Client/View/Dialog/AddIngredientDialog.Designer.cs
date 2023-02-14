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
            this.cancelButton = new System.Windows.Forms.Button();
            this.addIngredientButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.measurementComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(82, 256);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.cancelButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(228, 44);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addIngredientButton
            // 
            this.addIngredientButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.addIngredientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.addIngredientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIngredientButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addIngredientButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addIngredientButton.Location = new System.Drawing.Point(82, 198);
            this.addIngredientButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.addIngredientButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.addIngredientButton.Name = "addIngredientButton";
            this.addIngredientButton.Size = new System.Drawing.Size(228, 44);
            this.addIngredientButton.TabIndex = 15;
            this.addIngredientButton.Text = "Add Ingredient";
            this.addIngredientButton.UseVisualStyleBackColor = false;
            this.addIngredientButton.Click += new System.EventHandler(this.addIngredientButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "Measurement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(64, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(82, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // measurementComboBox
            // 
            this.measurementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.measurementComboBox.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.measurementComboBox.FormattingEnabled = true;
            this.measurementComboBox.Location = new System.Drawing.Point(151, 154);
            this.measurementComboBox.Name = "measurementComboBox";
            this.measurementComboBox.Size = new System.Drawing.Size(216, 34);
            this.measurementComboBox.TabIndex = 11;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.amountTextBox.Location = new System.Drawing.Point(151, 97);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(216, 33);
            this.amountTextBox.TabIndex = 10;
            this.amountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amountTextBox_KeyPress);
            // 
            // nameComboBox
            // 
            this.nameComboBox.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(151, 21);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(216, 34);
            this.nameComboBox.TabIndex = 9;
            this.nameComboBox.TextChanged += new System.EventHandler(this.nameComboBox_TextChanged);
            // 
            // AddIngredientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 309);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addIngredientButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.measurementComboBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.nameComboBox);
            this.Name = "AddIngredientDialog";
            this.Text = "AddIngredientDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cancelButton;
        private Button addIngredientButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox measurementComboBox;
        private TextBox amountTextBox;
        private ComboBox nameComboBox;
    }
}