using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    /// <summary>
    /// Класс, представляющий контактную информацию.
    /// </summary>
    class Contact
    {
        private string _name;
        private string _phoneNumber;
        private string _email;

        /// <summary>
        /// Событие, возникающее при изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Contact()
        {
            _name = string.Empty;
            _phoneNumber = string.Empty;
            _email = string.Empty;
        }
        /// <summary>
        /// Конструктор для инициализации контакта с параметрами.
        /// </summary>
        /// <param name="name">Имя контакта.</param>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <param name="email">Адрес электронной почты.</param>
        public Contact(string name, string phoneNumber, string email)
        {
            _name = name;
            _phoneNumber = phoneNumber; 
            _email = email;
        }
        /// <summary>
        /// Имя контакта
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        /// <summary>
        /// Почта контакта
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        /// <summary>
        /// Номер контакта
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        /// <summary>
        /// Метод для вызова события PropertyChanged.
        /// </summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
