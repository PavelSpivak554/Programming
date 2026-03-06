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

namespace ObjectOrientedPractics.View.Controls
{
    public partial class AddressControl : UserControl
    {
        private Address _address = new Address();
        public event EventHandler AddressChanged;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Address Address
        {
            get
            {
                UpdateAddressFromControls();
                return _address;
            }
            set
            {
                _address = value;
                UpdateControlsFromAddress();
            }
        }

        public AddressControl()
        {
            InitializeComponent();
            InitializeVisualValidation();
        }

        /// <summary>
        /// Визуальная подсветка полей вместо блокирующей валидации
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
        /// Визуальная валидация почтового индекса
        /// </summary>
        private void ValidatePostIndexVisual()
        {
            bool isValid = string.IsNullOrEmpty(PostIndexTextBox.Text) ||
                          (int.TryParse(PostIndexTextBox.Text, out int index) &&
                           index >= 100000 &&
                           index <= 999999);

            PostIndexTextBox.BackColor = isValid ? Color.White : Color.LightPink;
            
        }

        /// <summary>
        /// Визуальная валидация страны
        /// </summary>
        private void ValidateCountryVisual()
        {
            bool isValid = string.IsNullOrEmpty(CountryTextBox.Text) || CountryTextBox.Text.Length <= 50;
            CountryTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Визуальная валидация города
        /// </summary>
        private void ValidateCityVisual()
        {
            bool isValid = string.IsNullOrEmpty(CityTextBox.Text) || CityTextBox.Text.Length <= 50;
            CityTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Визуальная валидация улицы
        /// </summary>
        private void ValidateStreetVisual()
        {
            bool isValid = string.IsNullOrEmpty(StreetTextBox.Text) || StreetTextBox.Text.Length <= 100;
            StreetTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Визуальная валидация номера дома
        /// </summary>
        private void ValidateBuildingVisual()
        {
            bool isValid = string.IsNullOrEmpty(BuildingTextBox.Text) || BuildingTextBox.Text.Length <= 10;
            BuildingTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Визуальная валидация номера квартиры
        /// </summary>
        private void ValidateApartmentVisual()
        {
            bool isValid = string.IsNullOrEmpty(ApartmentTextBox.Text) || ApartmentTextBox.Text.Length <= 10;
            ApartmentTextBox.BackColor = isValid ? Color.White : Color.LightPink;
        }

        /// <summary>
        /// Проверка всех полей адреса
        /// </summary>
        public bool ValidateAddress()
        {
            bool postIndexValid = !string.IsNullOrEmpty(PostIndexTextBox.Text) ||
                                 (int.TryParse(PostIndexTextBox.Text, out int index) && index >= 100000 && index <= 999999);
            bool countryValid = !string.IsNullOrEmpty(CountryTextBox.Text) && CountryTextBox.Text.Length <= 50;
            bool cityValid = !string.IsNullOrEmpty(CityTextBox.Text) && CityTextBox.Text.Length <= 50;
            bool streetValid = !string.IsNullOrEmpty(StreetTextBox.Text) && StreetTextBox.Text.Length <= 100;
            bool buildingValid = !string.IsNullOrEmpty(BuildingTextBox.Text) && BuildingTextBox.Text.Length <= 10;
            bool apartmentValid = !string.IsNullOrEmpty(ApartmentTextBox.Text) && ApartmentTextBox.Text.Length <= 10;

            // Визуально подсвечиваем поля
            PostIndexTextBox.BackColor = postIndexValid ? Color.White : Color.LightPink;
            CountryTextBox.BackColor = countryValid ? Color.White : Color.LightPink;
            CityTextBox.BackColor = cityValid ? Color.White : Color.LightPink;
            StreetTextBox.BackColor = streetValid ? Color.White : Color.LightPink;
            BuildingTextBox.BackColor = buildingValid ? Color.White : Color.LightPink;
            ApartmentTextBox.BackColor = buildingValid ? Color.White : Color.LightPink;

            return postIndexValid && countryValid && cityValid && streetValid && buildingValid && apartmentValid;
        }

        private void UpdateControlsFromAddress()
        {
            if (_address == null) return;

            PostIndexTextBox.Text = _address.Index.ToString();
            CountryTextBox.Text = _address.Country;
            CityTextBox.Text = _address.City;
            StreetTextBox.Text = _address.Street;
            BuildingTextBox.Text = _address.Building;
            ApartmentTextBox.Text = _address.Apartment;
            AddressChanged?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateAddressFromControls()
        {
            if (_address == null)
                _address = new Address();

            if (int.TryParse(PostIndexTextBox.Text, out int index))
            {
                _address.Index = index;
            }
            else
            {
                _address.Index = 100000;
            }

            _address.Country = CountryTextBox.Text ?? "";
            _address.City = CityTextBox.Text ?? "";
            _address.Street = StreetTextBox.Text ?? "";
            _address.Building = BuildingTextBox.Text ?? "";
            _address.Apartment = ApartmentTextBox.Text ?? "";
            AddressChanged?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Очистка всех полей
        /// </summary>
        public void ClearFields()
        {
            PostIndexTextBox.Text = "";
            CountryTextBox.Text = "";
            CityTextBox.Text = "";
            StreetTextBox.Text = "";
            BuildingTextBox.Text = "";
            ApartmentTextBox.Text = "";
        }

        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Принудительно обновляет визуальную валидацию всех полей
        /// </summary>
        public void RefreshValidation()
        {

            ValidatePostIndexVisual();
            ValidateCountryVisual();
            ValidateCityVisual();
            ValidateStreetVisual();
            ValidateBuildingVisual();
            ValidateApartmentVisual();
        }
    }
}