using ObjectOrientedPractics.Model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Controls
{
    public partial class AddressControl : UserControl
    {
        private Address _address;
        private bool _isAddressUpdating = false; // Флаг для предотвращения рекурсии

        public event EventHandler AddressChanged;

        public AddressControl()
        {
            InitializeComponent();
            InitializeVisualValidation();
            SubscribeToTextChangedEvents();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get
            {
                // При получении возвращаем текущий адрес
                return _address;
            }
            set
            {
                // Если адрес изменился
                if (_address != value)
                {
                    _address = value;
                    // Обновляем поля на форме
                    UpdateControlsFromAddress();
                }
            }
        }

        /// <summary>
        /// Подписка на события изменения текста
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
        /// Общий обработчик изменения текста
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Если идет обновление полей из адреса - игнорируем
            if (_isAddressUpdating) return;

            // Если адрес не инициализирован - создаем новый
            if (_address == null)
            {
                _address = new Address();
            }

            try
            {
                // Пытаемся обновить адрес из полей
                UpdateAddressFromControls();
                // Вызываем событие об изменении адреса
                AddressChanged?.Invoke(this, EventArgs.Empty);
            }
            catch
            {
                // Игнорируем ошибки валидации при вводе
            }
        }

        /// <summary>
        /// Визуальная подсветка полей
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

        private void ValidatePostIndexVisual()
        {
            bool isValid = string.IsNullOrEmpty(PostIndexTextBox.Text) ||
                          (int.TryParse(PostIndexTextBox.Text, out int index) &&
                           index >= 100000 && index <= 999999);
            PostIndexTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        private void ValidateCountryVisual()
        {
            bool isValid = string.IsNullOrEmpty(CountryTextBox.Text) || CountryTextBox.Text.Length <= 50;
            CountryTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        private void ValidateCityVisual()
        {
            bool isValid = string.IsNullOrEmpty(CityTextBox.Text) || CityTextBox.Text.Length <= 50;
            CityTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        private void ValidateStreetVisual()
        {
            bool isValid = string.IsNullOrEmpty(StreetTextBox.Text) || StreetTextBox.Text.Length <= 100;
            StreetTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        private void ValidateBuildingVisual()
        {
            bool isValid = string.IsNullOrEmpty(BuildingTextBox.Text) || BuildingTextBox.Text.Length <= 10;
            BuildingTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        private void ValidateApartmentVisual()
        {
            bool isValid = string.IsNullOrEmpty(ApartmentTextBox.Text) || ApartmentTextBox.Text.Length <= 10;
            ApartmentTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Обновляет поля на форме из объекта Address
        /// </summary>
        private void UpdateControlsFromAddress()
        {
            // Устанавливаем флаг, чтобы не вызывать TextChanged события
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
                // Снимаем флаг
                _isAddressUpdating = false;
            }
        }

        /// <summary>
        /// Обновляет объект Address из полей формы
        /// </summary>
        private void UpdateAddressFromControls()
        {
            if (_address == null) return;

            // Сохраняем старые значения для проверки изменений
            int oldIndex = _address.Index;
            string oldCountry = _address.Country;
            string oldCity = _address.City;
            string oldStreet = _address.Street;
            string oldBuilding = _address.Building;
            string oldApartment = _address.Apartment;

            // Обновляем индекс
            if (int.TryParse(PostIndexTextBox.Text, out int index))
            {
                _address.Index = index;
            }

            // Обновляем остальные поля
            _address.Country = CountryTextBox.Text ?? "";
            _address.City = CityTextBox.Text ?? "";
            _address.Street = StreetTextBox.Text ?? "";
            _address.Building = BuildingTextBox.Text ?? "";
            _address.Apartment = ApartmentTextBox.Text ?? "";
        }

        /// <summary>
        /// Проверка всех полей адреса
        /// </summary>
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
        /// Очистка всех полей
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