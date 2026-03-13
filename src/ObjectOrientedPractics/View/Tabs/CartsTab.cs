using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;


namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет вкладку для управления корзинами покупок покупателей.
    /// Позволяет добавлять товары в корзину, удалять их, очищать корзину и создавать заказы.
    /// </summary>
    public partial class CartsTab : UserControl
    {
        /// <summary>
        /// Список доступных товаров.
        /// </summary>
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Текущий выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CartsTab"/>.
        /// </summary>
        public CartsTab()
        {
            InitializeComponent();
            DiscountsCheckedListBox.ItemCheck += DiscountsCheckedListBox_ItemCheck;
        }

        /// <summary>
        /// Получает или задает список доступных товаров.
        /// При установке нового значения обновляет список товаров в интерфейсе.
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
        /// Получает или задает список покупателей.
        /// При установке нового значения обновляет выпадающий список покупателей.
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
        /// Получает или задает текущего выбранного покупателя.
        /// При изменении обновляет отображение корзины.
        /// </summary>
        private Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                UpdateCartListBox();
            }
        }

        /// <summary>
        /// Обновляет данные на вкладке.
        /// Перезагружает списки товаров и покупателей, сбрасывает выбранного покупателя.
        /// </summary>
        public void RefreshData()
        {
            UpdateItemsListBox();
            UpdateCustomersComboBox();
            CurrentCustomer = null;
        }

        /// <summary>
        /// Обновляет список товаров в интерфейсе.
        /// </summary>
        private void UpdateItemsListBox()
        {
            ItemsListBox.Items.Clear();
            if (_items == null) return;

            foreach (var item in _items)
            {
                ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
            }
        }

        /// <summary>
        /// Обновляет выпадающий список покупателей.
        /// </summary>
        private void UpdateCustomersComboBox()
        {
            CustomersComboBox.Items.Clear();
            if (_customers == null) return;

            foreach (var customer in _customers)
            {
                CustomersComboBox.Items.Add(customer);
            }

            CustomersComboBox.DisplayMember = "FullName";
            CustomersComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Обновляет отображение корзины текущего покупателя.
        /// </summary>
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

        /// <summary>
        /// Обновляет отображение общей суммы товаров в корзине.
        /// </summary>
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

        /// <summary>
        /// Получает выбранный товар из списка товаров.
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
        /// Обрабатывает изменение выбранного покупателя в выпадающем списке.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CustomersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersComboBox.SelectedItem is Customer selectedCustomer)
            {
                _currentCustomer = selectedCustomer;
                UpdateCartListBox();
                UpdateDiscountsCheckedListBox(); // ← добавить
            }
            else
            {
                _currentCustomer = null;
                CartListBox.Items.Clear();
                DiscountsCheckedListBox.Items.Clear();
                AmountLabel.Text = "0,00 ₽";
                DiscountAmountlabel.Text = "0,00 ₽";
                Totallabel.Text = "0,00 ₽";
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления товара в корзину.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления товара из корзины.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие кнопки очистки корзины.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие кнопки создания заказа.
        /// Создает заказ из товаров в корзине текущего покупателя.
        /// В зависимости от приоритетности покупателя, создает приоритетные заказы
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CreateOrderBtn_Click(object sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                MessageBox.Show("Выберите покупателя!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentCustomer.Cart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста!", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double totalDiscount = 0;
            var items = _currentCustomer.Cart.Items.ToList();

            // Применяем выбранные скидки
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                if (DiscountsCheckedListBox.GetItemChecked(i))
                {
                    var discount = _currentCustomer.Discounts[i];
                    totalDiscount += discount.Apply(items);
                }
            }

            // Обновляем все скидки
            foreach (var discount in _currentCustomer.Discounts)
            {
                discount.Update(items);
            }

            // Создаем заказ
            Order order;
            if (_currentCustomer.IsPriority)
            {
                order = new PriorityOrder(_currentCustomer.Cart, _currentCustomer.Address);
            }
            else
            {
                order = new Order(_currentCustomer.Cart, _currentCustomer.Address);
            }

            order.DiscountAmount = totalDiscount;
            _currentCustomer.Orders.Add(order);

            // Очищаем корзину и обновляем интерфейс
            _currentCustomer.Cart.Items.Clear();
            UpdateCartListBox();
            UpdateDiscountsCheckedListBox();

            MessageBox.Show($"Заказ №{order.Id} создан! Скидка: {totalDiscount:C2}",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        /// <summary>
        /// Обновляет список скидок в CheckedListBox.
        /// </summary>
        private void UpdateDiscountsCheckedListBox()
        {
            DiscountsCheckedListBox.Items.Clear();

            if (_currentCustomer?.Discounts != null)
            {
                foreach (var discount in _currentCustomer.Discounts)
                {
                    DiscountsCheckedListBox.Items.Add(discount.Info, true); // все включены по умолчанию
                }
            }

            UpdateDiscountAmount();
        }

        /// <summary>
        /// Обновляет сумму скидки на основе выбранных скидок.
        /// </summary>
        private void UpdateDiscountAmount()
        {
            if (_currentCustomer?.Cart?.Items == null) return;

            double totalDiscount = 0;
            var items = _currentCustomer.Cart.Items.ToList();

            // Собираем выбранные скидки
            var selectedDiscounts = new List<IDiscount>();
            for (int i = 0; i < DiscountsCheckedListBox.Items.Count; i++)
            {
                if (DiscountsCheckedListBox.GetItemChecked(i))
                {
                    selectedDiscounts.Add(_currentCustomer.Discounts[i]);
                }
            }

            // Вычисляем общую скидку
            foreach (var discount in selectedDiscounts)
            {
                totalDiscount += discount.Calculate(items);
            }

            DiscountAmountlabel.Text = totalDiscount.ToString("C2");

            // Обновляем Total (Amount - Discount)
            double total = (_currentCustomer.Cart.Amount - totalDiscount);
            Totallabel.Text = total.ToString("C2");
        }

        /// <summary>
        /// Обрабатывает изменение выбранных скидок.
        /// </summary>
        private void DiscountsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Нужно использовать BeginInvoke, чтобы событие сработало после изменения
            this.BeginInvoke((MethodInvoker)UpdateDiscountAmount);
        }
    }
}