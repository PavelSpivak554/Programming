using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model.Enums
{
    public enum OrderStatus
    {

        /// <summary>
        /// Новый заказ.
        /// </summary>
        New = 0,

        /// <summary>
        /// Заказ обрабатывается.
        /// </summary>
        Processing = 1,

        /// <summary>
        /// Заказ собирается на складе.
        /// </summary>
        Assembly = 2,

        /// <summary>
        /// Заказ отправлен.
        /// </summary>
        Sent = 3,

        /// <summary>
        /// Заказ доставлен.
        /// </summary>
        Delivered = 4,

        /// <summary>
        /// Заказ возвращен.
        /// </summary>
        Returned = 5,

        /// <summary>
        /// Заказ отменен (со стороны магазина).
        /// </summary>
        Abandoned = 6
    }
}
