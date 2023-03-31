namespace Desktop_Client.View.Screens
{
    partial class PlannedMealsScreen
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hamburgerButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.viewShoppingListButton = new System.Windows.Forms.Button();
            this.mealsListTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mealsListTableLayout, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(713, 1324);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.hamburgerButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.titleLabel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(675, 94);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // hamburgerButton
            // 
            this.hamburgerButton.BackColor = System.Drawing.Color.Transparent;
            this.hamburgerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hamburgerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hamburgerButton.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hamburgerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.hamburgerButton.Location = new System.Drawing.Point(579, 5);
            this.hamburgerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hamburgerButton.Name = "hamburgerButton";
            this.hamburgerButton.Size = new System.Drawing.Size(92, 84);
            this.hamburgerButton.TabIndex = 3;
            this.hamburgerButton.Text = "☰";
            this.hamburgerButton.UseVisualStyleBackColor = false;
            this.hamburgerButton.Click += new System.EventHandler(this.hamburgerButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 88);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(103, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(469, 94);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Planned Meals";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413F));
            this.tableLayoutPanel3.Controls.Add(this.viewShoppingListButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(19, 111);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(675, 94);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // viewShoppingListButton
            // 
            this.viewShoppingListButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.viewShoppingListButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewShoppingListButton.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.viewShoppingListButton.ForeColor = System.Drawing.Color.White;
            this.viewShoppingListButton.Location = new System.Drawing.Point(265, 3);
            this.viewShoppingListButton.Name = "viewShoppingListButton";
            this.viewShoppingListButton.Size = new System.Drawing.Size(407, 88);
            this.viewShoppingListButton.TabIndex = 3;
            this.viewShoppingListButton.Text = "Shopping List";
            this.viewShoppingListButton.UseVisualStyleBackColor = false;
            this.viewShoppingListButton.Click += new System.EventHandler(this.viewShoppingListButton_Click);
            // 
            // mealsListTableLayout
            // 
            this.mealsListTableLayout.AutoScroll = true;
            this.mealsListTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mealsListTableLayout.ColumnCount = 1;
            this.mealsListTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mealsListTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mealsListTableLayout.Location = new System.Drawing.Point(26, 218);
            this.mealsListTableLayout.Margin = new System.Windows.Forms.Padding(10);
            this.mealsListTableLayout.Name = "mealsListTableLayout";
            this.mealsListTableLayout.RowCount = 1;
            this.mealsListTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mealsListTableLayout.Size = new System.Drawing.Size(661, 1088);
            this.mealsListTableLayout.TabIndex = 2;
            // 
            // PlannedMealsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PlannedMealsScreen";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button backButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Button viewShoppingListButton;
        private Button hamburgerButton;
        private TableLayoutPanel mealsListTableLayout;
        private Label titleLabel;
    }
}
