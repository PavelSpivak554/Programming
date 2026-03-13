using ObjectOrientedPractics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Представляет товар с уникальным Id, названием, описанием и стоимостью.
    /// </summary>
    public class Item : ICloneable, IEquatable<Item>, IComparable<Item>
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
        /// Категория товара.
        /// </summary>
        private Category _category;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Item"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="cost"></param>
        /// <param name="category"></param>
        public Item(string name, string info, double cost, Category category)
        {
            _id = idCounter++;
            Name = name;
            Info = info;
            Cost = cost;
            Category = category;
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
        /// <summary>
        /// Возвращает категорию товара
        /// </summary>
        public Category Category
        {
            get { return _category; }
            set
            {
                _category = value;
            }
            
        }
        /// <summary>
        /// создаёт объект копию класса Item.
        /// </summary>
        /// <returns>копия класса</returns>
        public object Clone()
        {
            return new Item(this.Name, this.Info, this.Cost, this.Category);
        }

        /// <summary>
        /// Определяет, равен ли указанный объект текущему объекту.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns>true, если указанный объект равен текущему объекту; в противном случае — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Item other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Определяет, равен ли указанный объект Item текущему объекту Item.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Item other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return _id == other._id &&
                   _name == other._name &&
                   _info == other._info &&
                   _cost == other._cost &&
                   _category == other._category;
        }

        /// <summary>
        /// Возвращает хэш-код для текущего объекта.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _id.GetHashCode();
                hash = hash * 23 + (_name?.GetHashCode() ?? 0);
                hash = hash * 23 + (_info?.GetHashCode() ?? 0);
                hash = hash * 23 + _cost.GetHashCode();
                hash = hash * 23 + _category.GetHashCode();
                return hash;
            }
        }
        /// <summary>
        /// Сравнивает текущий объект Item с другим объектом Item по стоимости.
        /// </summary>
        /// <param name="other">Объект Item для сравнения с текущим объектом.</param>
        /// <returns>
        /// Меньше нуля: текущий объект меньше другого объекта по стоимости.
        /// Ноль: объекты равны по стоимости.
        /// Больше нуля: текущий объект больше другого объекта по стоимости.
        /// </returns>
        public int CompareTo(Item other)
        {
            if (other is null) return 1;
            return _cost.CompareTo(other._cost);
        }
        /// <summary>
        /// строковое представление объекта Item, переопределенное в классе
        /// </summary>
        /// <returns>Строка представляющая текущий объект</returns>
        public override string ToString()
        {
            return $"{Id} | {Category}";
        }
    }
}