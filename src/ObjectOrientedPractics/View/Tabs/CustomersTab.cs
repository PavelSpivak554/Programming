using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет вкладку для управления покупателями.
    /// Позволяет добавлять, удалять и редактировать информацию о покупателях,
    /// включая их персональные данные и адреса доставки.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Список покупателей.
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Выбранный покупатель.
        /// </summary>
        private Customer _selectedCustomer = null;

        /// <summary>
        /// Флаг для предотвращения рекурсивных вызовов при изменении выбранного индекса.
        /// </summary>
        private bool _isSelectedIndexChanging = false;

        /// <summary>
        /// Получает или задает список покупателей.
        /// При установке нового значения обновляет список в интерфейсе.
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
        /// Выполняет начальную настройку компонентов и подписывается на события.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            InitializeVisualValidation();
            addressControl1.AddressChanged += AddressControl_AddressChanged;
        }

        /// <summary>
        /// Инициализирует визуальную валидацию полей ввода.
        /// Подписывает обработчики проверки на события изменения текста.
        /// </summary>
        private void InitializeVisualValidation()
        {
            CustomerNameTextBox.TextChanged += (s, e) => ValidateFullNameVisual();
        }

        /// <summary>
        /// Обрабатывает изменение адреса в элементе управления AddressControl.
        /// Обновляет адрес выбранного покупателя.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void AddressControl_AddressChanged(object sender, EventArgs e)
        {
            if (_selectedCustomer != null && !_isSelectedIndexChanging)
            {
                _selectedCustomer.Address = addressControl1.Address;
                ListBoxUpdate();
                CustomersListBox.SelectedItem = _selectedCustomer;
            }
        }

        /// <summary>
        /// Выполняет визуальную проверку поля имени покупателя.
        /// Подсвечивает поле красным, если имя не соответствует требованиям.
        /// </summary>
        /// <returns>Возвращает true, если имя корректно; иначе false.</returns>
        private bool ValidateFullNameVisual()
        {
            string fullName = CustomerNameTextBox.Text;

            if (string.IsNullOrEmpty(fullName))
            {
                CustomerNameTextBox.BackColor = Color.White;
                return false;
            }

            bool isValid = fullName.Length <= 500 &&
                           fullName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '-');

            CustomerNameTextBox.BackColor = isValid ? Color.White : Color.LightPink;
            return isValid;
        }

        /// <summary>
        /// Выполняет комплексную проверку всех полей покупателя.
        /// </summary>
        /// <returns>Возвращает true, если все поля заполнены корректно; иначе false.</returns>
        private bool CustomerValidating()
        {
            bool isAddressValid = addressControl1.ValidateAddress();
            bool isNameValid = !string.IsNullOrEmpty(CustomerNameTextBox.Text) &&
                              CustomerNameTextBox.Text.Length <= 200;

            CustomerNameTextBox.BackColor = isNameValid ? Color.White : Color.LightPink;

            return isNameValid && isAddressValid;
        }

        /// <summary>
        /// Очищает все поля ввода информации о покупателе.
        /// </summary>
        public void ClearFields()
        {
            CustomerNameTextBox.Text = string.Empty;
            CustomerIdTextBox.Text = string.Empty;
            addressControl1.ClearFields();
        }

        /// <summary>
        /// Обновляет содержимое списка покупателей в интерфейсе.
        /// </summary>
        public void ListBoxUpdate()
        {
            CustomersListBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomersListBox.Items.Add(customer);
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбранного элемента в списке покупателей.
        /// Загружает данные выбранного покупателя в поля для редактирования.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSelectedIndexChanging) return;

            _isSelectedIndexChanging = true;

            try
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
            finally
            {
                _isSelectedIndexChanging = false;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки добавления покупателя.
        /// Создает нового покупателя на основе введенных данных.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomerValidating())
                {
                    _isSelectedIndexChanging = true;
                    CustomersListBox.SelectedItem = null;
                    _isSelectedIndexChanging = false;

                    string customerName = CustomerNameTextBox.Text;

                    Address address = new Address(
                        addressControl1.Address.Index,
                        addressControl1.Address.Country,
                        addressControl1.Address.City,
                        addressControl1.Address.Street,
                        addressControl1.Address.Building,
                        addressControl1.Address.Apartment
                    );

                    Customer customer = new Customer(customerName, address);
                    _customers.Add(customer);

                    ListBoxUpdate();
                }
                else
                {
                    MessageBox.Show("Невозможно добавить покупателя, введите корректные данные в выделенные поля",
                        "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка при добавлении покупателя: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки удаления покупателя.
        /// Удаляет выбранного покупателя из списка.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CustomerRemoveButton_Click(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer selectedItem)
            {
                int selectedIndex = CustomersListBox.SelectedIndex;
                _customers.Remove(selectedItem);
                ListBoxUpdate();
            }
        }

        /// <summary>
        /// Обрабатывает изменение текста в поле имени покупателя.
        /// Обновляет имя выбранного покупателя в реальном времени.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_selectedCustomer != null && ValidateFullNameVisual() && !_isSelectedIndexChanging)
            {
                _selectedCustomer.FullName = CustomerNameTextBox.Text;

                int currentIndex = CustomersListBox.SelectedIndex;
                ListBoxUpdate();
                if (currentIndex >= 0)
                {
                    CustomersListBox.SelectedIndex = currentIndex;
                }
            }
        }
    }
}