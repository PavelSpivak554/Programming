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
    public partial class PriorityOrdersTab : UserControl
    {
        private PriorityOrder _currentPriorityOrder;
        // Свойство для получения товаров из Store
        private Store _store;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Store Store
        {
            get { return _store; }
            set
            {
                _store = value;
            }
        }

        public PriorityOrdersTab()
        {
            _currentPriorityOrder = new PriorityOrder(DateTime.Now, "", new Cart(), new Address());

            InitializeComponent();
            InitializeTimeComboBox();
            StatusComboBox.DataSource = Enum.GetValues(typeof(OrderStatus));
            DisplayPriorityOrderInfo();

            // Подписываемся на события кнопок
            this.AddButton.Click += AddButton_Click;
            this.Removebutton.Click += Removebutton_Click;
            this.Clearbutton.Click += Clearbutton_Click;
            this.StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            this.DeliveryTimeComboBox.SelectedIndexChanged += DeliveryTimeComboBox_SelectedIndexChanged;
        }

        private void InitializeTimeComboBox()
        {
            DeliveryTimeComboBox.Items.Clear();
            foreach (DeliveryTime time in Enum.GetValues(typeof(DeliveryTime)))
            {
                DeliveryTimeComboBox.Items.Add(_currentPriorityOrder.GetDesiredTime(time));
            }
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder == null || StatusComboBox.SelectedItem == null) return;

            _currentPriorityOrder.Status = (OrderStatus)StatusComboBox.SelectedItem;
        }

        private void DisplayPriorityOrderInfo()
        {
            IdTextBox.Text = _currentPriorityOrder.Id.ToString();
            CreatedTextBox.Text = _currentPriorityOrder.Date.ToShortDateString();

            // Статус - выбирается из списка
            if (StatusComboBox.Items.Count > 0)
            {
                StatusComboBox.SelectedItem = _currentPriorityOrder.Status;
            }

            // Адрес - через AddressControl
            addressControl1.Address = _currentPriorityOrder.Address;

            // Список товаров
            UpdateItemsListbox();

            // Время доставки
            if (DeliveryTimeComboBox.Items.Count > 0 && !string.IsNullOrEmpty(_currentPriorityOrder.DesiredTime))
            {
                DeliveryTimeComboBox.SelectedItem = _currentPriorityOrder.DesiredTime;
            }
        }

        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder == null || DeliveryTimeComboBox.SelectedItem == null) return;

            _currentPriorityOrder.DesiredTime = DeliveryTimeComboBox.SelectedItem.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_store == null || _store.Items.Count == 0)
            {
                MessageBox.Show("Нет доступных товаров в магазине!");
                return;
            }

            // Выбираем случайный товар из Store
            Random random = new Random();
            int randomIndex = random.Next(0, _store.Items.Count);
            Item randomItem = _store.Items[randomIndex];

            // Создаем копию товара (чтобы не изменять оригинал в магазине)
            Item newItem = new Item(
                randomItem.Name,
                randomItem.Info,
                randomItem.Cost,
                randomItem.Category
            );

            // Добавляем в заказ
            _currentPriorityOrder.Items.Add(newItem);

            // Обновляем отображение
            UpdateItemsListbox();

            // Выделяем последний добавленный товар
            ItemsListBox.SelectedIndex = _currentPriorityOrder.Items.Count - 1;
        }

        private void Removebutton_Click(object sender, EventArgs e)
        {
            // Проверяем, выбран ли товар
            if (ItemsListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите товар для удаления из заказа!",
                    "Предупреждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Запоминаем индекс удаляемого товара
            int removedIndex = ItemsListBox.SelectedIndex;

            // Получаем товар из заказа (НЕ из Store!)
            Item currentItem = _currentPriorityOrder.Items[removedIndex];

            // Удаляем товар из заказа
            _currentPriorityOrder.Items.Remove(currentItem);

            // Обновляем ListBox
            UpdateItemsListbox();

            // Устанавливаем новое выделение
            SetSelectionAfterRemove(removedIndex);
        }

        /// <summary>
        /// Устанавливает выделение после удаления товара
        /// </summary>
        private void SetSelectionAfterRemove(int removedIndex)
        {
            if (_currentPriorityOrder.Items.Count == 0)
            {
                // Если товаров больше нет - снимаем выделение
                ItemsListBox.SelectedIndex = -1;
                return;
            }

            // Если удаленный индекс меньше количества товаров
            if (removedIndex < _currentPriorityOrder.Items.Count)
            {
                // Выделяем следующий товар (тот же индекс)
                ItemsListBox.SelectedIndex = removedIndex;
            }
            else
            {
                // Если следующего нет - выделяем последний
                ItemsListBox.SelectedIndex = _currentPriorityOrder.Items.Count - 1;
            }
        }

        private void UpdateItemsListbox()
        {
            ItemsListBox.Items.Clear();
            if (_currentPriorityOrder.Items != null)
            {
                foreach (var item in _currentPriorityOrder.Items)
                {
                    ItemsListBox.Items.Add($"{item.Name} - {item.Cost:C}");
                }
            }
            UpdateTotalAmount();
        }

        /// <summary>
        /// Обновляет отображение общей суммы товаров в корзине.
        /// </summary>
        private void UpdateTotalAmount()
        {
            if (_currentPriorityOrder.Items != null)
            {
                double total = 0;
                foreach (var item in _currentPriorityOrder.Items)
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

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            _currentPriorityOrder = new PriorityOrder(DateTime.Now, "", new Cart(), new Address());
            DisplayPriorityOrderInfo();

            // Сбрасываем время доставки на первый элемент
            if (DeliveryTimeComboBox.Items.Count > 0)
            {
                DeliveryTimeComboBox.SelectedIndex = 0;
            }
        }
    }
}