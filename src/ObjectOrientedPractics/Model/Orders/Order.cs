using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model.Orders
{
    /// <summary>
    /// Представляет заказ покупателя.
    /// Содержит информацию о заказе: Id, дату создания, адрес доставки,
    /// список товаров и общую стоимость.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Счетчик для генерации уникальных Id заказов.
        /// </summary>
        private static int idCounter = 1;
        /// <summary>
        /// Уникальный идентификатор заказа.
        /// </summary>
        private readonly int _id;
        /// <summary>
        /// Дата и время создания заказа.
        /// </summary>
        private readonly DateTime _date;
        /// <summary>
        /// Адрес доставки заказа.
        /// </summary>
        private Address _address;
        /// <summary>
        /// Список товаров в заказе.
        /// </summary>
        private List<Item> _items;
        /// <summary>
        /// Общая стоимость заказа.
        /// </summary>
        private double _amount;

        private OrderStatus _status;
        /// <summary>
        /// Размер примененной скидки.
        /// </summary>
        private double _discountAmount;
        /// <summary>
        /// Создает новый экземпляр класса <see cref="Order"/> на основе корзины покупателя.
        /// </summary>
        /// <param name="cart">Корзина с товарами.</param>
        /// <param name="address">Адрес доставки.</param>
        public Order(Cart cart, Address address)
        {
            _id = idCounter++;
            _date = DateTime.Now;
            _address = address;
            _items = new List<Item>();

            if (cart?.Items != null)
            {
                foreach (var item in cart.Items)
                {
                    _items.Add(item);
                }
            }
            _amount = cart?.Amount ?? 0.0;
            _status = OrderStatus.New;
            _discountAmount = 0.0;
        }

        /// <summary>
        /// Создает новый экземпляр класса <see cref="Order"/> без параметров.
        /// </summary>
        public Order()
        {
            _id = idCounter++;
            _date = DateTime.Now;
            _items = new List<Item>();
            _discountAmount = 0.0;
        }

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }
        /// <summary>
        /// Возвращает дату и время создания заказа.
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
        }
        /// <summary>
        /// Возвращает или задает адрес доставки заказа.
        /// </summary>
        public Address Address
        {
            get
            {
                return _address;
            }
            set { _address = value; }


        }
        /// <summary>
        /// Возвращает или задает список товаров в заказе.
        /// </summary>
        public List<Item> Items { get { return _items; } set { _items = value; } }

        /// <summary>
        /// Возвращает или задает общую стоимость заказа.
        /// </summary>
        public double Amount
        {
            get { return _amount; } set { _amount = value; }
        }

        /// <summary>
        /// перечисление статусов.
        /// </summary>
        public OrderStatus Status
        {
            get => _status;
            set => _status = value;
        }
        /// <summary>
        /// Возвращает или задает размер примененной скидки.
        /// </summary>
        public double DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; }
        }


        /// <summary>
        /// Возвращает конечную стоимость заказа с учетом скидки.
        /// </summary>
        public double Total
        {
            get { return Amount - DiscountAmount; }
        }
    }

    
}
