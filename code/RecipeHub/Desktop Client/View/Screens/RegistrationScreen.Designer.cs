namespace Desktop_Client.View.Screens
{
    partial class RegistrationScreen
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
            this.createAccountForm = new Desktop_Client.View.Components.Login.CreateAccountForm();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.createAccountLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.createAccountForm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.createAccountLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(713, 1324);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // createAccountForm
            // 
            this.createAccountForm.AutoSize = true;
            this.createAccountForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.createAccountForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.createAccountForm.Location = new System.Drawing.Point(64, 96);
            this.createAccountForm.Margin = new System.Windows.Forms.Padding(64, 5, 64, 5);
            this.createAccountForm.Name = "createAccountForm";
            this.createAccountForm.Size = new System.Drawing.Size(585, 704);
            this.createAccountForm.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cancelButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CreateAccountButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 1179);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel2.MaximumSize = new System.Drawing.Size(800, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(705, 140);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(9, 12);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.cancelButton.MaximumSize = new System.Drawing.Size(429, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(333, 116);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.CreateAccountButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.CreateAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccountButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateAccountButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateAccountButton.Location = new System.Drawing.Point(362, 12);
            this.CreateAccountButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.CreateAccountButton.MaximumSize = new System.Drawing.Size(429, 0);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(333, 116);
            this.CreateAccountButton.TabIndex = 6;
            this.CreateAccountButton.Text = "Create Account";
            this.CreateAccountButton.UseVisualStyleBackColor = false;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // createAccountLabel
            // 
            this.createAccountLabel.AutoSize = true;
            this.createAccountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createAccountLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createAccountLabel.Location = new System.Drawing.Point(3, 0);
            this.createAccountLabel.Name = "createAccountLabel";
            this.createAccountLabel.Padding = new System.Windows.Forms.Padding(0, 16, 0, 16);
            this.createAccountLabel.Size = new System.Drawing.Size(707, 91);
            this.createAccountLabel.TabIndex = 2;
            this.createAccountLabel.Text = "Create Account";
            this.createAccountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistrationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RegistrationScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Components.Login.CreateAccountForm createAccountForm;
        private TableLayoutPanel tableLayoutPanel2;
        private Button cancelButton;
        private Button CreateAccountButton;
        private Label createAccountLabel;
    }
}
