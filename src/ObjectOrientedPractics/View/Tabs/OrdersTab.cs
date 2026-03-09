using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class OrdersTab : UserControl
    {
        private List<Customer> _customers;
        private List<Order> _orders = new List<Order>();
        private Order _selectedOrder;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                UpdateOrders();
            }
        }

        public OrdersTab()
        {
            InitializeComponent();

            // Настройка DataGridView
            ConfigureDataGridView();

            // Настройка комбобокса
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));

            // Устанавливаем поля только для чтения
            SetReadOnlyMode();

            // Подписка на события
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Настройка колонок DataGridView
        /// </summary>
        private void ConfigureDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "Id";
            idColumn.DataPropertyName = "Id";

            DataGridViewTextBoxColumn createdColumn = new DataGridViewTextBoxColumn();
            createdColumn.Name = "Created";
            createdColumn.HeaderText = "Created";

            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.Name = "OrderStatus";
            statusColumn.HeaderText = "Order Status";

            DataGridViewTextBoxColumn customerColumn = new DataGridViewTextBoxColumn();
            customerColumn.Name = "CustomerFullName";
            customerColumn.HeaderText = "Customer Full Name";

            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn();
            addressColumn.Name = "DeliveryAddress";
            addressColumn.HeaderText = "Delivery Address";

            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn();
            amountColumn.Name = "TotalAmount";
            amountColumn.HeaderText = "Total Amount";

            dataGridView1.Columns.Add(idColumn);
            dataGridView1.Columns.Add(createdColumn);
            dataGridView1.Columns.Add(statusColumn);
            dataGridView1.Columns.Add(customerColumn);
            dataGridView1.Columns.Add(addressColumn);
            dataGridView1.Columns.Add(amountColumn);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
        }

        /// <summary>
        /// Установка режима только для чтения для всех полей кроме статуса
        /// </summary>
        private void SetReadOnlyMode()
        {
            IdTextBox.ReadOnly = true;
            CreatedTextBox.ReadOnly = true;

            // AddressControl в режим только для чтения
            SetAddressControlReadOnly(true);

            OrderItemsListBox.Enabled = false;
        }

        /// <summary>
        /// Установка режима только для чтения для AddressControl
        /// </summary>
        private void SetAddressControlReadOnly(bool readOnly)
        {
            foreach (Control control in addressControl1.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.ReadOnly = readOnly;
                    textBox.BackColor = System.Drawing.Color.White;
                }
            }
        }

        /// <summary>
        /// Обновляет список заказов на основе списка покупателей.
        /// Перебирает всех покупателей, собирает их заказы в общий список
        /// и заполняет таблицу DataGridView.
        /// </summary>
        private void UpdateOrders()
        {
            _orders.Clear();
            dataGridView1.Rows.Clear();

            if (_customers == null) return;

            foreach (var customer in _customers)
            {
                foreach (var order in customer.Orders)
                {
                    _orders.Add(order);

                    dataGridView1.Rows.Add(
                        order.Id,
                        order.Date.ToShortDateString(),
                        order.Status,
                        customer.FullName,
                        $"{order.Address.Index}, {order.Address.Country}, {order.Address.City}, {order.Address.Street} {order.Address.Building}-{order.Address.Apartment}",
                        order.Amount.ToString("F2")
                    );
                }
            }

            _selectedOrder = null;
            ClearOrderInfo();
        }

        /// <summary>
        /// Метод для обновления данных на вкладке.
        /// Вызывается из главного окна при необходимости.
        /// </summary>
        public void RefreshData()
        {
            UpdateOrders();
        }

        /// <summary>
        /// Обработчик выбора строки в таблице.
        /// При выборе заказа инициализирует правую панель с данными заказа.
        /// </summary>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                _selectedOrder = null;
                ClearOrderInfo();
                return;
            }

            int selectedIndex = dataGridView1.SelectedRows[0].Index;

            if (selectedIndex < 0 || selectedIndex >= _orders.Count)
            {
                _selectedOrder = null;
                ClearOrderInfo();
                return;
            }

            _selectedOrder = _orders[selectedIndex];
            DisplayOrderInfo(_selectedOrder);
        }

        /// <summary>
        /// Отображает информацию о заказе на правой панели.
        /// </summary>
        /// <param name="order">Выбранный заказ.</param>
        private void DisplayOrderInfo(Order order)
        {
            if (order == null) return;

            IdTextBox.Text = order.Id.ToString();
            CreatedTextBox.Text = order.Date.ToShortDateString();

            StatusComboBox.SelectedIndexChanged -= StatusComboBox_SelectedIndexChanged;
            StatusComboBox.SelectedItem = order.Status;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;

            addressControl1.Address = order.Address;

            OrderItemsListBox.Items.Clear();
            foreach (var item in order.Items)
            {
                OrderItemsListBox.Items.Add($"{item.Name} - {item.Cost:F2} ₽");
            }

            AmountValueLabel.Text = order.Amount.ToString("F2");
        }

        /// <summary>
        /// Очищает поля информации о заказе.
        /// </summary>
        private void ClearOrderInfo()
        {
            IdTextBox.Clear();
            CreatedTextBox.Clear();
            StatusComboBox.SelectedIndex = -1;
            addressControl1.ClearFields();
            OrderItemsListBox.Items.Clear();
            AmountValueLabel.Text = "0";
        }

        /// <summary>
        /// Обработчик изменения статуса заказа.
        /// Присваивает новое значение статуса выбранному заказу и обновляет таблицу.
        /// </summary>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedOrder == null || StatusComboBox.SelectedItem == null) return;

            OrderStatus newStatus = (OrderStatus)StatusComboBox.SelectedItem;
            _selectedOrder.Status = newStatus;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[selectedIndex].Cells["OrderStatus"].Value = newStatus;
                }
            }
        }
    }
}