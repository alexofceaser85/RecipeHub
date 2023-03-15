namespace Desktop_Client.View.Components.PlannedMeals
{
    partial class PlannedMealListItem
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
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dinnerPanel = new System.Windows.Forms.Panel();
            this.dinnerTable = new System.Windows.Forms.TableLayoutPanel();
            this.dinnerLabel = new System.Windows.Forms.Label();
            this.noDinnerPlannedLabel = new System.Windows.Forms.Label();
            this.lunchPanel = new System.Windows.Forms.Panel();
            this.lunchTable = new System.Windows.Forms.TableLayoutPanel();
            this.lunchLabel = new System.Windows.Forms.Label();
            this.noLunchPlannedLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.breakfastPanel = new System.Windows.Forms.Panel();
            this.breakfastTable = new System.Windows.Forms.TableLayoutPanel();
            this.breakfastLabel = new System.Windows.Forms.Label();
            this.noPlannedBreakfastLabel = new System.Windows.Forms.Label();
            this.mainTableLayout.SuspendLayout();
            this.dinnerPanel.SuspendLayout();
            this.dinnerTable.SuspendLayout();
            this.lunchPanel.SuspendLayout();
            this.lunchTable.SuspendLayout();
            this.breakfastPanel.SuspendLayout();
            this.breakfastTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.AutoSize = true;
            this.mainTableLayout.ColumnCount = 1;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.dinnerPanel, 0, 3);
            this.mainTableLayout.Controls.Add(this.lunchPanel, 0, 2);
            this.mainTableLayout.Controls.Add(this.titleLabel, 0, 0);
            this.mainTableLayout.Controls.Add(this.breakfastPanel, 0, 1);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 4;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTableLayout.Size = new System.Drawing.Size(651, 568);
            this.mainTableLayout.TabIndex = 0;
            // 
            // dinnerPanel
            // 
            this.dinnerPanel.AutoSize = true;
            this.dinnerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dinnerPanel.Controls.Add(this.dinnerTable);
            this.dinnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dinnerPanel.Location = new System.Drawing.Point(3, 403);
            this.dinnerPanel.Name = "dinnerPanel";
            this.dinnerPanel.Size = new System.Drawing.Size(645, 162);
            this.dinnerPanel.TabIndex = 4;
            // 
            // dinnerTable
            // 
            this.dinnerTable.AutoSize = true;
            this.dinnerTable.ColumnCount = 1;
            this.dinnerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dinnerTable.Controls.Add(this.dinnerLabel, 0, 0);
            this.dinnerTable.Controls.Add(this.noDinnerPlannedLabel, 0, 1);
            this.dinnerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dinnerTable.Location = new System.Drawing.Point(0, 0);
            this.dinnerTable.Name = "dinnerTable";
            this.dinnerTable.RowCount = 2;
            this.dinnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.dinnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dinnerTable.Size = new System.Drawing.Size(643, 160);
            this.dinnerTable.TabIndex = 0;
            // 
            // dinnerLabel
            // 
            this.dinnerLabel.AutoSize = true;
            this.dinnerLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dinnerLabel.Location = new System.Drawing.Point(3, 0);
            this.dinnerLabel.Name = "dinnerLabel";
            this.dinnerLabel.Size = new System.Drawing.Size(157, 59);
            this.dinnerLabel.TabIndex = 1;
            this.dinnerLabel.Text = "Dinner";
            // 
            // noDinnerPlannedLabel
            // 
            this.noDinnerPlannedLabel.AutoSize = true;
            this.noDinnerPlannedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noDinnerPlannedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noDinnerPlannedLabel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noDinnerPlannedLabel.ForeColor = System.Drawing.Color.Blue;
            this.noDinnerPlannedLabel.Location = new System.Drawing.Point(0, 59);
            this.noDinnerPlannedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.noDinnerPlannedLabel.Name = "noDinnerPlannedLabel";
            this.noDinnerPlannedLabel.Padding = new System.Windows.Forms.Padding(0, 32, 0, 32);
            this.noDinnerPlannedLabel.Size = new System.Drawing.Size(643, 101);
            this.noDinnerPlannedLabel.TabIndex = 2;
            this.noDinnerPlannedLabel.Text = "No Planned Recipes";
            this.noDinnerPlannedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lunchPanel
            // 
            this.lunchPanel.AutoSize = true;
            this.lunchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lunchPanel.Controls.Add(this.lunchTable);
            this.lunchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lunchPanel.Location = new System.Drawing.Point(3, 235);
            this.lunchPanel.Name = "lunchPanel";
            this.lunchPanel.Size = new System.Drawing.Size(645, 162);
            this.lunchPanel.TabIndex = 3;
            // 
            // lunchTable
            // 
            this.lunchTable.AutoSize = true;
            this.lunchTable.ColumnCount = 1;
            this.lunchTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lunchTable.Controls.Add(this.lunchLabel, 0, 0);
            this.lunchTable.Controls.Add(this.noLunchPlannedLabel, 0, 1);
            this.lunchTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lunchTable.Location = new System.Drawing.Point(0, 0);
            this.lunchTable.Name = "lunchTable";
            this.lunchTable.RowCount = 2;
            this.lunchTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.lunchTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lunchTable.Size = new System.Drawing.Size(643, 160);
            this.lunchTable.TabIndex = 0;
            // 
            // lunchLabel
            // 
            this.lunchLabel.AutoSize = true;
            this.lunchLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lunchLabel.Location = new System.Drawing.Point(3, 0);
            this.lunchLabel.Name = "lunchLabel";
            this.lunchLabel.Size = new System.Drawing.Size(140, 59);
            this.lunchLabel.TabIndex = 1;
            this.lunchLabel.Text = "Lunch";
            // 
            // noLunchPlannedLabel
            // 
            this.noLunchPlannedLabel.AutoSize = true;
            this.noLunchPlannedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noLunchPlannedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noLunchPlannedLabel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noLunchPlannedLabel.ForeColor = System.Drawing.Color.Blue;
            this.noLunchPlannedLabel.Location = new System.Drawing.Point(0, 59);
            this.noLunchPlannedLabel.Margin = new System.Windows.Forms.Padding(0);
            this.noLunchPlannedLabel.Name = "noLunchPlannedLabel";
            this.noLunchPlannedLabel.Padding = new System.Windows.Forms.Padding(0, 32, 0, 32);
            this.noLunchPlannedLabel.Size = new System.Drawing.Size(643, 101);
            this.noLunchPlannedLabel.TabIndex = 2;
            this.noLunchPlannedLabel.Text = "No Planned Recipes";
            this.noLunchPlannedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(645, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Day of Week (Date)";
            // 
            // breakfastPanel
            // 
            this.breakfastPanel.AutoSize = true;
            this.breakfastPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.breakfastPanel.Controls.Add(this.breakfastTable);
            this.breakfastPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.breakfastPanel.Location = new System.Drawing.Point(3, 67);
            this.breakfastPanel.Name = "breakfastPanel";
            this.breakfastPanel.Size = new System.Drawing.Size(645, 162);
            this.breakfastPanel.TabIndex = 2;
            // 
            // breakfastTable
            // 
            this.breakfastTable.AutoSize = true;
            this.breakfastTable.ColumnCount = 1;
            this.breakfastTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.breakfastTable.Controls.Add(this.breakfastLabel, 0, 0);
            this.breakfastTable.Controls.Add(this.noPlannedBreakfastLabel, 0, 1);
            this.breakfastTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.breakfastTable.Location = new System.Drawing.Point(0, 0);
            this.breakfastTable.Name = "breakfastTable";
            this.breakfastTable.RowCount = 2;
            this.breakfastTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.breakfastTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.breakfastTable.Size = new System.Drawing.Size(643, 160);
            this.breakfastTable.TabIndex = 0;
            // 
            // breakfastLabel
            // 
            this.breakfastLabel.AutoSize = true;
            this.breakfastLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.breakfastLabel.Location = new System.Drawing.Point(3, 0);
            this.breakfastLabel.Name = "breakfastLabel";
            this.breakfastLabel.Size = new System.Drawing.Size(207, 59);
            this.breakfastLabel.TabIndex = 1;
            this.breakfastLabel.Text = "Breakfast";
            // 
            // noPlannedBreakfastLabel
            // 
            this.noPlannedBreakfastLabel.AutoSize = true;
            this.noPlannedBreakfastLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noPlannedBreakfastLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noPlannedBreakfastLabel.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noPlannedBreakfastLabel.ForeColor = System.Drawing.Color.Blue;
            this.noPlannedBreakfastLabel.Location = new System.Drawing.Point(0, 59);
            this.noPlannedBreakfastLabel.Margin = new System.Windows.Forms.Padding(0);
            this.noPlannedBreakfastLabel.Name = "noPlannedBreakfastLabel";
            this.noPlannedBreakfastLabel.Padding = new System.Windows.Forms.Padding(0, 32, 0, 32);
            this.noPlannedBreakfastLabel.Size = new System.Drawing.Size(643, 101);
            this.noPlannedBreakfastLabel.TabIndex = 2;
            this.noPlannedBreakfastLabel.Text = "No Planned Recipes";
            this.noPlannedBreakfastLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlannedMealListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.mainTableLayout);
            this.Name = "PlannedMealListItem";
            this.Size = new System.Drawing.Size(651, 568);
            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.dinnerPanel.ResumeLayout(false);
            this.dinnerPanel.PerformLayout();
            this.dinnerTable.ResumeLayout(false);
            this.dinnerTable.PerformLayout();
            this.lunchPanel.ResumeLayout(false);
            this.lunchPanel.PerformLayout();
            this.lunchTable.ResumeLayout(false);
            this.lunchTable.PerformLayout();
            this.breakfastPanel.ResumeLayout(false);
            this.breakfastPanel.PerformLayout();
            this.breakfastTable.ResumeLayout(false);
            this.breakfastTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private Label titleLabel;
        private Label breakfastLabel;
        private Panel breakfastPanel;
        private TableLayoutPanel breakfastTable;
        private Label noPlannedBreakfastLabel;
        private Panel dinnerPanel;
        private TableLayoutPanel dinnerTable;
        private Label dinnerLabel;
        private Label noDinnerPlannedLabel;
        private Panel lunchPanel;
        private TableLayoutPanel lunchTable;
        private Label lunchLabel;
        private Label noLunchPlannedLabel;
    }
}
