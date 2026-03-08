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
    public partial class CustomersTab : UserControl
    {
        private List<Customer> _customers = new List<Customer>();
        private Customer _selectedCustomer = null;
        private bool _isSelectedIndexChanging = false; // Флаг для предотвращения рекурсии

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

        public CustomersTab()
        {
            InitializeComponent();
            InitializeVisualValidation();
            addressControl1.AddressChanged += AddressControl_AddressChanged;
        }

        private void InitializeVisualValidation()
        {
            CustomerNameTextBox.TextChanged += (s, e) => ValidateFullNameVisual();
        }

        private void AddressControl_AddressChanged(object sender, EventArgs e)
        {
            // Обновляем адрес только если есть выбранный покупатель и это не режим создания нового
            if (_selectedCustomer != null && !_isSelectedIndexChanging)
            {
                _selectedCustomer.Address = addressControl1.Address;
                ListBoxUpdate();
                CustomersListBox.SelectedItem = _selectedCustomer;
            }
        }

        private bool ValidateFullNameVisual()
        {
            string fullName = CustomerNameTextBox.Text;

            // Если поле пустое - не подсвечиваем
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

        private bool CustomerValidating()
        {
            bool isAddressValid = addressControl1.ValidateAddress();
            bool isNameValid = !string.IsNullOrEmpty(CustomerNameTextBox.Text) &&
                              CustomerNameTextBox.Text.Length <= 200;

            CustomerNameTextBox.BackColor = isNameValid ? Color.White : Color.LightPink;

            return isNameValid && isAddressValid;
        }

        public void ClearFields()
        {
            CustomerNameTextBox.Text = string.Empty;
            CustomerIdTextBox.Text = string.Empty;
            addressControl1.ClearFields();
        }

        public void ListBoxUpdate()
        {
            CustomersListBox.Items.Clear();
            foreach (var customer in _customers)
            {
                CustomersListBox.Items.Add(customer);
            }
        }

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

        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CustomerValidating())
                {
                    // Снимаем выделение с текущего элемента перед созданием нового
                    _isSelectedIndexChanging = true;
                    CustomersListBox.SelectedItem = null;
                    _isSelectedIndexChanging = false;

                    // Создаем нового покупателя
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

                    // Обновляем список
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

        private void CustomerRemoveButton_Click(object sender, EventArgs e)
        {
            if (CustomersListBox.SelectedItem is Customer selectedItem)
            {
                int selectedIndex = CustomersListBox.SelectedIndex;

                // Удаляем покупателя
                _customers.Remove(selectedItem);

                // Обновляем список
                ListBoxUpdate();

                
            }
        }

        private void CustomerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Обновляем имя только если есть выбранный покупатель и это не режим создания нового
            if (_selectedCustomer != null && ValidateFullNameVisual() && !_isSelectedIndexChanging)
            {
                _selectedCustomer.FullName = CustomerNameTextBox.Text;

                // Обновляем отображение в ListBox
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