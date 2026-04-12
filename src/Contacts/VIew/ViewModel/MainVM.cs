using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
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
        #region Private Fields

        /// <summary>
        /// Поле коллекции контактов, хранящее актуальные данные.
        /// </summary>
        private ObservableCollection<Contact> _contacts;

        /// <summary>
        /// Поле хранящее текущий контакт
        /// </summary>
        private Contact _selectedContact;

        /// <summary>
        /// Редактируемый контакт для временного хранения
        /// </summary>
        private Contact _editableContact;

        /// <summary>
        /// Флаг для режима добавления
        /// </summary>
        private bool _isAdding;

        /// <summary>
        /// Флаг для режима редактирования
        /// </summary>
        private bool _isEditing;

        /// <summary>
        /// Поле для сериализатора
        /// </summary>
        private readonly ContactSerializer _serializer;

        /// <summary>
        /// Поле для интерфейса сообщений
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        /// Поле для отображения отфильтрованных контактов
        /// </summary>
        private ICollectionView _contactsView;

        /// <summary>
        /// Поле для хранения поискового запроса
        /// </summary>
        private string _searchText;
        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор по умолчанию.
        /// Инициализирует сериализатор, создает тестовый контакт и команду сохранения.
        /// </summary>
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

        #region Public Properties (Simple)

        /// <summary>
        /// Свойство для доступа к имени
        /// </summary>
        public string Name
        {
            get { return _editableContact.Name; }
            set
            {
                if (_editableContact.Name != value)
                {
                    _editableContact.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к номеру телефона
        /// </summary>
        public string PhoneNumber
        {
            get { return _editableContact.PhoneNumber; }
            set
            {
                if (_editableContact.PhoneNumber != value)
                {
                    _editableContact.PhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к почте
        /// </summary>
        public string Email
        {
            get { return _editableContact.Email; }
            set
            {
                if (_editableContact.Email != value)
                {
                    _editableContact.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к коллекции контактов
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство для доступа к отфильтрованной коллекции контактов
        /// </summary>
        public ICollectionView CollectionView
        {
            get => _contactsView;
            set
            {
                _contactsView = value;
                _contactsView?.Refresh(); // отвечает за обновление данных в UI 
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value ?? "";
                _contactsView.Refresh();
                OnPropertyChanged();

            }
        }
        /// <summary>
        /// Свойство для доступа к текущему контакту
        /// </summary>
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact == value) return;
                if (_isEditing || _isAdding)
                {
                    CancelEditing();
                }

                _selectedContact = value;
                if (value != null && !_isAdding && !_isEditing)
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
        /// Свойство для доступа к изменяемому контакту
        /// </summary>
        public Contact EditableContact
        {
            get => _editableContact;
            set
            {
                if (_editableContact == value) return;
                _editableContact = value;

                if (value != null)
                {
                    _editableContact.ValidateAll();
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Свойство для доступа к флагу добавления контакта
        /// </summary>
        public bool IsAdding
        {
            get => _isAdding;
            set
            {
                if (_isAdding != value)
                {
                    _isAdding = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к флагу изменения контакта
        /// </summary>
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing != value)
                {
                    _isEditing = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        /// <summary>
        /// Свойство для доступа к флагу доступа кнопок только на чтение
        /// </summary>
        public bool IsReadOnly => !_isAdding && !_isEditing;

        /// <summary>
        /// Свойство для доступа к флагу видимости кнопки Apply
        /// </summary>
        public bool IsApplyVisible => _isAdding || _isEditing;

        #endregion

        #region Commands

        /// <summary>
        /// Свойство для команды сохранения
        /// </summary>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Свойство для команды загрузки
        /// </summary>
        public ICommand LoadCommand { get; private set; }

        /// <summary>
        /// Свойство для команды добавления
        /// </summary>
        public ICommand AddCommand { get; private set; }

        /// <summary>
        /// Свойство для команды удаления
        /// </summary>
        public ICommand RemoveCommand { get; private set; }

        /// <summary>
        /// Свойство для команды изменения
        /// </summary>
        public ICommand EditCommand { get; private set; }

        /// <summary>
        /// Свойство для команды применения
        /// </summary>
        public ICommand ApplyCommand { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод сохранения контактов (автосохранение в файл)
        /// </summary>
        public void SaveContacts()
        {
            try
            {
                _serializer.SaveContact(_contacts);
            }
            catch (Exception ex)
            {
                _messageService.FailureMessage(ex);
            }
        }

        #endregion

        #region Private Methods (Command Initialization)

        /// <summary>
        /// Метод инициализации всех команд
        /// </summary>
        private void InitializeCommands()
        {
            InitializeAddCommand();
            InitializeApplyCommand();
            InitializeEditCommand();
            InitializeLoadCommand();
            InitializeRemoveCommand();
            InitializeSaveCommand();
        }

        /// <summary>
        /// Метод инициализации команды сохранения
        /// </summary>
        private void InitializeSaveCommand()
        {
            SaveCommand = new RelayCommand(
                _ =>
                {
                    try
                    {
                        _serializer.SaveContact(_contacts);
                    }
                    catch (Exception ex)
                    {
                        _messageService.FailureMessage(ex);
                    }
                });
        }

        /// <summary>
        /// Метод инициализации команды загрузки
        /// </summary>
        private void InitializeLoadCommand()
        {
            LoadCommand = new RelayCommand(
                _ =>
                {
                    try
                    {
                        _contacts.Clear();
                        var loadedContacts = _serializer.LoadContact();
                        foreach (var c in loadedContacts)
                            _contacts.Add(c);
                    }
                    catch (Exception ex)
                    {
                        _messageService.FailureMessage(ex);
                    }
                });
        }

        /// <summary>
        /// Метод инициализации команды добавления
        /// </summary>
        private void InitializeAddCommand()
        {
            AddCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;

                    SelectedContact = null;
                    IsAdding = true;
                    EditableContact = new Contact();
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                },
                canExecute: _ =>
                {
                    return !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });
        }

        /// <summary>
        /// Метод инициализации команды удаления
        /// </summary>
        private void InitializeRemoveCommand()
        {
            RemoveCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;

                    var removedContact = SelectedContact;
                    int index = _contacts.IndexOf(removedContact);
                    _contacts.Remove(removedContact);
                    SaveContacts();

                    if (_contacts.Count == 0)
                    {
                        EditableContact = new Contact();

                        OnPropertyChanged(nameof(Name));
                        OnPropertyChanged(nameof(PhoneNumber));
                        OnPropertyChanged(nameof(Email));
                    }
                    else if (index < _contacts.Count)
                    {
                        SelectedContact = _contacts[index];
                    }
                    else
                    {
                        SelectedContact = _contacts[_contacts.Count - 1];
                    }
                },
                canExecute: _ =>
                {
                    return SelectedContact != null && !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });
        }

        /// <summary>
        /// Метод инициализации команды редактирования
        /// </summary>
        private void InitializeEditCommand()
        {
            EditCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isAdding || _isEditing) return;
                    IsEditing = true;
                    IsAdding = false;

                    EditableContact = new Contact()
                    {
                        Name = SelectedContact.Name,
                        PhoneNumber = SelectedContact.PhoneNumber,
                        Email = SelectedContact.Email
                    };

                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(PhoneNumber));
                    OnPropertyChanged(nameof(Email));
                },
                canExecute: _ =>
                {
                    return SelectedContact != null && !_isAdding && !_isEditing; //доступна, когда оба флага false 
                });
        }

        /// <summary>
        /// Метод инициализации команды подтверждения
        /// </summary>
        private void InitializeApplyCommand()
        {
            ApplyCommand = new RelayCommand(
                execute: _ =>
                {
                    if (_isEditing)
                    {
                        SelectedContact.Name = EditableContact.Name;
                        SelectedContact.PhoneNumber = EditableContact.PhoneNumber;
                        SelectedContact.Email = EditableContact.Email;

                        IsEditing = false;
                        SaveContacts();
                    }
                    else if (_isAdding)
                    {
                        var newContact = EditableContact;
                        _contacts.Add(newContact);
                        IsAdding = false;
                        SelectedContact = newContact;
                        SaveContacts();
                    }
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsApplyVisible));
                    
                    CommandManager.InvalidateRequerySuggested();
                },
                canExecute: _ => (_isEditing || _isAdding)
                && EditableContact != null
                && !EditableContact.HasErrors
                && AreFieldsClear());
        }

        #endregion

        #region Private Methods (Helpers)

        /// <summary>
        /// Проверяет, что все поля редактируемого контакта заполнены.
        /// </summary>
        /// <remarks>
        /// Обеспечивает недоступность кнопки apply в UI ведь валидатор допускает то, что пустые поля валидны
        /// </remarks>
        /// <returns>true, если все поля не пустые; иначе false.</returns>
        private bool AreFieldsClear()
        {
            return !string.IsNullOrWhiteSpace(EditableContact.Name) &&
           !string.IsNullOrWhiteSpace(EditableContact.PhoneNumber) &&
           !string.IsNullOrWhiteSpace(EditableContact.Email);
        }

        /// <summary>
        /// Метод отмены изменений
        /// </summary>
        private void CancelEditing()
        {
            if (_isEditing)
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
            else if (_isAdding)
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
        /// Метод проверяющий то, что данные в строке поиска есть в коллекции контактов, обеспечивает поиск по имени
        /// </summary>
        /// <param name="item">Контакт которой мы проверяем для фильтрации</param>
        /// <returns>true, если имя контакты содержит вводимые данные, иначе false</returns>
        /// <remarks>Игнорируем регистр</remarks>
        private bool FilteredContacts(object item)
        {
            var contact = item as Contact;
            return contact?.Name.Contains(SearchText ?? "", StringComparison.OrdinalIgnoreCase) == true;
        }
        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Событие для уведомления об изменениях свойств.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события PropertyChanged
        /// </summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}