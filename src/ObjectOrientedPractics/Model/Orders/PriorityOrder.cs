using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;


namespace ObjectOrientedPractics.Model.Orders
{
    /// <summary>
    /// Представляет приоритетный заказ с возможностью выбора даты и времени доставки.
    /// Наследуется от базового класса <see cref="Order"/>.
    /// </summary>
    public class PriorityOrder : Order
    {
        /// <summary>
        /// Поле для хранения желаемой даты доставки.
        /// </summary>
        private DateTime _desiredDate;

        /// <summary>
        /// Поле для хранения желаемого времени доставки.
        /// </summary>
        private string _desiredTime;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PriorityOrder"/>.
        /// </summary>
        /// <param name="desiredDate">Желаемая дата доставки.</param>
        /// <param name="desiredTime">Желаемое время доставки в виде строки.</param>
        /// <param name="cart">Корзина с товарами для заказа.</param>
        /// <param name="address">Адрес доставки заказа.</param>
        public PriorityOrder(DateTime desiredDate, string desiredTime, Cart cart, Address address) : base(cart, address)
        {
            DesiredDate = desiredDate;
            DesiredTime = desiredTime;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PriorityOrder" /> только с данными стандартного заказа.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="address"></param>
        public PriorityOrder(Cart cart, Address address) : base (cart, address)
        { }
        public PriorityOrder() { }

        /// <summary>
        /// Получает или задает желаемую дату доставки.
        /// </summary>
        public DateTime DesiredDate
        {
            get { return _desiredDate; }
            set { _desiredDate = value; }
        }

        /// <summary>
        /// Получает или задает желаемое время доставки в виде строки.
        /// </summary>
        public string DesiredTime
        {
            get { return _desiredTime; }
            set { _desiredTime = value; }
        }

        /// <summary>
        /// Преобразует значение перечисления <see cref="DeliveryTime"/> в строковое представление временного диапазона.
        /// </summary>
        /// <param name="time">Элемент перечисления <see cref="DeliveryTime"/>.</param>
        /// <returns>Строковое представление временного диапазона.</returns>
        public string GetDesiredTime(DeliveryTime time)
        {
            switch (time)
            {
                case DeliveryTime.From9To11:
                    return "9:00 – 11:00";
                case DeliveryTime.From11To13:
                    return "11:00 – 13:00";
                case DeliveryTime.From13To15:
                    return "13:00 – 15:00";
                case DeliveryTime.From15To17:
                    return "15:00 – 17:00";
                case DeliveryTime.From17To19:
                    return "17:00 – 19:00";
                case DeliveryTime.From19To21:
                    return "19:00 – 21:00";
                default:
                    return "Не выбрано";
            }
        }
    }
}