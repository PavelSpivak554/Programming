namespace Programming.Views.UserControls
{
    partial class RectanglesControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InterTextBox2 = new System.Windows.Forms.TextBox();
            this.InterTextBox1 = new System.Windows.Forms.TextBox();
            this.IntersectionButton = new System.Windows.Forms.Button();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CenterYtextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CenterXtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CreateRectangleButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.ColorTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.RectangleListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // InterTextBox2
            // 
            this.InterTextBox2.Location = new System.Drawing.Point(298, 164);
            this.InterTextBox2.Name = "InterTextBox2";
            this.InterTextBox2.Size = new System.Drawing.Size(24, 22);
            this.InterTextBox2.TabIndex = 35;
            // 
            // InterTextBox1
            // 
            this.InterTextBox1.Location = new System.Drawing.Point(247, 164);
            this.InterTextBox1.Name = "InterTextBox1";
            this.InterTextBox1.Size = new System.Drawing.Size(24, 22);
            this.InterTextBox1.TabIndex = 34;
            // 
            // IntersectionButton
            // 
            this.IntersectionButton.Location = new System.Drawing.Point(247, 192);
            this.IntersectionButton.Name = "IntersectionButton";
            this.IntersectionButton.Size = new System.Drawing.Size(102, 23);
            this.IntersectionButton.TabIndex = 33;
            this.IntersectionButton.Text = "Intersection";
            this.IntersectionButton.UseVisualStyleBackColor = true;
            this.IntersectionButton.Click += new System.EventHandler(this.IntersectionButton_Click);
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(274, 117);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.Size = new System.Drawing.Size(100, 22);
            this.IDTextBox.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(271, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "ID:";
            // 
            // CenterYtextBox
            // 
            this.CenterYtextBox.Location = new System.Drawing.Point(274, 72);
            this.CenterYtextBox.Name = "CenterYtextBox";
            this.CenterYtextBox.ReadOnly = true;
            this.CenterYtextBox.Size = new System.Drawing.Size(100, 22);
            this.CenterYtextBox.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(271, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Center Y:";
            // 
            // CenterXtextBox
            // 
            this.CenterXtextBox.Location = new System.Drawing.Point(274, 23);
            this.CenterXtextBox.Name = "CenterXtextBox";
            this.CenterXtextBox.ReadOnly = true;
            this.CenterXtextBox.Size = new System.Drawing.Size(100, 22);
            this.CenterXtextBox.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Center X:";
            // 
            // CreateRectangleButton
            // 
            this.CreateRectangleButton.Location = new System.Drawing.Point(147, 191);
            this.CreateRectangleButton.Name = "CreateRectangleButton";
            this.CreateRectangleButton.Size = new System.Drawing.Size(75, 23);
            this.CreateRectangleButton.TabIndex = 26;
            this.CreateRectangleButton.Text = "Create";
            this.CreateRectangleButton.UseVisualStyleBackColor = true;
            this.CreateRectangleButton.Click += new System.EventHandler(this.CreateRectangleButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(147, 162);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(75, 23);
            this.FindButton.TabIndex = 25;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // ColorTextBox
            // 
            this.ColorTextBox.Location = new System.Drawing.Point(147, 114);
            this.ColorTextBox.Name = "ColorTextBox";
            this.ColorTextBox.Size = new System.Drawing.Size(100, 22);
            this.ColorTextBox.TabIndex = 24;
            this.ColorTextBox.TextChanged += new System.EventHandler(this.ColorTextBox_TextChanged);
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(147, 71);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.WidthTextBox.TabIndex = 23;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(147, 23);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.LengthTextBox.TabIndex = 22;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Location = new System.Drawing.Point(144, 95);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(42, 16);
            this.ColorLabel.TabIndex = 21;
            this.ColorLabel.Text = "Color:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(144, 52);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(44, 16);
            this.WidthLabel.TabIndex = 20;
            this.WidthLabel.Text = "Width:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(144, 3);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(50, 16);
            this.LengthLabel.TabIndex = 19;
            this.LengthLabel.Text = "Length:";
            // 
            // RectangleListBox
            // 
            this.RectangleListBox.FormattingEnabled = true;
            this.RectangleListBox.ItemHeight = 16;
            this.RectangleListBox.Items.AddRange(new object[] {
            "Rectangle 1",
            "Rectangle 2",
            "Rectangle 3",
            "Rectangle 4",
            "Rectangle 5"});
            this.RectangleListBox.Location = new System.Drawing.Point(3, 3);
            this.RectangleListBox.Name = "RectangleListBox";
            this.RectangleListBox.Size = new System.Drawing.Size(120, 212);
            this.RectangleListBox.TabIndex = 18;
            this.RectangleListBox.SelectedIndexChanged += new System.EventHandler(this.RectangleListBox_SelectedIndexChanged);
            // 
            // RectanglesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InterTextBox2);
            this.Controls.Add(this.InterTextBox1);
            this.Controls.Add(this.IntersectionButton);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CenterYtextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CenterXtextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CreateRectangleButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.ColorTextBox);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.LengthTextBox);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.RectangleListBox);
            this.Name = "RectanglesControl";
            this.Size = new System.Drawing.Size(378, 221);
            this.Load += new System.EventHandler(this.RectanglesControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InterTextBox2;
        private System.Windows.Forms.TextBox InterTextBox1;
        private System.Windows.Forms.Button IntersectionButton;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CenterYtextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CenterXtextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CreateRectangleButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.TextBox ColorTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.ListBox RectangleListBox;
    }
}
