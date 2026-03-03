using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel для главного окна приложения.
    /// </summary>
    class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле контакта, хранящее актуальные данные.
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Поле для сереализатора
        /// </summary>
        private readonly ContactSerializer _serializer;

        /// <summary>
        /// Свойство для команды сохранения
        /// </summary>
        public ICommand SaveCommand { get; }

        

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MainVM()
        {
            // Инициализация сериализатора
            _serializer = new ContactSerializer();
            // Инициализация контакта с тестовыми данными
            _contact = new Contact
            {
                Name = "Смирнов Юрий",
                PhoneNumber = "+7-913-111-22-33",
                Email = "yuri.smirnov@no.mail"
            };
            SaveCommand = new SaveCommand(contact =>
            {
                _serializer.SaveContact(contact);

                System.Windows.MessageBox.Show(
                    "Контакт успешно сохранен!",
                    "Сохранение",
                    System.Windows.MessageBoxButton.OK,
                    System.Windows.MessageBoxImage.Information);
            });
        }

        
        /// <summary>
        /// Событие для уведомления об изменениях свойств.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Свойство для доступа к имени
        /// </summary>
        public string Name
        {
            get { return _contact.Name; }
            set
            {
                if (_contact.Name != value)
                {
                    _contact.Name = value;
                    OnPropertyChanged();
                }
            }
        }
       /// <summary>
       /// Свойство для доступа к номеру телефона
       /// </summary>
        public string PhoneNumber
        {
            get { return _contact.PhoneNumber; }
            set
            {
                if (_contact.PhoneNumber != value)
                {
                    _contact.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Свойство для доступа к почте
        /// </summary>
        public string Email
        {
            get { return _contact.Email; }
            set
            {
                if (_contact.Email != value)
                {
                    _contact.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Медод для вызова события PropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Свойство для доступа к контакту
        /// Используется для передачи всего объекта Contact в команду сохранения
        /// </summary>
        public Contact CurrentContact
        {
            get { return _contact; }
        }
    }
}
    
