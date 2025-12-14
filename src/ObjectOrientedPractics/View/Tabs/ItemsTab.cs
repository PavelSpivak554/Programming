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

        }

        /// <summary>
        /// Список товаров, отображаемых на вкладке.
        /// </summary>
        private List<Item> _items = new List<Item>();

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
        /// Выполняет валидацию поля наименования товара.
        /// Проверяет, что строка не пустая.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void NametextBox_Validating()
        {
            string Name = ItemNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(Name))
            {
                ItemNameTextBox.BackColor = Color.Red;
            }
            else
            {
                ItemNameTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Выполняет валидацию поля описания товара.
        /// Проверяет, что строка не пустая.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void InfotextBox_Validating()
        {
            string Info = ItemInfoTextBox.Text;
            if (string.IsNullOrWhiteSpace(Info))
            {
                ItemInfoTextBox.BackColor = Color.Red;
            }
            else
            {
                ItemInfoTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Выполняет валидацию поля стоимости товара.
        /// Проверяет, что значение может быть преобразовано в double и является неотрицательным.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void CosttextBox_Validating()
        {
            string Cost = ItemCostTextBox.Text;
            if (!double.TryParse(Cost, out double cost) || cost < 0)
            {
                ItemCostTextBox.BackColor = Color.Red;
            }
            else
            {
                ItemCostTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Выполняет комплексную валидацию всех полей ввода.
        /// </summary>
        private bool ItemsValidating()
        {
            NametextBox_Validating();
            InfotextBox_Validating();
            CosttextBox_Validating();

            if (ItemCostTextBox.BackColor == Color.White &&
                ItemInfoTextBox.BackColor == Color.White &&
                ItemNameTextBox.BackColor == Color.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки добавления товара.
        /// Создает новый товар на основе введенных данных и добавляет его в коллекцию.
        /// </summary>

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ItemsValidating())
                {
                    string itemName = ItemNameTextBox.Text;
                    string itemInfo = ItemInfoTextBox.Text;
                    double itemCost = Convert.ToDouble(ItemCostTextBox.Text);
                    Category itemCategory = (Category)Enum.Parse(typeof(Category), ItemsCategoryComboBox.Text); // преобразует строку в значение enum.
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
            if (ItemsListBox.SelectedItem != null)
            {
                Item selectedItem = (Item)ItemsListBox.SelectedItem;
                selectedItem.Category = newCategory;
                ListBoxUpdate();
            }

        }
    }
}