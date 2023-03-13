namespace Desktop_Client.View.Dialog
{
    partial class AddPlannedMealDialog
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
            this.mainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.inputTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.dateLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.buttonTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mainTablePanel.SuspendLayout();
            this.inputTablePanel.SuspendLayout();
            this.buttonTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTablePanel
            // 
            this.mainTablePanel.ColumnCount = 1;
            this.mainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTablePanel.Controls.Add(this.titleLabel, 0, 0);
            this.mainTablePanel.Controls.Add(this.inputTablePanel, 0, 1);
            this.mainTablePanel.Controls.Add(this.buttonTablePanel, 0, 2);
            this.mainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.mainTablePanel.Name = "mainTablePanel";
            this.mainTablePanel.RowCount = 3;
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.mainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.mainTablePanel.Size = new System.Drawing.Size(604, 350);
            this.mainTablePanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(16, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(16, 0, 3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(585, 59);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Add to Planned Meals";
            // 
            // inputTablePanel
            // 
            this.inputTablePanel.ColumnCount = 1;
            this.inputTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTablePanel.Controls.Add(this.dateLabel, 0, 0);
            this.inputTablePanel.Controls.Add(this.categoryLabel, 0, 2);
            this.inputTablePanel.Controls.Add(this.dateComboBox, 0, 1);
            this.inputTablePanel.Controls.Add(this.categoryComboBox, 0, 3);
            this.inputTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTablePanel.Location = new System.Drawing.Point(96, 62);
            this.inputTablePanel.Margin = new System.Windows.Forms.Padding(96, 3, 96, 3);
            this.inputTablePanel.Name = "inputTablePanel";
            this.inputTablePanel.RowCount = 4;
            this.inputTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inputTablePanel.Size = new System.Drawing.Size(412, 192);
            this.inputTablePanel.TabIndex = 1;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.Location = new System.Drawing.Point(3, 0);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(406, 39);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.categoryLabel.Location = new System.Drawing.Point(3, 96);
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(406, 39);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Category";
            // 
            // dateComboBox
            // 
            this.dateComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(3, 50);
            this.dateComboBox.MaxDropDownItems = 7;
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(406, 33);
            this.dateComboBox.TabIndex = 2;
            this.dateComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.dateComboBox_Format);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(3, 146);
            this.categoryComboBox.MaxDropDownItems = 7;
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(406, 33);
            this.categoryComboBox.TabIndex = 3;
            // 
            // buttonTablePanel
            // 
            this.buttonTablePanel.ColumnCount = 2;
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTablePanel.Controls.Add(this.submitButton, 0, 0);
            this.buttonTablePanel.Controls.Add(this.cancelButton, 0, 0);
            this.buttonTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTablePanel.Location = new System.Drawing.Point(3, 260);
            this.buttonTablePanel.Name = "buttonTablePanel";
            this.buttonTablePanel.RowCount = 1;
            this.buttonTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTablePanel.Size = new System.Drawing.Size(598, 87);
            this.buttonTablePanel.TabIndex = 2;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(315, 16);
            this.submitButton.Margin = new System.Windows.Forms.Padding(16);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(267, 55);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.cancelButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(16, 16);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(16);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(267, 55);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddPlannedMealDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTablePanel);
            this.Name = "AddPlannedMealDialog";
            this.Size = new System.Drawing.Size(604, 350);
            this.mainTablePanel.ResumeLayout(false);
            this.mainTablePanel.PerformLayout();
            this.inputTablePanel.ResumeLayout(false);
            this.inputTablePanel.PerformLayout();
            this.buttonTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel mainTablePanel;
        private Label titleLabel;
        private TableLayoutPanel inputTablePanel;
        private Label dateLabel;
        private Label categoryLabel;
        private ComboBox dateComboBox;
        private ComboBox categoryComboBox;
        private TableLayoutPanel buttonTablePanel;
        private Button submitButton;
        private Button cancelButton;
    }
}
