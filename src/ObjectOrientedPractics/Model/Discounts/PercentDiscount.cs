using ObjectOrientedPractics.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model.Discounts
{
    public class PercentDiscount : IDiscount, IComparable<PercentDiscount>
    {
        // Поля.
        private Category _category;
        private double _totalSpentOnCategory;
        private int _discountPercent;
        private static Random _random = new Random();

        /// <summary>
        /// Свойства
        /// </summary>
        public Category Category
        {
            get { return _category; }
            private set
            {
                _category = value;
            }
        }

        /// <summary>
        /// Свойства.
        /// </summary>
        public double TotalSpentOnCategory
        {
            get { return _totalSpentOnCategory; }
            private set
            {
                _totalSpentOnCategory = value;
                // При изменении суммы автоматически пересчитываем скидку
                UpdateDiscountPercent();
            }
        }
        /// <summary>
        /// Свойства.
        /// </summary>
        public int DiscountPercent
        {
            get { return _discountPercent; }
            private set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentException("Скидка должна быть от 1% до 10%");
                _discountPercent = value;
            }
        }
        /// <summary>
        /// метод возвращающий информацию
        /// </summary>
        public string Info
        {
            get { return $"Процентная «{GetCategoryName(Category)}» - {DiscountPercent}%"; }
        }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="category"></param>
        public PercentDiscount(Category category)
        {
            Category = category;
            TotalSpentOnCategory = 0;
            DiscountPercent = _random.Next(1, 10); // Начальная скидка 1%
        }

        /// <summary>
        /// метод Рассчитывает размер скидки для списка товаров.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double Calculate(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            // Находим товары нужной категории
            var categoryItems = items.Where(item => item.Category == Category).ToList();

            // Если нет товаров нужной категории - скидка 0
            if (categoryItems.Count == 0)
                return 0;

            // Суммируем стоимость товаров из категории скидки
            double categoryTotal = categoryItems.Sum(item => item.Cost);

            // Рассчитываем скидку в денежном выражении
            double discount = categoryTotal * (DiscountPercent / 100.0);
            return discount;
        }
        /// <summary>
        /// Применяет скидку к товарам
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double Apply(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            // Рассчитываем скидку
            double discount = Calculate(items);

            // Если скидка > 0, обновляем накопленную сумму
            if (discount > 0)
            {
                // Находим товары нужной категории
                var categoryItems = items.Where(item => item.Category == Category).ToList();

                // Суммируем стоимость товаров из категории скидки
                double categorySpent = categoryItems.Sum(item => item.Cost);

                // Обновляем накопленную сумму
                TotalSpentOnCategory += categorySpent;
            }

            return discount;
        }

        /// <summary>
        /// Обновляет скидку на основе накопленной суммы
        /// </summary>
        private void UpdateDiscountPercent()
        {
            // Каждые 1000 рублей увеличивают скидку на 1%
            int newDiscountPercent = 1 + (int)(TotalSpentOnCategory / 1000);

            // Скидка не может быть больше 10%
            DiscountPercent = Math.Min(newDiscountPercent, 10);
        }

        /// <summary>
        /// Обновляет скидку (для совместимости с интерфейсом)
        /// </summary>
        /// <param name="items"></param>
        public void Update(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return;

            // Находим товары нужной категории
            var categoryItems = items.Where(item => item.Category == Category).ToList();

            // Если нет товаров нужной категории - ничего не делаем
            if (categoryItems.Count == 0)
                return;

            // Суммируем стоимость товаров из категории скидки
            double categorySpent = categoryItems.Sum(item => item.Cost);

            // Обновляем накопленную сумму
            TotalSpentOnCategory += categorySpent;
        }

        /// <summary>
        ///  Возвращает читаемое название категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private string GetCategoryName(Category category)
        {
            switch (category)
            {
                case Category.Electronics: return "Электроника";
                case Category.Clothing: return "Одежда";
                case Category.Food: return "Продукты";
                case Category.Books: return "Книги";
                case Category.Sports: return "Спорт";
                case Category.Home: return "Дом";
                case Category.Beauty: return "Красота";
                case Category.Automotive: return "Авто";
                case Category.Kids: return "Дети";
                case Category.Construction: return "Строительство";
                default: return category.ToString();
            }
        }

        /// <summary>
        /// Сравнивает текущий объект PercentDiscount с другим объектом PercentDiscount по проценту скидки.
        /// </summary>
        /// <param name="other">Объект PercentDiscount для сравнения с текущим объектом.</param>
        /// <returns>
        /// Меньше нуля: текущий объект имеет меньший процент скидки, чем другой объект.
        /// Ноль: объекты имеют одинаковый процент скидки.
        /// Больше нуля: текущий объект имеет больший процент скидки, чем другой объект.
        /// </returns>
        public int CompareTo(PercentDiscount other)
        {
            if (other is null) return 1; // null всегда меньше любого объекта

            return _discountPercent.CompareTo(other._discountPercent);
        }
    }
}
