using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет корзину покупок покупателя.
    /// Содержит список товаров и общую стоимость корзины.
    /// </summary>
    public class Cart : ICloneable

    {   /// <summary>
        /// Список товаров в корзине.
        /// </summary>
        private List<Item> _items;
        /// <summary>
        /// Итоговая сумма всех товаров
        /// </summary>
        private double _amount;
        /// <summary>
        /// Создает новый экземпляр класса <see cref="Cart"/>.
        /// </summary>
        /// <param name="items">Список товаров для добавления в корзину.</param>
        public Cart()
        {
            _items = new List<Item>();

        }
        /// <summary>
        /// Получает или задает список товаров в корзине.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        /// <summary>
        /// Получает общую стоимость всех товаров в корзине.
        /// </summary>
        public double Amount
        {
            get
            {
                double finalAmount = 0;
                if (_items != null && _items.Count > 0)
                {
                    foreach (Item item in _items)
                    {
                        finalAmount += item.Cost;
                    }
                    return finalAmount;
                }
                return 0.0;
            }
        }

        /// <summary>
        /// Создаеи объект копию класса
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clonedCart = new Cart();
            foreach (var item in _items)
            {
                clonedCart.Items.Add((Item)item.Clone());
            }
            return clonedCart;
        }

    }

}
