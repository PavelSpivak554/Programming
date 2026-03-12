using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectOrientedPractics.Model.Orders;
using ObjectOrientedPractics.Model.Enums;



namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет вкладку для управления заказами.
    /// Отображает список всех заказов покупателей и позволяет просматривать детали заказа
    /// и изменять статус заказа.
    /// </summary>
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Список покупателей, полученный из главного окна.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Общий список всех заказов от всех покупателей.
        /// </summary>
        private List<Order> _orders = new List<Order>();

        /// <summary>
        /// Выбранный в данный момент заказ.
        /// </summary>
        private Order _selectedOrder;

        /// <summary>
        /// Текущий приоритетный заказ (если выбранный заказ приоритетный).
        /// </summary>
        private PriorityOrder _selectedPriorityOrder;

        /// <summary>
        /// Получает или задает список покупателей.
        /// При установке нового значения автоматически обновляет список заказов.
        /// </summary>
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

        /// <summary>
        /// Получает или задает выбранный заказ.
        /// При изменении определяет тип заказа и обновляет видимость панели приоритетных опций.
        /// </summary>
        private Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;

                // Определяем, является ли выбранный заказ приоритетным
                _selectedPriorityOrder = _selectedOrder as PriorityOrder;

                // Обновляем видимость и содержимое панели приоритетных опций
                UpdatePriorityOptionsPanel();
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OrdersTab"/>.
        /// Выполняет настройку таблицы, комбобокса и подписывается на события.
        /// </summary>
        public OrdersTab()
        {
            InitializeComponent();
            ConfigureDataGridView();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            SetReadOnlyMode();

            // Изначально скрываем панель приоритетных опций
            HidePriorityOptionsPanel();

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
        }

        /// <summary>
        /// Скрывает панель приоритетных опций.
        /// </summary>
        private void HidePriorityOptionsPanel()
        {
            label8.Visible = false;            // "Delivery Time"
            DeliveryTimeComboBox.Visible = false;
        }

        /// <summary>
        /// Показывает панель приоритетных опций.
        /// </summary>
        private void ShowPriorityOptionsPanel()
        {
            label8.Visible = true;
            DeliveryTimeComboBox.Visible = true;
        }

        /// <summary>
        /// Обновляет видимость и содержимое панели приоритетных опций.
        /// </summary>
        private void UpdatePriorityOptionsPanel()
        {
            if (_selectedPriorityOrder != null)
            {
                // Заполняем ComboBox значениями времени доставки
                InitializeTimeComboBox();

                // Устанавливаем выбранное значение из заказа
                if (!string.IsNullOrEmpty(_selectedPriorityOrder.DesiredTime))
                {
                    DeliveryTimeComboBox.SelectedItem = _selectedPriorityOrder.DesiredTime;
                }

                ShowPriorityOptionsPanel();
            }
            else
            {
                HidePriorityOptionsPanel();
            }
        }

        /// <summary>
        /// Инициализирует выпадающий список времени доставки.
        /// Заполняет список строковыми представлениями временных интервалов.
        /// </summary>
        private void InitializeTimeComboBox()
        {
            DeliveryTimeComboBox.Items.Clear();

            // Создаем временный объект для получения строковых представлений
            var tempOrder = new PriorityOrder(new Cart(), new Address());

            foreach (DeliveryTime time in Enum.GetValues(typeof(DeliveryTime)))
            {
                DeliveryTimeComboBox.Items.Add(tempOrder.GetDesiredTime(time));
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбранного времени доставки.
        /// </summary>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_selectedPriorityOrder == null || DeliveryTimeComboBox.SelectedItem == null) return;

            _selectedPriorityOrder.DesiredTime = DeliveryTimeComboBox.SelectedItem.ToString();
        }

        /// <summary>
        /// Настраивает колонки DataGridView для отображения информации о заказах.
        /// Устанавливает режим только для чтения и отключает автоматическую генерацию колонок.
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
        /// Устанавливает режим только для чтения для всех полей, кроме статуса заказа.
        /// </summary>
        private void SetReadOnlyMode()
        {
            IdTextBox.ReadOnly = true;
            CreatedTextBox.ReadOnly = true;

            SetAddressControlReadOnly(true);

            OrderItemsListBox.Enabled = false;
        }

        /// <summary>
        /// Устанавливает режим только для чтения для элементов управления AddressControl.
        /// </summary>
        /// <param name="readOnly">True - режим только для чтения, False - режим редактирования.</param>
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

            SelectedOrder = null;
            ClearOrderInfo();
        }

        /// <summary>
        /// Обновляет данные на вкладке.
        /// Вызывается из главного окна при необходимости.
        /// </summary>
        public void RefreshData()
        {
            UpdateOrders();
        }

        /// <summary>
        /// Обрабатывает выбор строки в таблице заказов.
        /// Загружает информацию о выбранном заказе в поля для просмотра.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                SelectedOrder = null;
                ClearOrderInfo();
                return;
            }

            int selectedIndex = dataGridView1.SelectedRows[0].Index;

            if (selectedIndex < 0 || selectedIndex >= _orders.Count)
            {
                SelectedOrder = null;
                ClearOrderInfo();
                return;
            }

            // Используем свойство SelectedOrder для установки выбранного заказа
            SelectedOrder = _orders[selectedIndex];
            DisplayOrderInfo(_selectedOrder);
        }

        /// <summary>
        /// Отображает информацию о заказе в соответствующих полях интерфейса.
        /// </summary>
        /// <param name="order">Заказ для отображения.</param>
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
        /// Очищает все поля с информацией о заказе.
        /// </summary>
        private void ClearOrderInfo()
        {
            IdTextBox.Clear();
            CreatedTextBox.Clear();
            StatusComboBox.SelectedIndex = -1;
            addressControl1.ClearFields();
            OrderItemsListBox.Items.Clear();
            AmountValueLabel.Text = "0";

            // Скрываем панель приоритетных опций при очистке
            HidePriorityOptionsPanel();
        }

        /// <summary>
        /// Обрабатывает изменение статуса заказа.
        /// Обновляет статус выбранного заказа и соответствующую ячейку в таблице.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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