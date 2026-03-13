using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectOrientedPractics.Model.Enums;


namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет вкладку для работы с товарами.
    /// Обеспечивает добавление, удаление и редактирование информации о товарах.
    /// </summary>
    public partial class ItemsTab : UserControl
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ItemsTab"/>.
        /// </summary>
        public ItemsTab()
        {
            InitializeComponent();
            ItemsCategoryComboBox.DataSource = Enum.GetValues(typeof(Category));
            InitializeVisualValidation();
            
        }

        /// <summary>
        /// Список товаров, отображаемых на вкладке.
        /// </summary>
        private List<Item> _items = new List<Item>();
        /// <summary>
        /// Список товаров, отображаемых в элементе управления.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Item> Items
        {
            get => _items;
            set
            {
                _items = value ?? new List<Item>();
                ListBoxUpdate();
            }
        }


        /// <summary>
        /// Инициализация визуальной валидации полей
        /// </summary>
        private void InitializeVisualValidation()
        {
            ItemInfoTextBox.TextChanged += (s, e) => ValidateInfoTextBoxVisual();
            ItemCostTextBox.TextChanged += (s, e) => ValidateCostTextBoxVisual();
            ItemNameTextBox.TextChanged += (s, e) => ValidateNameTextBoxVisual();
        }
        private void InitializeSampleData()
        {
            _items.Add(new Item("Ноутбук", "Игровой ноутбук с RTX 4060", 89999.99, Category.Electronics));
            _items.Add(new Item("Книга", "Программирование на C#", 2499.99, Category.Books));
            _items.Add(new Item("Кофе", "Арабика, 250г", 599.99, Category.Food));
            _items.Add(new Item("Футболка", "Хлопковая, черная", 1299.99, Category.Clothing));
            _items.Add(new Item("Наушники", "Беспроводные, шумоподавление", 5999.99, Category.Electronics));
            ListBoxUpdate();
        }
        /// <summary>
        /// Выполняет валидацию поля наименования товара.
        /// Проверяет, что строка не пустая и не превышает 200 символов.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void ValidateNameTextBoxVisual()
        {
            bool isValid = string.IsNullOrEmpty(ItemNameTextBox.Text) ||
                          (ItemNameTextBox.Text.Length <= 200);
            ItemNameTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }
        /// <summary>
        /// Выполняет валидацию поля описания товара.
        /// Проверяет, что строка не пустая и не превышает 1000 символов.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void ValidateInfoTextBoxVisual()
        {
            bool isValid = string.IsNullOrEmpty(ItemInfoTextBox.Text) ||
                         (ItemInfoTextBox.Text.Length <= 1000);
            ItemInfoTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }
        /// <summary>
        /// Выполняет валидацию поля стоимости товара.
        /// Проверяет, что значение может быть преобразовано в double и является неотрицательным.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void ValidateCostTextBoxVisual()
        {
            bool isValid = string.IsNullOrWhiteSpace(ItemCostTextBox.Text) ||
                          (double.TryParse(ItemCostTextBox.Text, out double index) && index >= 0 && index <= 100000);
            ItemCostTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }
        /// <summary>
        /// Проверка всех полей Item
        /// </summary>
        private bool ItemsValidation()
        {
            bool costValid = !string.IsNullOrEmpty(ItemCostTextBox.Text) &&
                double.TryParse(ItemCostTextBox.Text, out double cost) &&
                cost >= 0 &&
                cost <= 100000;
            bool nameValid = !string.IsNullOrEmpty(ItemNameTextBox.Text) && ItemNameTextBox.Text.Length <= 200;
            bool infoValid = !string.IsNullOrEmpty(ItemInfoTextBox.Text) && ItemInfoTextBox.Text.Length <= 1000;
            ItemCostTextBox.BackColor = costValid ? Color.White : Color.LightPink;
            ItemNameTextBox.BackColor = nameValid ? Color.White : Color.LightPink;
            ItemInfoTextBox.BackColor = infoValid ? Color.White : Color.LightPink;

            return costValid && nameValid && infoValid;
        }
        /// <summary>
        /// Обрабатывает событие нажатия кнопки добавления товара.
        /// Создает новый товар на основе введенных данных и добавляет его в коллекцию.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemsValidation())
                {
                    string itemName = ItemNameTextBox.Text;
                    string itemInfo = ItemInfoTextBox.Text;
                    double itemCost = Convert.ToDouble(ItemCostTextBox.Text);
                    Category itemCategory = (Category)Enum.Parse(typeof(Category), ItemsCategoryComboBox.Text);
                    Item item = new Item(itemName, itemInfo, itemCost, itemCategory);
                    _items.Add(item);
                    ListBoxUpdate();
                }
                else
                {
                    MessageBox.Show("Невозможно добавить предмет, введите корректные данные в выделенные поля",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Невозможно добавить предмет, входные данные некорректны",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Невозможно добавить предмет, входные данные некорректны",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки удаления товара.
        /// Удаляет выбранный товар из коллекции и обновляет интерфейс.
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            _items.Remove(selectedItem);
            ListBoxUpdate();
            ClearFields();
        }

        /// <summary>
        /// Обрабатывает событие изменения выбранного элемента в списке товаров.
        /// Загружает данные выбранного товара в текстовые поля для редактирования.
        /// </summary>
        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Item selectedItem = (Item)ItemsListBox.SelectedItem;
                ItemNameTextBox.Text = selectedItem.Name;
                ItemInfoTextBox.Text = selectedItem.Info;
                ItemCostTextBox.Text = selectedItem.Cost.ToString();
                ItemIdTextBox.Text = selectedItem.Id.ToString();
                ItemsCategoryComboBox.Text = selectedItem.Category.ToString();
            }
            catch (System.NullReferenceException)
            {
            }
        }
        /// <summary>
        /// при выборе нового значения в выпадающем списке, категория присваиваевается товару.
        /// </summary>>
        private void ItemsCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category newCategory = (Category)ItemsCategoryComboBox.SelectedItem;
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            if (ItemsListBox.SelectedItem != null)
            {
                selectedItem.Category = newCategory;
                ListBoxUpdate();
            }
        }
        /// <summary>
        /// Очищает текстовые поля ввода данных о товаре.
        /// </summary>
        public void ClearFields()
        {
            ItemNameTextBox.Text = string.Empty;
            ItemInfoTextBox.Text = string.Empty;
            ItemCostTextBox.Text = string.Empty;
            ItemIdTextBox.Text = string.Empty;
        }
        /// <summary>
        /// Обновляет содержимое списка товаров в ListBox.
        /// Загружает все товары из коллекции _items.
        /// </summary>
        public void ListBoxUpdate()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
        }
        /// <summary>
        /// сохранение данных при редактировании названия
        /// </summary>
        private void ItemNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string newName = ItemNameTextBox.Text;
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            if (ItemsListBox.SelectedItem != null)
            {
                    selectedItem.Name = newName;
            }
        }
        /// <summary>
        /// сохранение данных при редактировании описания
        /// </summary>
        private void ItemInfoTextBox_TextChanged(object sender, EventArgs e)
        {
            string newInfo = ItemInfoTextBox.Text;
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            if (ItemsListBox.SelectedItem != null)
            {
                selectedItem.Info = newInfo;
            }
        }
        /// <summary>
        /// сохранение данных при редактировании цены
        /// </summary>
        private void ItemCostTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ItemsListBox.SelectedItem != null &&
                double.TryParse(ItemCostTextBox.Text, out double newCost)&&
                                newCost >= 0 && newCost <= 100000)
            {
                Item selectedItem = (Item)ItemsListBox.SelectedItem;
                selectedItem.Cost = newCost;
            }
        }
    }
}