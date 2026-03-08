using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class CartsTab : UserControl
    {
        private List<Item> _items = new List<Item>();
        private List<Customer> _customers = new List<Customer>();
        private Customer _currentCustomer;

        public CartsTab()
        {
            InitializeComponent();
        }

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

        private Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                UpdateCartListBox();
            }
        }

        public void RefreshData()
        {
            UpdateItemsListBox();
            UpdateCustomersComboBox();
            CurrentCustomer = null;
        }

        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            if (_items == null) return;

            foreach (var item in _items)
            {
                ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
            }
        }

        private void UpdateCustomersComboBox()
        {
            CustomersComboBox.Items.Clear();
            if (_customers == null) return;

            foreach (var customer in _customers)
            {
                CustomersComboBox.Items.Add(customer);
            }

            CustomersComboBox.DisplayMember = "FullName";
            CustomersComboBox.SelectedIndex = -1; // по умолчанию ничего не выбрано
        }

        private void UpdateCartListBox()
        {
            CartListBox.Items.Clear();

            if (CurrentCustomer?.Cart?.Items != null)
            {
                foreach (var item in CurrentCustomer.Cart.Items)
                {
                    CartListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }

            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            if (CurrentCustomer?.Cart?.Items != null)
            {
                double total = 0;
                foreach (var item in CurrentCustomer.Cart.Items)
                {
                    total += item.Cost;
                }
                AmountLabel.Text = total.ToString("C2");
            }
            else
            {
                AmountLabel.Text = "0,00 ₽";
            }
        }

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

        private void CustomersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersComboBox.SelectedItem is Customer selectedCustomer)
            {
                CurrentCustomer = selectedCustomer;
                MessageBox.Show($"Выбран покупатель: {CurrentCustomer.FullName}");
            }
            else
            {
                CurrentCustomer = null;
                MessageBox.Show("Покупатель не выбран");
            }
        }

        private void AddToCartBtn_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Выберите товар для добавления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CurrentCustomer.Cart.Items.Add(SelectedItem);
            UpdateCartListBox();
        }

        private void RemoveItemBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CartListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите товар для удаления из корзины!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CurrentCustomer.Cart.Items.RemoveAt(CartListBox.SelectedIndex);
            UpdateCartListBox();
        }

        private void ClearCartBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина уже пуста!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Очистить корзину?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentCustomer.Cart.Items.Clear();
                UpdateCartListBox();
            }
        }

        private void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста! Добавьте товары для создания заказа.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var order = new Order(CurrentCustomer.Cart, CurrentCustomer.Address);
            CurrentCustomer.Orders.Add(order);

            CurrentCustomer.Cart.Items.Clear();
            UpdateCartListBox();

            MessageBox.Show($"Заказ №{order.Id} успешно создан!\nКоличество товаров: {order.Items.Count}\nСумма заказа: {order.Amount:C2}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}