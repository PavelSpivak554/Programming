using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using View.Model;
using View.Model.Services;
using View.ViewModel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel для главного окна приложения.
    /// </summary>
    public partial class MainVM : ObservableObject
    {
        #region Private Fields

        /// <summary>
        /// Коллекция контактов, хранящая актуальные данные.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Текущий выбранный контакт.
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Редактируемый контакт для временного хранения данных.
        /// </summary>
        [ObservableProperty]
        private Contact _editableContact;

        /// <summary>
        /// Флаг, указывающий, что выполняется добавление нового контакта.
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReadOnly))]
        [NotifyPropertyChangedFor(nameof(IsApplyVisible))]
        private bool _isAdding;

        /// <summary>
        /// Флаг, указывающий, что выполняется редактирование существующего контакта.
        /// </summary>
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReadOnly))]
        [NotifyPropertyChangedFor(nameof(IsApplyVisible))]
        private bool _isEditing;

        /// <summary>
        /// Сервис сериализации контактов.
        /// </summary>
        private readonly ContactSerializer _serializer;

        /// <summary>
        /// Сервис для отображения сообщений пользователю.
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        /// Представление коллекции контактов для фильтрации.
        /// </summary>
        private ICollectionView _contactsView;

        /// <summary>
        /// Текст поискового запроса.
        /// </summary>
        [ObservableProperty]
        private string _searchText = "";

        /// <summary>
        /// Имя редактируемого контакта.
        /// </summary>
        [ObservableProperty]
        private string _name;

        /// <summary>
        /// Номер телефона редактируемого контакта.
        /// </summary>
        [ObservableProperty]
        private string _phoneNumber;

        /// <summary>
        /// Email редактируемого контакта.
        /// </summary>
        [ObservableProperty]
        private string _email;

        #endregion

        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MainVM"/>.
        /// </summary>
        /// <param name="messageService">Сервис для отображения сообщений.</param>
        public MainVM(IMessageService messageService)
        {
            _contacts = new ObservableCollection<Contact>();
            _serializer = new ContactSerializer();
            _messageService = messageService;
            _editableContact = new Contact();

            try
            {
                var loadedContacts = _serializer.LoadContact();
                foreach (var c in loadedContacts)
                    _contacts.Add(c);
            }
            catch (Exception ex)
            {
                _messageService.FailureMessage(ex);
            }

            CollectionView = CollectionViewSource.GetDefaultView(_contacts);
            CollectionView.Filter = item => FilteredContacts(item);
            InitializeCommands();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Получает или задает отфильтрованное представление коллекции контактов.
        /// </summary>
        public ICollectionView CollectionView
        {
            get => _contactsView;
            set
            {
                _contactsView = value;
                _contactsView?.Refresh();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Получает или задает текущий выбранный контакт.
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact == value) return;

                if (IsEditing || IsAdding)
                {
                    CancelEditing();
                }

                _selectedContact = value;

                if (value != null && !IsAdding && !IsEditing)
                {
                    EditableContact = new Contact
                    {
                        Name = value.Name,
                        PhoneNumber = value.PhoneNumber,
                        Email = value.Email
                    };
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        /// <summary>
        /// Получает значение, указывающее, находится ли интерфейс в режиме только для чтения.
        /// </summary>
        public bool IsReadOnly => !IsAdding && !IsEditing;

        /// <summary>
        /// Получает значение, указывающее, видима ли кнопка Apply.
        /// </summary>
        public bool IsApplyVisible => IsAdding || IsEditing;

        #endregion

        #region Commands

        /// <summary>
        /// Команда сохранения контактов в файл.
        /// </summary>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Команда загрузки контактов из файла.
        /// </summary>
        public ICommand LoadCommand { get; private set; }

        /// <summary>
        /// Команда добавления нового контакта.
        /// </summary>
        public ICommand AddCommand { get; private set; }

        /// <summary>
        /// Команда удаления выбранного контакта.
        /// </summary>
        public ICommand RemoveCommand { get; private set; }

        /// <summary>
        /// Команда редактирования выбранного контакта.
        /// </summary>
        public ICommand EditCommand { get; private set; }

        /// <summary>
        /// Команда применения изменений.
        /// </summary>
        public ICommand ApplyCommand { get; private set; }

        #endregion

        #region Partial Methods

        /// <summary>
        /// Вызывается при изменении свойства <see cref="SearchText"/>.
        /// Обновляет фильтрацию коллекции контактов.
        /// </summary>
        /// <param name="value">Новое значение поискового запроса.</param>
        partial void OnSearchTextChanged(string value)
        {
            _contactsView?.Refresh();
        }

        /// <summary>
        /// Вызывается при изменении свойства <see cref="IsAdding"/>.
        /// Обновляет состояние команд.
        /// </summary>
        /// <param name="value">Новое значение флага добавления.</param>
        partial void OnIsAddingChanged(bool value)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Вызывается при изменении свойства <see cref="IsEditing"/>.
        /// Обновляет состояние команд.
        /// </summary>
        /// <param name="value">Новое значение флага редактирования.</param>
        partial void OnIsEditingChanged(bool value)
        {
            CommandManager.InvalidateRequerySuggested();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Сохраняет текущую коллекцию контактов в файл.
        /// </summary>
        public void SaveContacts()
        {
            try
            {
                _serializer.SaveContact(Contacts);
            }
            catch (Exception ex)
            {
                _messageService.FailureMessage(ex);
            }
        }

        #endregion

        #region Private Methods (Command Initialization)

        /// <summary>
        /// Инициализирует все команды ViewModel.
        /// </summary>
        private void InitializeCommands()
        {
            
            InitializeAddCommand();
            InitializeRemoveCommand();
            InitializeEditCommand();
            InitializeApplyCommand();
        }


        /// <summary>
        /// Инициализирует команду добавления нового контакта.
        /// </summary>
        private void InitializeAddCommand()
        {
            AddCommand = new RelayCommand(
                execute: _ =>
                {
                    if (IsAdding || IsEditing) return;

                    SelectedContact = null;
                    IsAdding = true;
                    EditableContact = new Contact();

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                },
                canExecute: _ => !IsAdding && !IsEditing);
        }

        /// <summary>
        /// Инициализирует команду удаления контакта.
        /// </summary>
        private void InitializeRemoveCommand()
        {
            RemoveCommand = new RelayCommand(
                execute: _ =>
                {
                    if (IsAdding || IsEditing) return;

                    var removedContact = SelectedContact;
                    int index = Contacts.IndexOf(removedContact);
                    Contacts.Remove(removedContact);
                    SaveContacts();

                    if (Contacts.Count == 0)
                    {
                        EditableContact = new Contact();
                        OnPropertyChanged(nameof(Name));
                        OnPropertyChanged(nameof(PhoneNumber));
                        OnPropertyChanged(nameof(Email));
                    }
                    else if (index < Contacts.Count)
                    {
                        SelectedContact = Contacts[index];
                    }
                    else
                    {
                        SelectedContact = Contacts[Contacts.Count - 1];
                    }
                },
                canExecute: _ => SelectedContact != null && !IsAdding && !IsEditing);
        }

        /// <summary>
        /// Инициализирует команду редактирования выбранного контакта.
        /// </summary>
        private void InitializeEditCommand()
        {
            EditCommand = new RelayCommand(
                execute: _ =>
                {
                    if (IsAdding || IsEditing) return;

                    IsEditing = true;
                    IsAdding = false;

                    EditableContact = new Contact
                    {
                        Name = SelectedContact.Name,
                        PhoneNumber = SelectedContact.PhoneNumber,
                        Email = SelectedContact.Email
                    };

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                },
                canExecute: _ => SelectedContact != null && !IsAdding && !IsEditing);
        }

        /// <summary>
        /// Инициализирует команду применения изменений.
        /// </summary>
        private void InitializeApplyCommand()
        {
            ApplyCommand = new RelayCommand(
                execute: _ =>
                {
                    if (IsEditing)
                    {
                        SelectedContact.Name = EditableContact.Name;
                        SelectedContact.PhoneNumber = EditableContact.PhoneNumber;
                        SelectedContact.Email = EditableContact.Email;

                        IsEditing = false;
                        SaveContacts();
                    }
                    else if (IsAdding)
                    {
                        var newContact = EditableContact;
                        Contacts.Add(newContact);
                        IsAdding = false;
                        SelectedContact = newContact;
                        SaveContacts();
                    }

                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                },
                canExecute: _ => (IsEditing || IsAdding)
                    && EditableContact != null
                    && !EditableContact.HasErrors
                    && AreFieldsClear());
        }

        #endregion

        #region Private Methods (Helpers)

        /// <summary>
        /// Проверяет, что все обязательные поля редактируемого контакта заполнены.
        /// </summary>
        /// <remarks>
        /// Обеспечивает корректное состояние кнопки Apply, так как валидатор допускает пустые поля как валидные.
        /// </remarks>
        /// <returns>true, если все поля заполнены; иначе false.</returns>
        private bool AreFieldsClear()
        {
            return !string.IsNullOrWhiteSpace(EditableContact.Name)
                && !string.IsNullOrWhiteSpace(EditableContact.PhoneNumber)
                && !string.IsNullOrWhiteSpace(EditableContact.Email);
        }

        /// <summary>
        /// Отменяет текущее редактирование или добавление контакта.
        /// </summary>
        private void CancelEditing()
        {
            if (IsEditing)
            {
                IsEditing = false;

                if (_selectedContact != null)
                {
                    EditableContact = new Contact
                    {
                        Name = _selectedContact.Name,
                        PhoneNumber = _selectedContact.PhoneNumber,
                        Email = _selectedContact.Email
                    };
                }
                else
                {
                    EditableContact = new Contact();
                    _selectedContact = null;
                }
            }
            else if (IsAdding)
            {
                IsAdding = false;

                if (_selectedContact != null)
                {
                    EditableContact = _selectedContact;
                }
                else
                {
                    EditableContact = new Contact();
                }
            }

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(Email));
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Фильтрует контакты по поисковому запросу, проверяя совпадение по имени.
        /// </summary>
        /// <param name="item">Контакт для проверки.</param>
        /// <returns>true, если имя контакта содержит поисковый запрос; иначе false.</returns>
        /// <remarks>Сравнение выполняется без учета регистра.</remarks>
        private bool FilteredContacts(object item)
        {
            var contact = item as Contact;
            return contact?.Name.Contains(SearchText ?? "", StringComparison.OrdinalIgnoreCase) == true;
        }

        #endregion
    }
}