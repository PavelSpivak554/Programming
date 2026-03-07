using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CartsTab : UserControl
    {
        private List<Item> _items;
        private List<Customer> _customers;
        private Customer _currentCustomer;

        public CartsTab()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Обновляет данные на вкладке Carts.
        /// Вызывается при переключении на вкладку.
        /// </summary>
        public void RefreshData()
        {
            UpdateItemsListBox();
            UpdateCustomersComboBox();
            CurrentCustomer = null;
            UpdateCartListBox();
        }

        /// <summary>
        /// Список товаров (привязан к ListBox).
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value ?? new List<Item>();
                UpdateItemsListBox();
            }
        }

        /// <summary>
        /// Список покупателей (привязан к ComboBox).
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value ?? new List<Customer>();
                UpdateCustomersComboBox();
            }
        }

        /// <summary>
        /// Текущий выбранный покупатель.
        /// </summary>
        private Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                UpdateCartListBox();
                UpdateTotalAmount();
            }
        }

        /// <summary>
        /// Обновляет данные в ListBox товаров.
        /// </summary>
        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            if (_items != null)
            {
                foreach (var item in _items)
                {
                    ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }
        }

        /// <summary>
        /// Обновляет данные в ComboBox покупателей.
        /// </summary>
        private void UpdateCustomersComboBox()
        {
            CustomersComboBox.Items.Clear();
            CustomersComboBox.Items.Add("-- Выберите покупателя --");

            if (_customers != null)
            {
                foreach (var customer in _customers)
                {
                    CustomersComboBox.Items.Add(customer);
                }
            }

            CustomersComboBox.DisplayMember = "FullName";
            CustomersComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновляет ListBox корзины выбранного покупателя.
        /// </summary>
        private void UpdateCartListBox()
        {
            CartListBox.Items.Clear();

            if (CurrentCustomer?.Cart != null)
            {
                foreach (var item in CurrentCustomer.Cart.Items)
                {
                    CartListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }

            UpdateTotalAmount();
        }

        /// <summary>
        /// Обновляет отображение общей суммы корзины.
        /// </summary>
        private void UpdateTotalAmount()
        {
            if (CurrentCustomer?.Cart != null)
            {
                AmountLabel.Text = CurrentCustomer.Cart.Amount.ToString("C2");
            }
            else
            {
                AmountLabel.Text = "0,00 ₽";
            }
        }

        /// <summary>
        /// Возвращает выбранный товар в ItemsListBox.
        /// </summary>
        private Item SelectedItem
        {
            get
            {
                if (ItemsListBox.SelectedIndex >= 0 && _items != null &&
                    ItemsListBox.SelectedIndex < _items.Count)
                {
                    return _items[ItemsListBox.SelectedIndex];
                }
                return null;
            }
        }

        /// <summary>
        /// Обработчик изменения выбора в ComboBox покупателей.
        /// </summary>
        private void CustomersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersComboBox.SelectedIndex <= 0)
            {
                CurrentCustomer = null;
            }
            else if (CustomersComboBox.SelectedItem is Customer selectedCustomer)
            {
                CurrentCustomer = selectedCustomer;
            }
        }

        /// <summary>
        /// Обработчик кнопки добавления товара в корзину.
        /// </summary>
        private void AddToCartBtn_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Выберите товар для добавления!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CurrentCustomer.Cart.Items.Add(SelectedItem);
            UpdateCartListBox();
        }

        /// <summary>
        /// Обработчик кнопки удаления товара из корзины.
        /// </summary>
        private void RemoveItemBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CartListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите товар для удаления из корзины!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить выбранный товар из корзины?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentCustomer.Cart.Items.RemoveAt(CartListBox.SelectedIndex);
                UpdateCartListBox();
            }
        }

        /// <summary>
        /// Обработчик кнопки очистки корзины.
        /// </summary>
        private void ClearCartBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина уже пуста!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Очистить корзину?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentCustomer.Cart.Items.Clear();
                UpdateCartListBox();
            }
        }

        /// <summary>
        /// Обработчик кнопки создания заказа.
        /// </summary>
        private void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста! Добавьте товары для создания заказа.",
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем заказ
            var order = new Order(CurrentCustomer.Cart, CurrentCustomer.Address);
            CurrentCustomer.Orders.Add(order);

            // Очищаем корзину
            CurrentCustomer.Cart.Items.Clear();
            UpdateCartListBox();

            MessageBox.Show($"Заказ №{order.Id} успешно создан!\n" +
                $"Количество товаров: {order.Items.Count}\n" +
                $"Сумма заказа: {order.Amount:C2}", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}