using Programming.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming.Views.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EnumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as ListBox).SelectedIndex)
            {
                case 0:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Models.Enums.Color));
                    break;
                case 1:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Education));
                    break;
                case 2:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Genre));
                    break;
                case 3:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Season));
                    break;
                case 4:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(SmartManufacturers));
                    break;
                case 5:
                    ValuesListBox.DataSource = Enum.GetValues(typeof(Weekday));
                    break;
            }
        }

        private void ValuesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ValueTextBox.Text = Convert.ToInt32(ValuesListBox.SelectedValue).ToString();

        }
    }
}
