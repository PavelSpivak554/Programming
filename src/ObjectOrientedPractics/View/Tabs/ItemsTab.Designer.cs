namespace ObjectOrientedPractics.View.Tabs
{
    partial class ItemsTab
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.ItemAddButton = new System.Windows.Forms.Button();
            this.ItemRemoveButton = new System.Windows.Forms.Button();
            this.SelectedItemLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemIdTextBox = new System.Windows.Forms.TextBox();
            this.ItemCostTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ItemInfoTextBox = new System.Windows.Forms.TextBox();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ItemsCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OrderComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FindItemsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.IntegralHeight = false;
            this.ItemsListBox.ItemHeight = 16;
            this.ItemsListBox.Location = new System.Drawing.Point(3, 56);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(309, 329);
            this.ItemsListBox.TabIndex = 0;
            this.ItemsListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsListBox_SelectedIndexChanged);
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsLabel.Location = new System.Drawing.Point(3, 9);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(44, 16);
            this.itemsLabel.TabIndex = 1;
            this.itemsLabel.Text = "Items";
            // 
            // ItemAddButton
            // 
            this.ItemAddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemAddButton.Location = new System.Drawing.Point(3, 3);
            this.ItemAddButton.Name = "ItemAddButton";
            this.ItemAddButton.Size = new System.Drawing.Size(95, 37);
            this.ItemAddButton.TabIndex = 2;
            this.ItemAddButton.Text = "Add";
            this.ItemAddButton.UseVisualStyleBackColor = true;
            this.ItemAddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ItemRemoveButton
            // 
            this.ItemRemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemRemoveButton.Location = new System.Drawing.Point(104, 3);
            this.ItemRemoveButton.Name = "ItemRemoveButton";
            this.ItemRemoveButton.Size = new System.Drawing.Size(95, 37);
            this.ItemRemoveButton.TabIndex = 3;
            this.ItemRemoveButton.Text = "Remove";
            this.ItemRemoveButton.UseVisualStyleBackColor = true;
            this.ItemRemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // SelectedItemLabel
            // 
            this.SelectedItemLabel.AutoSize = true;
            this.SelectedItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedItemLabel.Location = new System.Drawing.Point(3, 9);
            this.SelectedItemLabel.Name = "SelectedItemLabel";
            this.SelectedItemLabel.Size = new System.Drawing.Size(102, 16);
            this.SelectedItemLabel.TabIndex = 4;
            this.SelectedItemLabel.Text = "Selected Item";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Id:";
            // 
            // ItemIdTextBox
            // 
            this.ItemIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemIdTextBox.Location = new System.Drawing.Point(74, 28);
            this.ItemIdTextBox.Name = "ItemIdTextBox";
            this.ItemIdTextBox.ReadOnly = true;
            this.ItemIdTextBox.Size = new System.Drawing.Size(142, 22);
            this.ItemIdTextBox.TabIndex = 7;
            // 
            // ItemCostTextBox
            // 
            this.ItemCostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemCostTextBox.Location = new System.Drawing.Point(74, 56);
            this.ItemCostTextBox.Name = "ItemCostTextBox";
            this.ItemCostTextBox.Size = new System.Drawing.Size(142, 22);
            this.ItemCostTextBox.TabIndex = 8;
            this.ItemCostTextBox.TextChanged += new System.EventHandler(this.ItemCostTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Description:";
            this.label4.UseMnemonic = false;
            // 
            // ItemInfoTextBox
            // 
            this.ItemInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemInfoTextBox.Location = new System.Drawing.Point(3, 229);
            this.ItemInfoTextBox.MaximumSize = new System.Drawing.Size(600, 187);
            this.ItemInfoTextBox.Multiline = true;
            this.ItemInfoTextBox.Name = "ItemInfoTextBox";
            this.ItemInfoTextBox.Size = new System.Drawing.Size(471, 66);
            this.ItemInfoTextBox.TabIndex = 12;
            this.ItemInfoTextBox.TextChanged += new System.EventHandler(this.ItemInfoTextBox_TextChanged);
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemNameTextBox.Location = new System.Drawing.Point(3, 137);
            this.ItemNameTextBox.MaximumSize = new System.Drawing.Size(600, 187);
            this.ItemNameTextBox.Multiline = true;
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(471, 66);
            this.ItemNameTextBox.TabIndex = 10;
            this.ItemNameTextBox.TextChanged += new System.EventHandler(this.ItemNameTextBox_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 475);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ItemsCategoryComboBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.SelectedItemLabel);
            this.panel2.Controls.Add(this.ItemInfoTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ItemNameTextBox);
            this.panel2.Controls.Add(this.ItemIdTextBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ItemCostTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(324, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 469);
            this.panel2.TabIndex = 1;
            // 
            // ItemsCategoryComboBox
            // 
            this.ItemsCategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsCategoryComboBox.FormattingEnabled = true;
            this.ItemsCategoryComboBox.Location = new System.Drawing.Point(75, 87);
            this.ItemsCategoryComboBox.Name = "ItemsCategoryComboBox";
            this.ItemsCategoryComboBox.Size = new System.Drawing.Size(141, 24);
            this.ItemsCategoryComboBox.TabIndex = 14;
            this.ItemsCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemsCategoryComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Category:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.FindItemsTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.itemsLabel);
            this.panel1.Controls.Add(this.ItemsListBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 469);
            this.panel1.TabIndex = 0;
            // 
            // OrderComboBox
            // 
            this.OrderComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.OrderComboBox, 2);
            this.OrderComboBox.FormattingEnabled = true;
            this.OrderComboBox.Items.AddRange(new object[] {
            "alphabetical",
            "Cost (Ascending)",
            "Cost (Descending)"});
            this.OrderComboBox.Location = new System.Drawing.Point(80, 3);
            this.OrderComboBox.Name = "OrderComboBox";
            this.OrderComboBox.Size = new System.Drawing.Size(223, 24);
            this.OrderComboBox.TabIndex = 15;
            this.OrderComboBox.SelectedIndexChanged += new System.EventHandler(this.OrderComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 29);
            this.label7.TabIndex = 15;
            this.label7.Text = "Order By:";
            // 
            // FindItemsTextBox
            // 
            this.FindItemsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindItemsTextBox.Location = new System.Drawing.Point(45, 31);
            this.FindItemsTextBox.Name = "FindItemsTextBox";
            this.FindItemsTextBox.Size = new System.Drawing.Size(264, 22);
            this.FindItemsTextBox.TabIndex = 15;
            this.FindItemsTextBox.TextChanged += new System.EventHandler(this.FindItemsTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Find:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.ItemAddButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ItemRemoveButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 423);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 43);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.1634F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.84967F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.OrderComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 388);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(306, 29);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // ItemsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ItemsTab";
            this.Size = new System.Drawing.Size(804, 475);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Button ItemAddButton;
        private System.Windows.Forms.Button ItemRemoveButton;
        private System.Windows.Forms.Label SelectedItemLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ItemIdTextBox;
        private System.Windows.Forms.TextBox ItemCostTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ItemInfoTextBox;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ItemsCategoryComboBox;
        private System.Windows.Forms.TextBox FindItemsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox OrderComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
