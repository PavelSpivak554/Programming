using ObjectOrientedPractics.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class ItemsTab : UserControl
    {
        public ItemsTab()
        {
            InitializeComponent();
        }

        List<Item> _items = new List<Item>();
        public void ClearFields()
        {
            NameTextBox.Text = string.Empty;
            InfoTextBox.Text = string.Empty;
            CostTextBox.Text = string.Empty;
            IdTextBox.Text = string.Empty;
        }
        public void ListBoxUpdate()
        {
            ItemsListBox.Items.Clear();
            foreach (var item in _items)
            {
                ItemsListBox.Items.Add(item);
            }
            ItemsListBox.DisplayMember = "Name";
            ItemsListBox.ValueMember = "Id";

        }
        private void NametextBox_Validating()
        {
            string Name = NameTextBox.Text;
            if (string.IsNullOrWhiteSpace(Name))
            {
                NameTextBox.BackColor = Color.Red;
            }
            else
            {
                NameTextBox.BackColor = Color.White;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NametextBox_Validating();
            string itemName = NameTextBox.Text;
            string itemInfo = InfoTextBox.Text;
            int itemCost = Convert.ToInt32(CostTextBox.Text);

            Item item = new Item(itemName,itemInfo,itemCost);
            _items.Add(item);
            ListBoxUpdate();
        }
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            _items.Remove(selectedItem);
            ListBoxUpdate(); 
            ClearFields();   
                
        }

        private void ItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item selectedItem = (Item)ItemsListBox.SelectedItem;
            NameTextBox.Text = selectedItem.Name;
            InfoTextBox.Text = selectedItem.Info;
            CostTextBox.Text = selectedItem.Cost.ToString();
            IdTextBox.Text = selectedItem.Id.ToString();
        }
    }
}
