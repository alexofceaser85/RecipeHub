namespace Desktop_Client.View.Components.General
{
    partial class UserMenu
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.ingredientsNavbarOption = new System.Windows.Forms.Button();
            this.logoutNavbarOption = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Gray;
            this.menuPanel.Controls.Add(this.logoutNavbarOption);
            this.menuPanel.Controls.Add(this.ingredientsNavbarOption);
            this.menuPanel.Location = new System.Drawing.Point(0, 3);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(467, 633);
            this.menuPanel.TabIndex = 1;
            // 
            // ingredientsNavbarOption
            // 
            this.ingredientsNavbarOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ingredientsNavbarOption.BackColor = System.Drawing.Color.Gray;
            this.ingredientsNavbarOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingredientsNavbarOption.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ingredientsNavbarOption.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ingredientsNavbarOption.Location = new System.Drawing.Point(3, 0);
            this.ingredientsNavbarOption.Name = "ingredientsNavbarOption";
            this.ingredientsNavbarOption.Size = new System.Drawing.Size(464, 53);
            this.ingredientsNavbarOption.TabIndex = 0;
            this.ingredientsNavbarOption.Text = "Ingredients";
            this.ingredientsNavbarOption.UseVisualStyleBackColor = false;
            this.ingredientsNavbarOption.Click += new System.EventHandler(this.ingredientsNavbarOption_Click);
            // 
            // logoutNavbarOption
            // 
            this.logoutNavbarOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.logoutNavbarOption.BackColor = System.Drawing.Color.Gray;
            this.logoutNavbarOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutNavbarOption.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logoutNavbarOption.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logoutNavbarOption.Location = new System.Drawing.Point(3, 577);
            this.logoutNavbarOption.Name = "logoutNavbarOption";
            this.logoutNavbarOption.Size = new System.Drawing.Size(464, 53);
            this.logoutNavbarOption.TabIndex = 1;
            this.logoutNavbarOption.Text = "Logout";
            this.logoutNavbarOption.UseVisualStyleBackColor = false;
            this.logoutNavbarOption.Click += new System.EventHandler(this.logoutNavbarOption_Click);
            // 
            // UserMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuPanel);
            this.Name = "UserMenu";
            this.Size = new System.Drawing.Size(467, 639);
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel menuPanel;
        private Button ingredientsNavbarOption;
        private Button logoutNavbarOption;
    }
}
