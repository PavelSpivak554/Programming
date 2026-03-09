using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет хранилище данных приложения.
    /// Содержит списки товаров и покупателей.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Список товаров в магазине.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Список покупателей в магазине.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Получает или задает список товаров.
        /// </summary>
        public List<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        /// <summary>
        /// Получает или задает список покупателей.
        /// </summary>
        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Store"/>.
        /// Создает пустые списки для товаров и покупателей.
        /// </summary>
        public Store()
        {
            _items = new List<Item>();
            _customers = new List<Customer>();
        }
    }
}