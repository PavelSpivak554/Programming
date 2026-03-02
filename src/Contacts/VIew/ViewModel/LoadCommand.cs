using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VIew.Model;

namespace View.ViewModel
{
    /// <summary>
    /// Команда для загрузки контакта.
    /// </summary>
    class LoadCommand : ICommand
    {
        /// <summary>
        /// Приватное поле для хранения действия, которое нужно выполнить при загрузке;
        /// </summary>
        private readonly Action<Contact> _loadAction;

        /// <summary>
        /// Создает новую команду загрузки
        /// </summary>
        /// <param name="loadAction"></param>
        public LoadCommand(Action<Contact> loadAction)
        {
            _loadAction = loadAction;
        }
        /// <summary>
        /// Определеят можно ли выполнить команду сейчас. Кнопка всегда доступна.
        /// </summary>
        /// <returns>всегда true</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Определяет, что происходит при выполнении комманды.
        /// </summary>
        public void Execute(object parameter)
        {
            if(parameter is Contact contact)
            {
                _loadAction(contact);
            }
        }
        /// <summary>
        ///Событие которое возникает при изменении возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
