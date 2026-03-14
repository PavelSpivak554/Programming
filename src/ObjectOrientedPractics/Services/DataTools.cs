using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model.Enums;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Предоставляет методы для обработки и фильтрации данных.
    /// </summary>
    public class DataTools
    {
        /// <summary>
        /// Фильтрует товары, оставляя только те, стоимость которых выше 5000.
        /// </summary>
        /// <param name="items">Список товаров для фильтрации.</param>
        /// <returns>Новый список товаров с ценой выше 5000.</returns>
        public static List<Item> FilterExpensiveItems(List<Item> items)
        {
            List<Item> expensiveItems = new List<Item>();
            foreach (var item in items)
            {
                if (item.Cost > 5000)
                {
                    expensiveItems.Add(item);
                }
            }
            return expensiveItems;
        }

        /// <summary>
        /// Фильтрует товары, оставляя только те, которые относятся к категории Electronics.
        /// </summary>
        /// <param name="items">Список товаров для фильтрации.</param>
        /// <returns>Новый список товаров категории Electronics.</returns>
        public static List<Item> FilterElectronicItems(List<Item> items)
        {
            List<Item> electronicItems = new List<Item>();
            foreach (var item in items)
            {
                if(item.Category == Category.Electronics)
                {
                    electronicItems.Add(item);
                }
            }
            return electronicItems;
        }

        /// <summary>
        /// Делегат для определения критерия фильтрации товаров.
        /// </summary>
        /// <param name="item">Товар для проверки.</param>
        /// <returns>true, если товар удовлетворяет критерию; иначе false.</returns>
        public delegate bool CompareItems(Item item);

        /// <summary>
        /// Определяет критерий "цена выше 5000" для фильтрации.
        /// </summary>
        /// <param name="item">Товар для проверки.</param>
        /// <returns>true, если цена товара выше 5000; иначе false.</returns>
        public static bool CompareExpensivePrice(Item item)
        {
            return item.Cost > 5000;
        }

        /// <summary>
        /// Определяет критерий "категория Electronics" для фильтрации.
        /// </summary>
        /// <param name="item">Товар для проверки.</param>
        /// <returns>true, если категория товара Electronics; иначе false.</returns>
        public static bool CompareElectronicCategory(Item item)
        {
            return item.Category == Category.Electronics;
        }

        /// <summary>
        /// Фильтрует список товаров по заданному критерию.
        /// </summary>
        /// <param name="items">Список товаров для фильтрации.</param>
        /// <param name="compare">Делегат, определяющий критерий фильтрации.</param>
        /// <returns>Новый список товаров, удовлетворяющих критерию.</returns>
        public static List<Item> Filter(List<Item> items, Func<Item, bool> compare)
        {
            List<Item> newItems = new List<Item>();
            foreach(var item in items)
            {
                if (compare(item))
                {
                    newItems.Add(item);
                }
            }
            return newItems;
        }
        /// <summary>
        /// Сортирует список товаров с использованием переданного метода сравнения.
        /// </summary>
        /// <param name="items">Список товаров для сортировки.</param>
        /// <param name="compare">Делегат, определяющий порядок сортировки. 
        /// Должен возвращать true, если первый элемент должен быть после второго.</param>
        public static List<Item> Sort(List<Item> items, Func<Item, Item, bool> compare)
        {
            List<Item> sortedList = new List<Item>(items);

            for (int i = 0; i < sortedList.Count - 1; i++)
            {
                for (int j = 0; j < sortedList.Count - 1 - i; j++)
                {
                    if (compare(sortedList[j], sortedList[j + 1]))
                    {
                        Item temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                    }
                }
            }
            return sortedList;  
        }

        /// <summary>
        /// Сравнивает два товара по имени (лексикографически).
        /// </summary>
        /// <param name="x">Первый товар для сравнения.</param>
        /// <param name="y">Второй товар для сравнения.</param>
        /// <returns>true, если имя первого товара больше имени второго (по алфавиту); иначе false.</returns
        public static bool CompareByName(Item x, Item y)
        {
            return string.Compare(x.Name, y.Name) > 0;  
        }
        /// <summary>
        /// Сравнивает два товара по цене (для сортировки по возрастанию).
        /// </summary>
        /// <param name="x">Первый товар для сравнения.</param>
        /// <param name="y">Второй товар для сравнения.</param>
        /// <returns>true, если цена первого товара больше цены второго; иначе false.</returns>
        public static bool CompareByCostAscending(Item x, Item y)
        {
            return x.Cost > y.Cost;  
        }
        /// <summary>
        /// Сравнивает два товара по цене (для сортировки по убыванию).
        /// </summary>
        /// <param name="x">Первый товар для сравнения.</param>
        /// <param name="y">Второй товар для сравнения.</param>
        /// <returns>true, если цена первого товара меньше цены второго; иначе false.</returns>
        public static bool CompareByCostDescending(Item x, Item y)
        {
            return x.Cost < y.Cost;  
        }
    }
}