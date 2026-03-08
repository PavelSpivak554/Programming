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
        private List<Customer> _customers = new List<Customer>();
        private AddressControl _addressControl1 = new AddressControl();
        private Customer _selectedCustomer = null;

        /// <summary>
        /// Открытое свойство для доступа к списку покупателей вкладки
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value ?? new List<Customer>();
                ListBoxUpdate();
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomersTab"/>.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            InitializeVisualValidation();

        }        
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
        /// Загружает всех покупателей из коллекции _customers.
        /// </summary>
        public void ListBoxUpdate()
        {
            int selectedIndex = CustomersListBox.SelectedIndex;
            CustomersListBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomersListBox.Items.Add(customer);
            }
            if (selectedIndex >= 0 && selectedIndex < CustomersListBox.Items.Count)
            {
                CustomersListBox.SelectedIndex = selectedIndex;
            }
        }

        /// <summary>
        /// Выполняет валидацию поля имени покупателя.
        /// Проверяет, что строка не пустая и содержит только буквы.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private bool ValidateFullNameVisual()
        {
            bool isValid = string.IsNullOrEmpty(CustomerNameTextBox.Text) ||
                          (CustomerNameTextBox.Text.Length >= 500) ||
                          CustomerNameTextBox.Text.All(char.IsLetter);
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
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer selectedCustomer)
            {
                _selectedCustomer = selectedCustomer;

                CustomerNameTextBox.Text = selectedCustomer.FullName;
                CustomerIdTextBox.Text = selectedCustomer.Id.ToString();
                addressControl1.Address = selectedCustomer.Address;
            }
            else
            {
                _selectedCustomer = null;
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
                    ListBoxUpdate();
                    //ClearFields();
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
        /// Обрабатывает событие нажатия кнопки удаления покупателя.
        /// Удаляет выбранного покупателя из коллекции и обновляет интерфейс.
        /// </summary>
        private void CustomerRemoveButton_Click(object sender, EventArgs e)
        {
            Customer selectedItem = (Customer)CustomersListBox.SelectedItem;
            _customers.Remove(selectedItem);
            ListBoxUpdate();
            ClearFields();
        }

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedCustomer != null && ValidateFullNameVisual())
            {
                _selectedCustomer.FullName = CustomerNameTextBox.Text;

                // обновляем ListBox чтобы имя изменилось
                ListBoxUpdate();
                CustomersListBox.SelectedItem = _selectedCustomer;
            }
        }
    }
}