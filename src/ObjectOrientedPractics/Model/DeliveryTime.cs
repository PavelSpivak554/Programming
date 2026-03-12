using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Определяет возможные временные интервалы для доставки приоритетного заказа.
    /// </summary>
    /// <remarks>
    /// Каждый элемент перечисления соответствует двухчасовому временному слоту.
    /// Значения преобразуются в строку через метод <see cref="PriorityOrder.GetDesiredTime(DeliveryTime)"/>.
    /// </remarks>
    public enum DeliveryTime
    {
        /// <summary>
        /// Временной интервал с 9:00 до 11:00.
        /// </summary>
        From9To11 = 0,

        /// <summary>
        /// Временной интервал с 11:00 до 13:00.
        /// </summary>
        From11To13 = 1,

        /// <summary>
        /// Временной интервал с 13:00 до 15:00.
        /// </summary>
        From13To15 = 2,

        /// <summary>
        /// Временной интервал с 15:00 до 17:00.
        /// </summary>
        From15To17 = 3,

        /// <summary>
        /// Временной интервал с 17:00 до 19:00.
        /// </summary>
        From17To19 = 4,

        /// <summary>
        /// Временной интервал с 19:00 до 21:00.
        /// </summary>
        From19To21 = 5
    }
}