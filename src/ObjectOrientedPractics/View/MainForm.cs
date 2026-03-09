using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ObjectOrientedPractics
{
    public partial class MainForm : Form
    {
        private Store _store = new Store();

        public MainForm()
        {
            InitializeComponent();

            // Инициализация данных
            InitializeStore();

            // Передача данных во вкладки
            itemsTab1.Items = _store.Items;
            customersTab1.Customers = _store.Customers;
            cartsTab1.Items = _store.Items;
            cartsTab1.Customers = _store.Customers;
            ordersTab1.Customers = _store.Customers;

            // Смена вкладки
            tabControl1.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void InitializeStore()
        {
            // Добавление тестовых товаров
            _store.Items.Add(new Item("Ноутбук", "Игровой ноутбук с RTX 4060", 89999.99, Category.Electronics));
            _store.Items.Add(new Item("Книга", "Программирование на C#", 2499.99, Category.Books));
            _store.Items.Add(new Item("Кофе", "Арабика, 250г", 599.99, Category.Food));
            _store.Items.Add(new Item("Футболка", "Хлопковая, черная", 1299.99, Category.Clothing));
            _store.Items.Add(new Item("Наушники", "Беспроводные, шумоподавление", 5999.99, Category.Electronics));

            // Создаем адреса для покупателей
            Address address1 = new Address(123456, "Россия", "Томск", "Ленина", "10", "15");
            Address address2 = new Address(654321, "Россия", "Санкт-Петербург", "Невский", "20", "5");

            // Создаем покупателей
            Customer customer1 = new Customer("Никитос", address1);
            Customer customer2 = new Customer("Темыч", address2);

            // Добавляем товары в корзину первого покупателя
            customer1.Cart.Items.Add(_store.Items[0]);
            customer1.Cart.Items.Add(_store.Items[1]);
            customer1.Cart.Items.Add(_store.Items[4]);

            // Создаем заказ из корзины первого покупателя
            Order order1 = new Order(customer1.Cart, customer1.Address);
            customer1.Orders.Add(order1);

            customer2.Cart.Items.Add(_store.Items[2]); // Кофе
            customer2.Cart.Items.Add(_store.Items[3]); // Футболка

            // Создаем заказ из корзины второго покупателя
            Order order2 = new Order(customer2.Cart, customer2.Address);
            customer2.Orders.Add(order2);

            _store.Customers.Add(customer1);
            _store.Customers.Add(customer2);
        }

        /// <summary>
        /// Обработчик смены выбранной вкладки.
        /// При переключении на вкладки Carts и Orders обновляет данные.
        /// </summary>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Обновляем данные при переключении на вкладку Carts (индекс 2)
            if (tabControl1.SelectedIndex == 2)
            {
                cartsTab1.RefreshData();
            }

            // Обновляем данные при переключении на вкладку Orders (индекс 3)
            if (tabControl1.SelectedIndex == 3)
            {
                ordersTab1.RefreshData();
            }
        }
    }
}