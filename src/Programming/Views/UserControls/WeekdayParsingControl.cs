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

namespace Programming.Views.UserControls
{
    public partial class WeekdayParsingControl : UserControl
    {
        public WeekdayParsingControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Проверка дня недели.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParseButton_Click(object sender, EventArgs e)
        {
            {
                string input = ParsingTextBox.Text;
                if (Enum.TryParse<Weekday>(input, true, out Weekday weekday))
                {
                    ParsingTextBox2.Text = $"Это день недели {weekday} = {(int)weekday}";
                }
                else
                {
                    ParsingTextBox2.Text = "Нет такого дня недели";

                }
            }
        }
    }
}
