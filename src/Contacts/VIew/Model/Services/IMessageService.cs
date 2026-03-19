using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model.Services
{
    /// <summary>
    /// Интерфейс сервиса для отображения сообщений пользователю.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Отображает сообщение об успешной загрузке контакта.
        /// </summary>
        void SuccessLoadMessage();
        /// <summary>
        /// Отображает сообщение об успешном сохранении контакта.
        /// </summary>
        void SuccessSaveMessage();
        /// <summary>
        /// Отображает сообщение об ошибке.
        /// </summary>
        /// <param name="ex">Исключение, содержащее информацию об ошибке.</param>
        void FailureMessage(Exception ex);
    }
}
