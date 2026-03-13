using System.Drawing;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    partial class OrdersTab
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeliveryTimeComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OrderItemsListBox = new System.Windows.Forms.ListBox();
            this.AmountValueLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.CreatedTextBox = new System.Windows.Forms.TextBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addressControl1 = new ObjectOrientedPractics.View.Controls.AddressControl();
            this.TotalTitleLabel = new System.Windows.Forms.Label();
            this.TotalValueLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.663551F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.33645F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 473);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(2, 2);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 22);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Orders";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.DeliveryTimeComboBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.OrderItemsListBox);
            this.panel1.Controls.Add(this.AmountValueLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.StatusComboBox);
            this.panel1.Controls.Add(this.CreatedTextBox);
            this.panel1.Controls.Add(this.IdTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.addressControl1);
            this.panel1.Controls.Add(this.TotalTitleLabel);
            this.panel1.Controls.Add(this.TotalValueLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(315, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 433);
            this.panel1.TabIndex = 0;
            // 
            // DeliveryTimeComboBox
            // 
            this.DeliveryTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeliveryTimeComboBox.FormattingEnabled = true;
            this.DeliveryTimeComboBox.Location = new System.Drawing.Point(316, 8);
            this.DeliveryTimeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveryTimeComboBox.Name = "DeliveryTimeComboBox";
            this.DeliveryTimeComboBox.Size = new System.Drawing.Size(146, 24);
            this.DeliveryTimeComboBox.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Delivery Time:";
            // 
            // OrderItemsListBox
            // 
            this.OrderItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderItemsListBox.FormattingEnabled = true;
            this.OrderItemsListBox.ItemHeight = 16;
            this.OrderItemsListBox.Location = new System.Drawing.Point(2, 273);
            this.OrderItemsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.OrderItemsListBox.Name = "OrderItemsListBox";
            this.OrderItemsListBox.Size = new System.Drawing.Size(429, 68);
            this.OrderItemsListBox.TabIndex = 10;
            // 
            // AmountValueLabel
            // 
            this.AmountValueLabel.AutoSize = true;
            this.AmountValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.AmountValueLabel.Location = new System.Drawing.Point(159, 368);
            this.AmountValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AmountValueLabel.Name = "AmountValueLabel";
            this.AmountValueLabel.Size = new System.Drawing.Size(29, 35);
            this.AmountValueLabel.TabIndex = 9;
            this.AmountValueLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(343, 318);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, 250);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Order Items";
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(68, 55);
            this.StatusComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(146, 24);
            this.StatusComboBox.TabIndex = 5;
            // 
            // CreatedTextBox
            // 
            this.CreatedTextBox.Location = new System.Drawing.Point(68, 33);
            this.CreatedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CreatedTextBox.Name = "CreatedTextBox";
            this.CreatedTextBox.ReadOnly = true;
            this.CreatedTextBox.Size = new System.Drawing.Size(146, 22);
            this.CreatedTextBox.TabIndex = 4;
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(68, 10);
            this.IdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.ReadOnly = true;
            this.IdTextBox.Size = new System.Drawing.Size(146, 22);
            this.IdTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Created:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID:";
            // 
            // addressControl1
            // 
            this.addressControl1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.addressControl1.Location = new System.Drawing.Point(4, 83);
            this.addressControl1.Margin = new System.Windows.Forms.Padding(2);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.Size = new System.Drawing.Size(452, 165);
            this.addressControl1.TabIndex = 0;
            // 
            // TotalTitleLabel
            // 
            this.TotalTitleLabel.AutoSize = true;
            this.TotalTitleLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TotalTitleLabel.Location = new System.Drawing.Point(343, 343);
            this.TotalTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalTitleLabel.Name = "TotalTitleLabel";
            this.TotalTitleLabel.Size = new System.Drawing.Size(60, 25);
            this.TotalTitleLabel.TabIndex = 23;
            this.TotalTitleLabel.Text = "Total:";
            // 
            // TotalValueLabel
            // 
            this.TotalValueLabel.AutoSize = true;
            this.TotalValueLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.TotalValueLabel.Location = new System.Drawing.Point(342, 368);
            this.TotalValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TotalValueLabel.Name = "TotalValueLabel";
            this.TotalValueLabel.Size = new System.Drawing.Size(29, 35);
            this.TotalValueLabel.TabIndex = 24;
            this.TotalValueLabel.Text = "0";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(315, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 32);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected Order";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Created,
            this.OrderStatus,
            this.CustomerFullName,
            this.DeliveryAddress,
            this.TotalAmount,
            this.TotalColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(309, 433);
            this.dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 8;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 47;
            // 
            // Created
            // 
            this.Created.HeaderText = "Created";
            this.Created.MinimumWidth = 8;
            this.Created.Name = "Created";
            this.Created.ReadOnly = true;
            this.Created.Width = 84;
            // 
            // OrderStatus
            // 
            this.OrderStatus.HeaderText = "Order Status";
            this.OrderStatus.MinimumWidth = 8;
            this.OrderStatus.Name = "OrderStatus";
            this.OrderStatus.ReadOnly = true;
            this.OrderStatus.Width = 101;
            // 
            // CustomerFullName
            // 
            this.CustomerFullName.HeaderText = "Customer Full Name";
            this.CustomerFullName.MinimumWidth = 8;
            this.CustomerFullName.Name = "CustomerFullName";
            this.CustomerFullName.ReadOnly = true;
            this.CustomerFullName.Width = 110;
            // 
            // DeliveryAddress
            // 
            this.DeliveryAddress.HeaderText = "Delivery Address";
            this.DeliveryAddress.MinimumWidth = 8;
            this.DeliveryAddress.Name = "DeliveryAddress";
            this.DeliveryAddress.ReadOnly = true;
            this.DeliveryAddress.Width = 128;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Amount";
            this.TotalAmount.MinimumWidth = 8;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 81;
            // 
            // TotalColumn
            // 
            this.TotalColumn.HeaderText = "Total";
            this.TotalColumn.MinimumWidth = 8;
            this.TotalColumn.Name = "TotalColumn";
            this.TotalColumn.ReadOnly = true;
            this.TotalColumn.Width = 67;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(150, 343);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Amount:";
            // 
            // OrdersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrdersTab";
            this.Size = new System.Drawing.Size(784, 473);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Controls.AddressControl addressControl1;
        private Panel panel3;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Label label1;
        private TextBox CreatedTextBox;
        private TextBox IdTextBox;
        private ComboBox StatusComboBox;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Created;
        private DataGridViewTextBoxColumn OrderStatus;
        private DataGridViewTextBoxColumn CustomerFullName;
        private Label label6;
        private Label AmountValueLabel;
        private Label label7;
        private ListBox OrderItemsListBox;
        private DataGridViewTextBoxColumn DeliveryAddress;
        private DataGridViewTextBoxColumn TotalAmount;
        private ComboBox DeliveryTimeComboBox;
        private Label label8;
        // <-- NEW: Добавить объявления в конец
        private Label TotalTitleLabel;
        private Label TotalValueLabel;
        private DataGridViewTextBoxColumn TotalColumn;
        private Label label9;
    }
}