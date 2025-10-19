using ObjectOrientedPractics.Services;
using Programming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет товар с уникальным Id, названием, описанием и стоимостью.
    /// </summary>
    internal class Item
    {
        /// <summary>
        /// Счетчик для генерации уникальных Id товаров.
        /// </summary>
        private static int idCounter = 1;

        /// <summary>
        /// Уникальный Id товара.
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Название товара.
        /// </summary>
        private string _name;

        /// <summary>
        /// Описание товара.
        /// </summary>
        private string _info;

        /// <summary>
        /// Стоимость товара.
        /// </summary>
        private double _cost;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Item"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="cost"></param>
        public Item(string name, string info, double cost)
        {
            _id = idCounter++;
            Name = name;
            Info = info;
            Cost = cost;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Item"/>
        /// </summary>
        public Item()
        {
            _id = idCounter++;
        }

        /// <summary>
        /// Возвращает Id товара.
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Возвращает название товара.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 200, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает описание товара.
        /// </summary>
        public string Info
        {
            get { return _info; }
            set
            {
                ValueValidator.AssertStringOnLength(value, 1000, nameof(Info));
                _info = value;
            }
        }

        /// <summary>
        /// Возвращает стоимость товара.
        /// </summary>
        public double Cost
        {
            get { return _cost; }
            set
            {
                ValueValidator.AssertValueInRange(value, 0, 100000, nameof(Cost));
                _cost = value;
            }
        }
    }
}