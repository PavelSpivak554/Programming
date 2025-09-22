using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Models
{
    /// <summary>
    /// Представляет контакт с именем, фамилией и номером телефона
    /// </summary>
    internal class Contact
    {
        /// <summary>
        /// Имя контакта
        /// </summary>
        private string name;

        /// <summary>
        /// Фамилия контакта
        /// </summary>
        private string surname;

        /// <summary>
        /// Номер телефона контакта
        /// </summary>
        private string number;

        /// <summary>
        /// Создает экземпляр класса <see cref="Contact"/> с пустыми значениями
        /// </summary>
        public Contact() { }

        /// <summary>
        /// Создает экземпляр класса <see cref="Contact"/> с заданными параметрами
        /// </summary>
        /// <param name="name">Имя контакта</param>
        /// <param name="surname">Фамилия контакта</param>
        /// <param name="number">Номер телефона контакта</param>
        public Contact(string name, string surname, string number)
        {
            Name = name;
            Surname = surname;
            Number = number;
        }

        /// <summary>
        /// Возвращает или задает имя контакта
        /// </summary>

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                Validator.AssertStringContainsOnlyLetters(value, nameof(Name));
                name = value;
            }
        }

        /// <summary>
        /// Возвращает или задает фамилию контакта
        /// </summary>

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Значение не может быть пустым или состоять из пробелов.");
                }
                Validator.AssertStringContainsOnlyLetters(value, nameof(Surname));
                surname = value;  
            }
        }

        /// <summary>
        /// Возвращает или задает номер телефона контакта
        /// </summary>
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 11)
                {
                    throw new ArgumentException($"Невозможное значение номера телефона");
                }
                number = value;
            }
        }
    }
}