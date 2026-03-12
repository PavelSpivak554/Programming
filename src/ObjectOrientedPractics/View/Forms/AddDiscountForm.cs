using ObjectOrientedPractics.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.View.Forms
{
    public partial class AddDiscountForm : Form
    {
        public Category SelectedCategory { get; private set; }
        public AddDiscountForm()
        {
            InitializeComponent();
            InitializeCategoryComboBox();

            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeCategoryComboBox()
        {
            // Заполняем комбобокс категориями при создании формы
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {
                CategoryComboBox.Items.Add(category);
            }
            CategoryComboBox.SelectedIndex = 0;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Сохраняем выбранную категорию и закрываем форму с результатом OK
            SelectedCategory = (Category)CategoryComboBox.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Закрываем форму с результатом Cancel
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
