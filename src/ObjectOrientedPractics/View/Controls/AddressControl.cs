using ObjectOrientedPractics.Model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Controls
{
    /// <summary>
    /// Представляет пользовательский элемент управления для ввода и редактирования адреса доставки.
    /// Содержит поля для почтового индекса, страны, города, улицы, номера дома и квартиры.
    /// Обеспечивает визуальную валидацию вводимых данных.
    /// </summary>
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Объект адреса, связанный с элементом управления.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Флаг для предотвращения рекурсивных вызовов при обновлении данных.
        /// </summary>
        private bool _isAddressUpdating = false;

        /// <summary>
        /// Событие, возникающее при изменении адреса.
        /// </summary>
        public event EventHandler AddressChanged;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddressControl"/>.
        /// Выполняет начальную настройку компонентов и подписывается на события.
        /// </summary>
        public AddressControl()
        {
            InitializeComponent();
            InitializeVisualValidation();
            SubscribeToTextChangedEvents();
        }

        /// <summary>
        /// Получает или задает объект адреса, отображаемый и редактируемый в элементе управления.
        /// При установке нового значения автоматически обновляет поля на форме.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    UpdateControlsFromAddress();
                }
            }
        }

        /// <summary>
        /// Подписывается на события изменения текста во всех текстовых полях.
        /// </summary>
        private void SubscribeToTextChangedEvents()
        {
            PostIndexTextBox.TextChanged += TextBox_TextChanged;
            CountryTextBox.TextChanged += TextBox_TextChanged;
            CityTextBox.TextChanged += TextBox_TextChanged;
            StreetTextBox.TextChanged += TextBox_TextChanged;
            BuildingTextBox.TextChanged += TextBox_TextChanged;
            ApartmentTextBox.TextChanged += TextBox_TextChanged;
        }

        /// <summary>
        /// Обрабатывает изменение текста в любом из полей адреса.
        /// Обновляет объект Address и вызывает событие AddressChanged.
        /// </summary>
        /// <param name="sender">Источник события.</param>
        /// <param name="e">Аргументы события.</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_isAddressUpdating) return;

            if (_address == null)
            {
                _address = new Address();
            }

            try
            {
                UpdateAddressFromControls();
                AddressChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                // Игнорируем ошибки валидации при вводе
            }
        }

        /// <summary>
        /// Инициализирует визуальную валидацию полей.
        /// Подписывает обработчики проверки на события изменения текста.
        /// </summary>
        private void InitializeVisualValidation()
        {
            PostIndexTextBox.TextChanged += (s, e) => ValidatePostIndexVisual();
            CountryTextBox.TextChanged += (s, e) => ValidateCountryVisual();
            CityTextBox.TextChanged += (s, e) => ValidateCityVisual();
            StreetTextBox.TextChanged += (s, e) => ValidateStreetVisual();
            BuildingTextBox.TextChanged += (s, e) => ValidateBuildingVisual();
            ApartmentTextBox.TextChanged += (s, e) => ValidateApartmentVisual();
        }

        /// <summary>
        /// Выполняет визуальную проверку почтового индекса.
        /// Подсвечивает поле красным, если значение не соответствует требованиям.
        /// </summary>
        private void ValidatePostIndexVisual()
        {
            bool isValid = string.IsNullOrEmpty(PostIndexTextBox.Text) ||
                          (int.TryParse(PostIndexTextBox.Text, out int index) &&
                           index >= 100000 && index <= 999999);
            PostIndexTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Выполняет визуальную проверку названия страны.
        /// Подсвечивает поле красным, если длина превышает 50 символов.
        /// </summary>
        private void ValidateCountryVisual()
        {
            bool isValid = string.IsNullOrEmpty(CountryTextBox.Text) || CountryTextBox.Text.Length <= 50;
            CountryTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Выполняет визуальную проверку названия города.
        /// Подсвечивает поле красным, если длина превышает 50 символов.
        /// </summary>
        private void ValidateCityVisual()
        {
            bool isValid = string.IsNullOrEmpty(CityTextBox.Text) || CityTextBox.Text.Length <= 50;
            CityTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Выполняет визуальную проверку названия улицы.
        /// Подсвечивает поле красным, если длина превышает 100 символов.
        /// </summary>
        private void ValidateStreetVisual()
        {
            bool isValid = string.IsNullOrEmpty(StreetTextBox.Text) || StreetTextBox.Text.Length <= 100;
            StreetTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Выполняет визуальную проверку номера дома.
        /// Подсвечивает поле красным, если длина превышает 10 символов.
        /// </summary>
        private void ValidateBuildingVisual()
        {
            bool isValid = string.IsNullOrEmpty(BuildingTextBox.Text) || BuildingTextBox.Text.Length <= 10;
            BuildingTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Выполняет визуальную проверку номера квартиры.
        /// Подсвечивает поле красным, если длина превышает 10 символов.
        /// </summary>
        private void ValidateApartmentVisual()
        {
            bool isValid = string.IsNullOrEmpty(ApartmentTextBox.Text) || ApartmentTextBox.Text.Length <= 10;
            ApartmentTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Обновляет значения текстовых полей на основе данных объекта Address.
        /// </summary>
        private void UpdateControlsFromAddress()
        {
            _isAddressUpdating = true;

            try
            {
                if (_address != null)
                {
                    PostIndexTextBox.Text = _address.Index.ToString();
                    CountryTextBox.Text = _address.Country;
                    CityTextBox.Text = _address.City;
                    StreetTextBox.Text = _address.Street;
                    BuildingTextBox.Text = _address.Building;
                    ApartmentTextBox.Text = _address.Apartment;
                }
                else
                {
                    ClearFields();
                }
            }
            finally
            {
                _isAddressUpdating = false;
            }
        }

        /// <summary>
        /// Обновляет данные объекта Address на основе значений текстовых полей.
        /// </summary>
        private void UpdateAddressFromControls()
        {
            if (_address == null) return;

            if (int.TryParse(PostIndexTextBox.Text, out int index))
            {
                _address.Index = index;
            }

            _address.Country = CountryTextBox.Text ?? "";
            _address.City = CityTextBox.Text ?? "";
            _address.Street = StreetTextBox.Text ?? "";
            _address.Building = BuildingTextBox.Text ?? "";
            _address.Apartment = ApartmentTextBox.Text ?? "";
        }

        /// <summary>
        /// Выполняет полную проверку всех полей адреса.
        /// </summary>
        /// <returns>Возвращает true, если все поля заполнены корректно; иначе false.</returns>
        public bool ValidateAddress()
        {
            bool postIndexValid = !string.IsNullOrEmpty(PostIndexTextBox.Text) &&
                                 (int.TryParse(PostIndexTextBox.Text, out int index) &&
                                  index >= 100000 && index <= 999999);
            bool countryValid = !string.IsNullOrEmpty(CountryTextBox.Text) && CountryTextBox.Text.Length <= 50;
            bool cityValid = !string.IsNullOrEmpty(CityTextBox.Text) && CityTextBox.Text.Length <= 50;
            bool streetValid = !string.IsNullOrEmpty(StreetTextBox.Text) && StreetTextBox.Text.Length <= 100;
            bool buildingValid = !string.IsNullOrEmpty(BuildingTextBox.Text) && BuildingTextBox.Text.Length <= 10;
            bool apartmentValid = !string.IsNullOrEmpty(ApartmentTextBox.Text) && ApartmentTextBox.Text.Length <= 10;

            PostIndexTextBox.BackColor = postIndexValid ? Color.White : Color.LightPink;
            CountryTextBox.BackColor = countryValid ? Color.White : Color.LightPink;
            CityTextBox.BackColor = cityValid ? Color.White : Color.LightPink;
            StreetTextBox.BackColor = streetValid ? Color.White : Color.LightPink;
            BuildingTextBox.BackColor = buildingValid ? Color.White : Color.LightPink;
            ApartmentTextBox.BackColor = apartmentValid ? Color.White : Color.LightPink;

            return postIndexValid && countryValid && cityValid && streetValid && buildingValid && apartmentValid;
        }

        /// <summary>
        /// Очищает все текстовые поля элемента управления.
        /// </summary>
        public void ClearFields()
        {
            _isAddressUpdating = true;
            try
            {
                PostIndexTextBox.Text = "";
                CountryTextBox.Text = "";
                CityTextBox.Text = "";
                StreetTextBox.Text = "";
                BuildingTextBox.Text = "";
                ApartmentTextBox.Text = "";
            }
            finally
            {
                _isAddressUpdating = false;
            }
        }
    }
}