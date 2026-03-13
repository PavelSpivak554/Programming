namespace ObjectOrientedPractics.View.Tabs
{
    partial class CartsTab
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddToCartBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.CustomersComboBox = new System.Windows.Forms.ComboBox();
            this.CartLabel = new System.Windows.Forms.Label();
            this.CartListBox = new System.Windows.Forms.ListBox();
            this.AmountTitleLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.CreateOrderBtn = new System.Windows.Forms.Button();
            this.RemoveItemBtn = new System.Windows.Forms.Button();
            this.ClearCartBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.DiscountAmountlabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Totallabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DiscountsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ItemsListBox);
            this.panel1.Controls.Add(this.itemsLabel);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 469);
            this.panel1.TabIndex = 0;
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.IntegralHeight = false;
            this.ItemsListBox.ItemHeight = 16;
            this.ItemsListBox.Location = new System.Drawing.Point(3, 28);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(309, 392);
            this.ItemsListBox.TabIndex = 1;
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.itemsLabel.Location = new System.Drawing.Point(3, 9);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(44, 16);
            this.itemsLabel.TabIndex = 2;
            this.itemsLabel.Text = "Items";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.AddToCartBtn, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 423);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 43);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // AddToCartBtn
            // 
            this.AddToCartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddToCartBtn.Location = new System.Drawing.Point(3, 3);
            this.AddToCartBtn.Name = "AddToCartBtn";
            this.AddToCartBtn.Size = new System.Drawing.Size(95, 37);
            this.AddToCartBtn.TabIndex = 0;
            this.AddToCartBtn.Text = "Add To Cart";
            this.AddToCartBtn.UseVisualStyleBackColor = true;
            this.AddToCartBtn.Click += new System.EventHandler(this.AddToCartBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(324, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 469);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.CustomerLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CustomersComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CartLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.CartListBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.AmountTitleLabel, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.AmountLabel, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(477, 469);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CustomerLabel.Location = new System.Drawing.Point(3, 0);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(82, 40);
            this.CustomerLabel.TabIndex = 0;
            this.CustomerLabel.Text = "Customer";
            this.CustomerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CustomersComboBox
            // 
            this.CustomersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomersComboBox.FormattingEnabled = true;
            this.CustomersComboBox.Location = new System.Drawing.Point(91, 11);
            this.CustomersComboBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.CustomersComboBox.Name = "CustomersComboBox";
            this.CustomersComboBox.Size = new System.Drawing.Size(383, 24);
            this.CustomersComboBox.TabIndex = 1;
            this.CustomersComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomersComboBox_SelectedIndexChanged);
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartLabel.Location = new System.Drawing.Point(3, 40);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(82, 30);
            this.CartLabel.TabIndex = 2;
            this.CartLabel.Text = "Cart:";
            this.CartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CartListBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.CartListBox, 2);
            this.CartListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartListBox.FormattingEnabled = true;
            this.CartListBox.IntegralHeight = false;
            this.CartListBox.ItemHeight = 16;
            this.CartListBox.Location = new System.Drawing.Point(9, 73);
            this.CartListBox.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.CartListBox.Name = "CartListBox";
            this.CartListBox.Size = new System.Drawing.Size(465, 115);
            this.CartListBox.TabIndex = 3;
            // 
            // AmountTitleLabel
            // 
            this.AmountTitleLabel.AutoSize = true;
            this.AmountTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountTitleLabel.Location = new System.Drawing.Point(91, 191);
            this.AmountTitleLabel.Name = "AmountTitleLabel";
            this.AmountTitleLabel.Size = new System.Drawing.Size(383, 29);
            this.AmountTitleLabel.TabIndex = 4;
            this.AmountTitleLabel.Text = "Amount:";
            this.AmountTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AmountLabel.Location = new System.Drawing.Point(91, 220);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(383, 31);
            this.AmountLabel.TabIndex = 5;
            this.AmountLabel.Text = "0,00 ₽";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel3.SetColumnSpan(this.tableLayoutPanel4, 2);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.CreateOrderBtn, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.RemoveItemBtn, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.ClearCartBtn, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 254);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(471, 42);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // CreateOrderBtn
            // 
            this.CreateOrderBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateOrderBtn.Location = new System.Drawing.Point(3, 3);
            this.CreateOrderBtn.Name = "CreateOrderBtn";
            this.CreateOrderBtn.Size = new System.Drawing.Size(111, 36);
            this.CreateOrderBtn.TabIndex = 0;
            this.CreateOrderBtn.Text = "Create Order";
            this.CreateOrderBtn.UseVisualStyleBackColor = true;
            this.CreateOrderBtn.Click += new System.EventHandler(this.CreateOrderBtn_Click);
            // 
            // RemoveItemBtn
            // 
            this.RemoveItemBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveItemBtn.Location = new System.Drawing.Point(237, 3);
            this.RemoveItemBtn.Name = "RemoveItemBtn";
            this.RemoveItemBtn.Size = new System.Drawing.Size(111, 36);
            this.RemoveItemBtn.TabIndex = 1;
            this.RemoveItemBtn.Text = "Remove Item";
            this.RemoveItemBtn.UseVisualStyleBackColor = true;
            this.RemoveItemBtn.Click += new System.EventHandler(this.RemoveItemBtn_Click);
            // 
            // ClearCartBtn
            // 
            this.ClearCartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearCartBtn.Location = new System.Drawing.Point(354, 3);
            this.ClearCartBtn.Name = "ClearCartBtn";
            this.ClearCartBtn.Size = new System.Drawing.Size(114, 36);
            this.ClearCartBtn.TabIndex = 2;
            this.ClearCartBtn.Text = "Clear Cart";
            this.ClearCartBtn.UseVisualStyleBackColor = true;
            this.ClearCartBtn.Click += new System.EventHandler(this.ClearCartBtn_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.74152F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.25848F));
            this.tableLayoutPanel5.Controls.Add(this.DiscountAmountlabel, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.Totallabel, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.DiscountsCheckedListBox, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(91, 302);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(383, 164);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // DiscountAmountlabel
            // 
            this.DiscountAmountlabel.AutoSize = true;
            this.DiscountAmountlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiscountAmountlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscountAmountlabel.Location = new System.Drawing.Point(205, 63);
            this.DiscountAmountlabel.Name = "DiscountAmountlabel";
            this.DiscountAmountlabel.Size = new System.Drawing.Size(175, 45);
            this.DiscountAmountlabel.TabIndex = 21;
            this.DiscountAmountlabel.Text = "0,00 ₽";
            this.DiscountAmountlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(205, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 63);
            this.label4.TabIndex = 19;
            this.label4.Text = "Discount Amount:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Totallabel
            // 
            this.Totallabel.AutoSize = true;
            this.Totallabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Totallabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Totallabel.Location = new System.Drawing.Point(205, 131);
            this.Totallabel.Name = "Totallabel";
            this.Totallabel.Size = new System.Drawing.Size(175, 33);
            this.Totallabel.TabIndex = 12;
            this.Totallabel.Text = "0,00 ₽";
            this.Totallabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(205, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DiscountsCheckedListBox
            // 
            this.DiscountsCheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiscountsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiscountsCheckedListBox.FormattingEnabled = true;
            this.DiscountsCheckedListBox.Location = new System.Drawing.Point(3, 3);
            this.DiscountsCheckedListBox.Name = "DiscountsCheckedListBox";
            this.tableLayoutPanel5.SetRowSpan(this.DiscountsCheckedListBox, 4);
            this.DiscountsCheckedListBox.Size = new System.Drawing.Size(196, 158);
            this.DiscountsCheckedListBox.TabIndex = 8;
            // 
            // CartsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CartsTab";
            this.Size = new System.Drawing.Size(804, 475);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button AddToCartBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.ComboBox CustomersComboBox;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.ListBox CartListBox;
        private System.Windows.Forms.Label AmountTitleLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button CreateOrderBtn;
        private System.Windows.Forms.Button RemoveItemBtn;
        private System.Windows.Forms.Button ClearCartBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DiscountAmountlabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Totallabel;
        private System.Windows.Forms.CheckedListBox DiscountsCheckedListBox;
    }
}