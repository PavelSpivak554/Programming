using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Model
{
    public class Address
    {
        private int _index;
        private string _country;
        private string _city;
        private string _street;
        private string _building;
        private string _apartment;

        /// <summary>
        /// Конструктор по умолчанию. Инициализирует поля значениями по умолчанию.
        /// </summary>
        public Address()
        {
            _index = 100000;
            _country = "Россия";
            _city = "Москва";
            _street = "Ленина";
            _building = "1";
            _apartment = "1";
        }

        /// <summary>
        /// Конструктор с параметрами для инициализации всех полей адреса.
        /// </summary>
        /// <param name="index">Почтовый индекс (6-значное число)</param>
        /// <param name="country">Страна/регион (до 50 символов)</param>
        /// <param name="city">Город/населенный пункт (до 50 символов)</param>
        /// <param name="street">Улица (до 100 символов)</param>
        /// <param name="building">Номер дома (до 10 символов)</param>
        /// <param name="apartment">Номер квартиры/помещения (до 10 символов)</param>
        public Address(int index, string country, string city, string street, string building, string apartment)
        {
            Index = index;
            Country = country;
            City = city;
            Street = street;
            Building = building;
            Apartment = apartment;
        }
        /// <summary>
        /// Почтовый индекс. Должен быть шестизначным числом.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если значение не является шестизначным числом</exception>
        public int Index
        {
            get { return _index; }
            set
            {
                if (value < 100000 || value > 999999)
                {
                    throw new ArgumentException("Индекс должен быть шестизначным числом.");
                }
                _index = value;
            }
        }

        /// <summary>
        /// Страна или регион. Не более 50 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или превышает 50 символов</exception>
        public string Country
        {
            get { return _country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Страна не может быть пустой.");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Название страны не должно превышать 50 символов.");
                }
                _country = value;
            }
        }

        /// <summary>
        /// Город или населенный пункт. Не более 50 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или превышает 50 символов</exception>
        public string City
        {
            get { return _city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Город не может быть пустым.");
                }
                if (value.Length > 50)
                {
                    throw new ArgumentException("Название города не должно превышать 50 символов.");
                }
                _city = value;
            }
        }

        /// <summary>
        /// Улица. Не более 100 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или превышает 100 символов</exception>
        public string Street
        {
            get { return _street; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Улица не может быть пустой.");
                }
                if (value.Length > 100)
                {
                    throw new ArgumentException("Название улицы не должно превышать 100 символов.");
                }
                _street = value;
            }
        }

        /// <summary>
        /// Номер дома. Может содержать цифры, буквы и специальные символы. Не более 10 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка пустая или превышает 10 символов</exception>
        public string Building
        {
            get { return _building; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Номер дома не может быть пустым.");
                }
                if (value.Length > 10)
                {
                    throw new ArgumentException("Номер дома не должен превышать 10 символов.");
                }
                _building = value;
            }
        }
        /// <summary>
        /// Номер квартиры или помещения. Может быть null для частных домов. Не более 10 символов.
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка превышает 10 символов</exception>
        public string Apartment
        {
            get { return _apartment; }
            set
            {
                // Убираем проверку на пустоту - квартиры может не быть
                if (value != null && value.Length > 10)
                {
                    throw new ArgumentException("Номер квартиры не должен превышать 10 символов.");
                }
                _apartment = value ?? string.Empty; // Если null, присваиваем пустую строку
            }
        }
    }
}