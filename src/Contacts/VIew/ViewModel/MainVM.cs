using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using View.Model;
using View.Model.Services;
using View.ViewModel.Services;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel для главного окна приложения.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Поле контакта, хранящее актуальные данные.
        /// </summary>
        private Contact _contact;

        /// <summary>
        /// Поле для сериализатора
        /// </summary>
        private readonly ContactSerializer _serializer;
        /// <summary>
        /// Поле для интерфейса сообщений
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        /// Свойство для команды сохранения
        /// </summary>
        public ICommand SaveCommand { get; }
        /// <summary>
        /// Свойство для команды загрузки
        /// </summary>
        public ICommand LoadCommand { get; }

        /// <summary>
        /// Конструктор по умолчанию.
        /// Инициализирует сериализатор, создает тестовый контакт и команду сохранения.
        /// </summary>
        public MainVM(IMessageService messageService)
        {
            // Инициализация сериализатора
            _serializer = new ContactSerializer();
            _messageService = messageService;
            // Инициализация контакта с тестовыми данными
            _contact = new Contact
            {
                Name = "Смирнов Юрий",
                PhoneNumber = "+7-913-111-22-33",
                Email = "yuri.smirnov@no.mail"
            };
            SaveCommand = new RelayCommand(parameter =>
            {
                if (parameter is Contact contact)
                {
                    try
                    {
                        _serializer.SaveContact(contact);
                    }
                    catch (Exception ex)
                    {
                        _messageService.FailureMessage(ex);
                    }
                }
            });

            LoadCommand = new RelayCommand(contact =>  
            {
                try
                {
                    // Загружаем контакт из файла
                    Contact loadedContact = _serializer.LoadContact();

                    Name = loadedContact.Name;
                    PhoneNumber = loadedContact.PhoneNumber;
                    Email = loadedContact.Email;

                }
                catch (Exception ex)
                {
                    _messageService.FailureMessage(ex);
                }
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
        /// Метод для вызова события PropertyChanged
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
        /// Используется для передачи всего объекта Contact в команды
        /// </summary>
        public Contact CurrentContact
        {
            get { return _contact; }
        }
    }
}
    
