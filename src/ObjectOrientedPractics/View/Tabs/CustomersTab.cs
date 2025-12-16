using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;
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

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CustomersTab"/>.
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
            InitializeVisualValidation();
        }

        /// <summary>
        /// Очищает текстовые поля ввода данных о покупателе.
        /// </summary>
        public void ClearFields()
        {
            CustomerNameTextBox.Text = string.Empty;
            CustomerIdTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Обновляет содержимое списка покупателей в ListBox.
        /// Загружает всех покупателей из коллекции _customers.
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
        /// Выполняет валидацию поля имени покупателя.
        /// Проверяет, что строка не пустая и содержит только буквы.
        /// Изменяет цвет фона текстового поля в зависимости от результата проверки.
        /// </summary>
        private void NametextBox_Validating()
        {
            string Name = CustomerNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(Name) || !Name.All(char.IsLetter))
            {
                CustomerNameTextBox.BackColor = Color.Red;
            }
            else
            {
                CustomerNameTextBox.BackColor = Color.White;
            }
        }


        /// <summary>
        /// Выполняет комплексную валидацию всех полей ввода.
        /// </summary>
        private bool CustomerValidating()
        {
            NametextBox_Validating();
            if (CustomerNameTextBox.BackColor == Color.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Обрабатывает событие изменения выбранного элемента в списке покупателей.
        /// Загружает данные выбранного покупателя в текстовые поля для редактирования.
        /// </summary>
        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Customer selectedItem = (Customer)CustomersListBox.SelectedItem;
                CustomerNameTextBox.Text = selectedItem.FullName;
                CustomerIdTextBox.Text = selectedItem.Id.ToString();
            }
            catch (System.NullReferenceException)
            {

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
                    //string address = AddressTextBox.Text;
                    Customer customer = new Customer(customerName, address);
                    _customers.Add(customer);
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

        private void InitializeVisualValidation()
        {
            CustomerNameTextBox.TextChanged += (s, e) => ValidateFullNameVisual();
            
        }

        private void ValidateFullNameVisual()
        {
            bool isValid = string.IsNullOrEmpty(CustomerNameTextBox.Text) ||
                          (CustomerNameTextBox.Text.Length >= 500) ||
                          CustomerNameTextBox.Text.All(char.IsLetter);
            CustomerNameTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

    }
}