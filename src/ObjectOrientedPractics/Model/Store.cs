using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет магазин, содержащий списки товаров и покупателей.
    /// Является единой точкой доступа ко всем данным приложения.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Список товаров в магазине.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Список покупателей магазина.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Инициализирует новый экземпляр класса Store с пустыми списками.
        /// </summary>
        public Store()
        {
            _items = new List<Item>();
            _customers = new List<Customer>();
        }

        /// <summary>
        /// Получает или задает список товаров в магазине.
        /// </summary>
        public List<Item> Items
        {
            get
            {
                // Защита от null (хотя после конструктора это не должно случиться)
                if (_items == null)
                {
                    _items = new List<Item>();
                }
                return _items;
            }
            set
            {
                // Если передан null, создаем пустой список, иначе присваиваем значение
                if (value == null)
                {
                    _items = new List<Item>();
                }
                else
                {
                    _items = value;
                }
            }
        }

        /// <summary>
        /// Получает или задает список покупателей магазина.
        /// </summary>
        public List<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new List<Customer>();
                }
                return _customers;
            }
            set
            {
                if (value == null)
                {
                    _customers = new List<Customer>();
                }
                else
                {
                    _customers = value;
                }
            }
        }
    }
}