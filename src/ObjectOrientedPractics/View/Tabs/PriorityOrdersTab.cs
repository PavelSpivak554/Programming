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
    /// <summary>
    /// Представляет вкладку для управления приоритетными заказами.
    /// Позволяет просматривать и редактировать приоритетный заказ,
    /// добавлять и удалять товары, выбирать время доставки.
    /// </summary>
    public partial class PriorityOrdersTab : UserControl
    {
        /// <summary>
        /// Текущий приоритетный заказ.
        /// </summary>
        private PriorityOrder _currentPriorityOrder;

        /// <summary>
        /// Ссылка на хранилище данных магазина для доступа к товарам.
        /// </summary>
        private Store _store;

        /// <summary>
        /// Получает или задает хранилище данных магазина.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Store Store
        {
            get { return _store; }
            set
            {
                _store = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PriorityOrdersTab"/>.
        /// Создает новый приоритетный заказ, инициализирует компоненты,
        /// заполняет выпадающие списки и отображает информацию о заказе.
        /// </summary>
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

        /// <summary>
        /// Инициализирует выпадающий список времени доставки.
        /// Заполняет список строковыми представлениями временных интервалов.
        /// </summary>
        private void InitializeTimeComboBox()
        {
            DeliveryTimeComboBox.Items.Clear();
            foreach (DeliveryTime time in Enum.GetValues(typeof(DeliveryTime)))
            {
                DeliveryTimeComboBox.Items.Add(_currentPriorityOrder.GetDesiredTime(time));
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбранного статуса заказа.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder == null || StatusComboBox.SelectedItem == null) return;

            _currentPriorityOrder.Status = (OrderStatus)StatusComboBox.SelectedItem;
        }

        /// <summary>
        /// Отображает информацию о текущем приоритетном заказе.
        /// Заполняет все поля интерфейса данными из заказа.
        /// </summary>
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

        /// <summary>
        /// Обрабатывает изменение выбранного времени доставки.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_currentPriorityOrder == null || DeliveryTimeComboBox.SelectedItem == null) return;

            _currentPriorityOrder.DesiredTime = DeliveryTimeComboBox.SelectedItem.ToString();
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления товара.
        /// Добавляет случайный товар из магазина в заказ.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления товара.
        /// Удаляет выбранный товар из заказа и обновляет выделение.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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
        /// Устанавливает выделение после удаления товара.
        /// Выделяет следующий товар или последний, если следующего нет.
        /// </summary>
        /// <param name="removedIndex">Индекс удаленного товара.</param>
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

        /// <summary>
        /// Обновляет отображение списка товаров в заказе.
        /// Очищает ListBox и заполняет его актуальными товарами.
        /// </summary>
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
        /// Обновляет отображение общей суммы товаров в заказе.
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

        /// <summary>
        /// Обрабатывает нажатие кнопки очистки заказа.
        /// Создает новый экземпляр приоритетного заказа.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
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