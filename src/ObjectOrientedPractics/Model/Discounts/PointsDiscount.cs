using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public class PointsDiscount : IDiscount
    {
        private int _points;

        public int Points
        {
            get { return _points; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Количество баллов не может быть отрицательным");
                _points = value;
            }
        }
        public string Info
        {
            get { return $"Накопительная – {_points} баллов"; }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="initialPoints"></param>
        /// <exception cref="ArgumentException"></exception>
        public PointsDiscount(int initialPoints = 0)
        {
            if (initialPoints < 0)
                throw new ArgumentException("Количество баллов не может быть отрицательным");

            _points = initialPoints;
        }
        /// <summary>
        /// Рассчитывает размер скидки для списка товаров
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double Calculate(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            double totalPrice = items.Sum(item => item.Cost);
            double maxDiscount = totalPrice * 0.3; // Максимальная скидка - 30% от суммы

            // 1 балл = 1 рубль скидки, но не более 30% от стоимости
            double availableDiscount = Math.Min(_points, maxDiscount);

            return availableDiscount;
        }

        /// <summary>
        /// Применяет скидку к товарам и списывает баллы
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public double Apply(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            double totalPrice = items.Sum(item => item.Cost);
            double maxDiscount = totalPrice * 0.3; // Максимальная скидка - 30% от суммы

            // Определяем сколько баллов списать
            int pointsToDeduct;
            if (_points <= maxDiscount)
            {
                // Если баллов меньше или равно 30% - списываем все баллы
                pointsToDeduct = _points;
            }
            else
            {
                // Если баллов больше 30% - списываем только 30% от стоимости
                pointsToDeduct = (int)Math.Ceiling(maxDiscount);
            }

            double appliedDiscount = pointsToDeduct;

            // Списываем баллы
            Points = Math.Max(0, _points - pointsToDeduct);

            return appliedDiscount;
        }

        /// <summary>
        /// Добавляет баллы на основе списка товаров
        /// </summary>
        /// <param name="items"></param>
        public void Update(List<Item> items)
        {
            if (items == null || items.Count == 0)
                return;

            // Начисляем баллы: 10% от общей стоимости товаров, округляем в большую сторону
            double totalPrice = items.Sum(item => item.Cost);
            double pointsEarned = totalPrice * 0.1;
            int earnedPoints = (int)Math.Ceiling(pointsEarned);

            if (earnedPoints > 0)
            {
                Points += earnedPoints;
            }
        }

        /// <summary>
        /// Сравнивает текущий объект PointsDiscount с другим объектом PointsDiscount по количеству баллов.
        /// </summary>
        /// <param name="other">Объект PointsDiscount для сравнения с текущим объектом.</param>
        /// <returns>
        /// Меньше нуля: текущий объект имеет меньше баллов, чем другой объект.
        /// Ноль: объекты имеют одинаковое количество баллов.
        /// Больше нуля: текущий объект имеет больше баллов, чем другой объект.
        /// </returns>
        public int CompareTo(PointsDiscount other)
        {
            if (other is null) return 1; // null всегда меньше любого объекта

            return _points.CompareTo(other._points);
        }
    }
}
