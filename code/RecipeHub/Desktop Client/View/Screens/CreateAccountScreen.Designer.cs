namespace Desktop_Client.View.Screens
{
    partial class CreateAccountScreen
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.createAccountForm = new Desktop_Client.View.Components.Login.CreateAccountForm();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.createAccountForm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CreateAccountButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 761);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // createAccountForm
            // 
            this.createAccountForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.createAccountForm.Location = new System.Drawing.Point(64, 211);
            this.createAccountForm.Name = "createAccountForm";
            this.createAccountForm.Size = new System.Drawing.Size(356, 338);
            this.createAccountForm.TabIndex = 0;
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CreateAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.CreateAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccountButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateAccountButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateAccountButton.Location = new System.Drawing.Point(92, 559);
            this.CreateAccountButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.CreateAccountButton.MaximumSize = new System.Drawing.Size(300, 0);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(300, 72);
            this.CreateAccountButton.TabIndex = 5;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = false;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // CreateAccountScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 761);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CreateAccountScreen";
            this.Text = "CreateAccountScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Components.Login.CreateAccountForm createAccountForm;
        private Button CreateAccountButton;
    }
}