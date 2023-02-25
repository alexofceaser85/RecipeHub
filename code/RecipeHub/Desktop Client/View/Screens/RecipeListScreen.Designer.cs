﻿namespace Desktop_Client.View.Screens
{
    partial class RecipeListScreen
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
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topBar = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filtersButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hamburgerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.recipeListTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainLayoutPanel.SuspendLayout();
            this.topBar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoScroll = true;
            this.mainLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.topBar, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.recipeListTablePanel, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.MaximumSize = new System.Drawing.Size(920, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(713, 1324);
            this.mainLayoutPanel.TabIndex = 0;
            this.mainLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainLayoutPanel_Paint);
            // 
            // topBar
            // 
            this.topBar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.topBar.ColumnCount = 1;
            this.topBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topBar.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.topBar.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topBar.Location = new System.Drawing.Point(20, 12);
            this.topBar.Name = "topBar";
            this.topBar.RowCount = 2;
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.topBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.topBar.Size = new System.Drawing.Size(673, 194);
            this.topBar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.filtersButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.searchTextBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 105);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 94);
            this.tableLayoutPanel1.TabIndex = 7;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // filtersButton
            // 
            this.filtersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.filtersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtersButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filtersButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.filtersButton.Location = new System.Drawing.Point(4, 22);
            this.filtersButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.filtersButton.MaximumSize = new System.Drawing.Size(429, 50);
            this.filtersButton.Name = "filtersButton";
            this.filtersButton.Size = new System.Drawing.Size(158, 50);
            this.filtersButton.TabIndex = 6;
            this.filtersButton.Text = "Filters";
            this.filtersButton.UseVisualStyleBackColor = false;
            this.filtersButton.Click += new System.EventHandler(this.filtersButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchTextBox.Location = new System.Drawing.Point(175, 23);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PlaceholderText = "Search Recipes by Name";
            this.searchTextBox.Size = new System.Drawing.Size(481, 47);
            this.searchTextBox.TabIndex = 7;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.hamburgerButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 94);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // hamburgerButton
            // 
            this.hamburgerButton.BackColor = System.Drawing.Color.Transparent;
            this.hamburgerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hamburgerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hamburgerButton.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.hamburgerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.hamburgerButton.Location = new System.Drawing.Point(569, 5);
            this.hamburgerButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hamburgerButton.Name = "hamburgerButton";
            this.hamburgerButton.Size = new System.Drawing.Size(92, 84);
            this.hamburgerButton.TabIndex = 4;
            this.hamburgerButton.Text = "☰";
            this.hamburgerButton.UseVisualStyleBackColor = false;
            this.hamburgerButton.Click += new System.EventHandler(this.hamburgerButton_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(103, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recipeListTablePanel
            // 
            this.recipeListTablePanel.AutoScroll = true;
            this.recipeListTablePanel.ColumnCount = 1;
            this.recipeListTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipeListTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipeListTablePanel.Location = new System.Drawing.Point(20, 213);
            this.recipeListTablePanel.Name = "recipeListTablePanel";
            this.recipeListTablePanel.RowCount = 1;
            this.recipeListTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1032F));
            this.recipeListTablePanel.Size = new System.Drawing.Size(673, 1099);
            this.recipeListTablePanel.TabIndex = 1;
            // 
            // RecipeListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "RecipeListScreen";
            this.mainLayoutPanel.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainLayoutPanel;
        private TableLayoutPanel topBar;
        private TableLayoutPanel recipeListTablePanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Button filtersButton;
        private TextBox searchTextBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Button hamburgerButton;
    }
}