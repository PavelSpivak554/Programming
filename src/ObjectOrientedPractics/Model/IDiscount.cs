using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Model
{
    public interface IDiscount
    {
        /// <summary>
        /// Информация о скидке
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Рассчитывает размер скидки для списка товаров
        /// </summary>
        /// <param name="items">Список товаров</param>
        /// <returns>Размер скидки</returns>
        double Calculate(List<Item> items);

        /// <summary>
        /// Применяет скидку к товарам
        /// </summary>
        /// <param name="items">Список товаров</param>
        /// <returns>Размер примененной скидки</returns>
        double Apply(List<Item> items);

        /// <summary>
        /// Обновляет скидку на основе списка товаров
        /// </summary>
        /// <param name="items">Список товаров</param>
        void Update(List<Item> items);
    }
}
