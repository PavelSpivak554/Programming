using ObjectOrientedPractics.Services;
using Programming.Models;
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
    internal class Customer
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
        private string _address;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Customer"/>
        /// </summary>
        /// <param name="fullname">Полное имя покупателя</param>
        /// <param name="address">Адрес доставки.</param>
        public Customer(string fullname, string address)
        {
            _id = idCounter++;
            FullName = fullname;
            Address = address;
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
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, nameof(Address));
                _address = value;
            }
        }
    }
}