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

        protected bool _isPriority;
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

    /// <summary>
        /// Определяет, равен ли указанный объект текущему объекту Order.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns>true, если указанный объект равен текущему объекту; в противном случае — false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Order);
        }

        /// <summary>
        /// Определяет, равен ли указанный объект Order текущему объекту Order.
        /// </summary>
        /// <param name="other">Объект Order для сравнения с текущим объектом.</param>
        /// <returns>true, если указанный объект равен текущему объекту; в противном случае — false.</returns>
        public bool Equals(Order other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            // Сравниваем простые поля
            if (_id != other._id ||
                _date != other._date ||
                _amount != other._amount ||
                _status != other._status ||
                _isPriority != other._isPriority ||
                _discountAmount != other._discountAmount)
            {
                return false;
            }

            // Сравниваем адрес
            if (_address == null && other._address != null) return false;
            if (_address != null && !_address.Equals(other._address)) return false;

            // Сравниваем списки товаров
            if (_items == null && other._items != null) return false;
            if (_items != null && other._items == null) return false;
            if (_items != null && other._items != null)
            {
                if (_items.Count != other._items.Count) return false;

                for (int i = 0; i < _items.Count; i++)
                {
                    if (!_items[i].Equals(other._items[i]))
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего объекта Order.
        /// </summary>
        /// <returns>Хэш-код для текущего объекта Order.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _id.GetHashCode();
                hash = hash * 23 + _date.GetHashCode();
                hash = hash * 23 + _amount.GetHashCode();
                hash = hash * 23 + _status.GetHashCode();
                hash = hash * 23 + _isPriority.GetHashCode();
                hash = hash * 23 + _discountAmount.GetHashCode();

                // Включаем хэш адреса
                hash = hash * 23 + (_address?.GetHashCode() ?? 0);

                // Включаем хэш списка товаров
                if (_items != null)
                {
                    foreach (var item in _items)
                    {
                        hash = hash * 23 + item.GetHashCode();
                    }
                }
                else
                {
                    hash = hash * 23 + 0;
                }

                return hash;
            }
        }

    }
}
