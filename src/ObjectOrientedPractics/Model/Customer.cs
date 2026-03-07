using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет покупателя с Id, именем и адресом доставки.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Счетчик для генерации Id
        /// </summary>
        private static int idCounter = 1;

        /// <summary>
        /// Id покупателя.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Полное имя покупателя.
        /// </summary>
        private string _fullname;

        /// <summary>
        /// Адрес доставки покупателя.
        /// </summary>
        private Address _address;
        /// <summary>
        /// Корзина товаров покупателя
        /// Композиция: время жизни корзины совпадает с временем жизни покупателя.
        /// </summary>
        private Cart _cart;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Customer"/>
        /// </summary>
        /// <param name="fullname">Полное имя покупателя</param>
        /// <param name="address">Адрес доставки.</param>
        public Customer(string fullname, Address address)
        {
            _id = idCounter++;
            FullName = fullname;
            Address = address;
            Cart = new Cart();// Создаем корзину внутри конструктора (композиция)
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Customer"/>
        /// </summary>
        public Customer()
        {
            _id = idCounter++;
        }

        /// <summary>
        /// Возвращает Id покупателя.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Возвращает полное имя покупателя.
        /// </summary>
        public string FullName
        {
            get
            {
                return _fullname;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 500, nameof(FullName));
                ValueValidator.AssertStringContainsOnlyLetters(value, nameof(FullName));
                _fullname = value;
            }
        }
        /// <summary>
        /// Возвращает  адрес доставки покупателя.
        /// </summary>
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public Cart Cart { get { return _cart; } set { _cart = value; } }
        /// <summary>
        /// Переопределение ToString()
        /// </summary>
        /// <returns>Id и полное имя покупателя</returns>
        public override string ToString()
        {
            return $"{Id} | {FullName}";
        }
    }
}