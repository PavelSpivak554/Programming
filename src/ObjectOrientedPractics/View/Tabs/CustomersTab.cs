using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет вкладку для работы с покупателями.
    /// Обеспечивает добавление, удаление и редактирование информации о покупателях.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей, отображаемых на вкладке.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomersTab"/>.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            InitializeVisualValidation();
            _customers = new List<Customer>();
        }

        /// <summary>
        /// Получает или задает список покупателей для отображения на вкладке.
        /// При установке нового списка обновляет отображение в ListBox.
        /// </summary>
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                if (value == null)
                {
                    _customers = new List<Customer>();
                }
                else
                {
                    _customers = value;
                }
                UpdateListBox();
            }
        }

        /// <summary>
        /// Инициализация визуальной валидации полей
        /// </summary>
        private void InitializeVisualValidation()
        {
            CustomerNameTextBox.TextChanged += (s, e) => ValidateFullNameVisual();
        }

        /// <summary>
        /// Очищает текстовые поля ввода данных о покупателе.
        /// </summary>
        public void ClearFields()
        {
            CustomerNameTextBox.Text = string.Empty;
            CustomerIdTextBox.Text = string.Empty;
            addressControl1.ClearFields();
        }

        /// <summary>
        /// Обновляет содержимое списка покупателей в ListBox.
        /// Использует DataSource для эффективного обновления.
        /// </summary>
        public void UpdateListBox()
        {
            CustomersListBox.DataSource = null;
            CustomersListBox.DataSource = _customers;
            CustomersListBox.DisplayMember = "FullName";
        }

        /// <summary>
        /// Выполняет валидацию поля имени покупателя.
        /// Проверяет, что строка не пустая и содержит только буквы.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private bool ValidateFullNameVisual()
        {
            bool isValid = string.IsNullOrEmpty(CustomerNameTextBox.Text) ||
                          (CustomerNameTextBox.Text.Length <= 500);
            CustomerNameTextBox.BackColor = isValid ? Color.White : Color.LightPink;
            return isValid;
        }

        /// <summary>
        /// Выполняет комплексную валидацию всех полей ввода.
        /// </summary>
        private bool CustomerValidating()
        {
            bool isAddressValid = addressControl1.ValidateAddress();
            bool isNameValid = !string.IsNullOrEmpty(CustomerNameTextBox.Text) &&
                              CustomerNameTextBox.Text.Length <= 500;

            // Подсвечиваем поле имени
            CustomerNameTextBox.BackColor = isNameValid ? Color.White : Color.LightPink;

            return isNameValid && isAddressValid;
        }

        /// <summary>
        /// Обрабатывает событие изменения выбранного элемента в списке покупателей.
        /// Загружает данные выбранного покупателя в текстовые поля для редактирования.
        /// </summary>
        private void CustomersListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer selectedCustomer)
            {
                CustomerNameTextBox.Text = selectedCustomer.FullName;
                CustomerIdTextBox.Text = selectedCustomer.Id.ToString();
                addressControl1.Address = selectedCustomer.Address;
            }
            else
            {
                ClearFields();
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки добавления покупателя.
        /// Создает нового покупателя на основе введенных данных и добавляет его в коллекцию.
        /// </summary>
        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomerValidating())
                {
                    string customerName = CustomerNameTextBox.Text;
                    Address address = addressControl1.Address;
                    Customer customer = new Customer(customerName, address);
                    _customers.Add(customer);
                    UpdateListBox();
                    CustomersListBox.SelectedItem = customer;
                }
                else
                {
                    MessageBox.Show("Невозможно добавить покупателя, введите корректные данные в выделенные поля",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Невозможно добавить покупателя, входные данные некорректны",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает событие нажатия кнопки удаления покупателя.
        /// Удаляет выбранного покупателя из коллекции и обновляет интерфейс.
        /// </summary>
        private void CustomerRemoveButton_Click(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer selectedItem)
            {
                _customers.Remove(selectedItem);
                UpdateListBox();
                ClearFields();
            }
        }

        
    }
}