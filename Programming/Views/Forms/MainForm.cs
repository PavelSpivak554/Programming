using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programming.Models;
using Programming.Models.Enums;
using static Programming.Models.Rectangle;

namespace Programming.Views.Forms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            WidthTextBox.Enter += TextBox_Enter;
            LengthTextBox.Enter += TextBox_Enter;
            ColorTextBox.Enter += TextBox_Enter;

            WidthTextBox.Leave += TextBox_Leave;
            LengthTextBox.Leave += TextBox_Leave;
            ColorTextBox.Leave += TextBox_Leave;
        }
        private Models.Rectangle[] _rectangles;
        private Models.Rectangle _currentRectangle;
        bool _isUserInput = false;
        private void TextBox_Enter(object sender, EventArgs e)
        {
            _isUserInput = true; // Пользователь начал ввод
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            _isUserInput = false; // Пользователь завершил ввод
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

        private void ParseButton_Click(object sender, EventArgs e)
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

        private void SeasonButton_Click(object sender, EventArgs e)
        {
            switch (SeasonComboBox.SelectedItem)
            {
                case "Winter":
                    MessageBox.Show("Бррр! Холодно!", "Зима", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case "Spring":
                    this.tabPage1.BackColor = System.Drawing.Color.Green;
                    MessageBox.Show("Все зеленое!", "Весна", MessageBoxButtons.YesNo);
                    break;
                case "Summer":
                    MessageBox.Show("Ура! Солнце!", "Лето", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "Autumn":
                    this.tabPage1.BackColor = System.Drawing.Color.Orange;
                    MessageBox.Show("Листья Падают", "Осень");
                    break;

            }
        }

        private void CreateRectangleButton_Click(object sender, EventArgs e)
        {
            _rectangles = new Models.Rectangle[5];
            Random random = new Random();
            for (int i = 0; i < _rectangles.Length; i++)
            {
                int length = random.Next(1, 100); // Случайная длина
                int width = random.Next(1, 100);  // Случайная ширина
                string color = "Color" + i;       // Пример цвета
                _rectangles[i] = new Models.Rectangle(length, width, color);
            }
            _currentRectangle = _rectangles[0];
            WidthTextBox.BackColor = System.Drawing.Color.White;
            LengthTextBox.BackColor = System.Drawing.Color.White;
            ColorTextBox.BackColor = System.Drawing.Color.White;

        }

        private void RectangleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RectangleTextChange(RectangleListBox.SelectedIndex);
        }
        private void RectangleTextChange(int i)
        {
            var Width = _rectangles[i].Width;
            var Length = _rectangles[i].Length;
            var Color = _rectangles[i].Color;
            // Обновляем текстовые поля значениями ширины, высоты и цвета
            WidthTextBox.Text = Width.ToString();
            LengthTextBox.Text = Length.ToString();
            ColorTextBox.Text = Color.ToString();
        }

        private void LengthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Length = 0;
            try
            {
                if (Int32.TryParse(LengthTextBox.Text, out Length))
                {
                    var rect = _rectangles[RectangleListBox.SelectedIndex];
                    rect.Length = Length;
                }
                else
                {
                    MessageBox.Show("Недопустимое значение:");
                    LengthTextBox.BackColor = System.Drawing.Color.Red;
                }
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Недопустимое значение:");
                LengthTextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            var Width = 0;
            try
            {
                if (Int32.TryParse(WidthTextBox.Text, out Width))
                {
                var rect = _rectangles[RectangleListBox.SelectedIndex];
                rect.Width = Width;
                }
                else
                {   
                    MessageBox.Show("Недопустимое значение:");
                    WidthTextBox.BackColor = System.Drawing.Color.Red;
                }
            }
            
            catch(ArgumentOutOfRangeException) 
            {
                MessageBox.Show("Недопустимое значение:");
                WidthTextBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void ColorTextBox_TextChanged(object sender, EventArgs e)
        {
            var Color = ColorTextBox.Text;
            var rect = _rectangles[RectangleListBox.SelectedIndex];
            rect.Color = Color;
        }

        int FindRectangleWithMaxWidth(Models.Rectangle[] rectangle)
        {
            double maxWidth = 0;
            int maxIndex = 0;
            for (int i =0; i<rectangle.Length; i++)
            {
                if (rectangle[i].Width > maxWidth)
                {
                    maxWidth = rectangle[i].Width;
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            int index = FindRectangleWithMaxWidth(_rectangles);
            RectangleListBox.SelectedIndex = index;
        }
    }
}
