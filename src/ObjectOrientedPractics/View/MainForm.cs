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

            // Передача данных во вкладки (пункт 5)
            itemsTab1.Items = _store.Items;
            customersTab1.Customers = _store.Customers;

            // Пункт 6 - передача тех же экземпляров списков
            cartsTab1.Items = _store.Items;
            cartsTab1.Customers = _store.Customers;

            // Подписка на событие смены вкладки (пункт 19)
            tabControl1.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void InitializeStore()
        {
            // Добавление тестовых данных

            _store.Items.Add(new Item("Ноутбук", "Игровой ноутбук с RTX 4060", 89999.99, Category.Electronics));
            _store.Items.Add(new Item("Книга", "Программирование на C#", 2499.99, Category.Books));
            _store.Items.Add(new Item("Кофе", "Арабика, 250г", 599.99, Category.Food));
            _store.Items.Add(new Item("Футболка", "Хлопковая, черная", 1299.99, Category.Clothing));
            _store.Items.Add(new Item("Наушники", "Беспроводные, шумоподавление", 5999.99, Category.Electronics));

        }

        /// <summary>
        /// Обработчик смены выбранной вкладки.
        /// При переключении на вкладку Carts обновляет данные.
        /// </summary>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Предположим, что вкладка Carts имеет индекс 2
            if (tabControl1.SelectedIndex == 2)
            {
                cartsTab1.RefreshData(); // Пункт 19
            }
        }
    }
}
