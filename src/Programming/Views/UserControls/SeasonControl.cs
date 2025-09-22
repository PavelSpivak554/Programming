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
    public partial class SeasonControl : UserControl
    {
        public SeasonControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// События при выборе времени года.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeasonButton_Click(object sender, EventArgs e)
        {
            switch (SeasonComboBox.SelectedItem)
            {
                case "Winter":
                    MessageBox.Show("Бррр! Холодно!", "Зима", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case "Spring":
                    MessageBox.Show("Все зеленое!", "Весна", MessageBoxButtons.YesNo);
                    break;
                case "Summer":
                    MessageBox.Show("Ура! Солнце!", "Лето", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "Autumn":
                    MessageBox.Show("Листья Падают", "Осень");
                    break;

            }
        }
    }
}
