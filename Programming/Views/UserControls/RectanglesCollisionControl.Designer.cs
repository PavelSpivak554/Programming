namespace Programming.Views.UserControls
{
    partial class RectanglesCollisionControl
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.DelRectButton = new System.Windows.Forms.Button();
            this.AddRectButton = new System.Windows.Forms.Button();
            this.RectanglesPanel = new System.Windows.Forms.Panel();
            this.RectWidthTextBox = new System.Windows.Forms.TextBox();
            this.RectLengthTextBox = new System.Windows.Forms.TextBox();
            this.RectYTextBox = new System.Windows.Forms.TextBox();
            this.RectXTextBox = new System.Windows.Forms.TextBox();
            this.RectIDTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.RectListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(279, 152);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 42;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DelRectButton
            // 
            this.DelRectButton.Location = new System.Drawing.Point(141, 152);
            this.DelRectButton.Name = "DelRectButton";
            this.DelRectButton.Size = new System.Drawing.Size(75, 23);
            this.DelRectButton.TabIndex = 41;
            this.DelRectButton.Text = "Delete";
            this.DelRectButton.UseVisualStyleBackColor = true;
            this.DelRectButton.Click += new System.EventHandler(this.DelRectButton_Click);
            // 
            // AddRectButton
            // 
            this.AddRectButton.Location = new System.Drawing.Point(10, 152);
            this.AddRectButton.Name = "AddRectButton";
            this.AddRectButton.Size = new System.Drawing.Size(75, 23);
            this.AddRectButton.TabIndex = 40;
            this.AddRectButton.Text = "Add";
            this.AddRectButton.UseVisualStyleBackColor = true;
            this.AddRectButton.Click += new System.EventHandler(this.AddRectButton_Click);
            // 
            // RectanglesPanel
            // 
            this.RectanglesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RectanglesPanel.Location = new System.Drawing.Point(370, 14);
            this.RectanglesPanel.Name = "RectanglesPanel";
            this.RectanglesPanel.Size = new System.Drawing.Size(411, 407);
            this.RectanglesPanel.TabIndex = 39;
            // 
            // RectWidthTextBox
            // 
            this.RectWidthTextBox.Location = new System.Drawing.Point(57, 328);
            this.RectWidthTextBox.Name = "RectWidthTextBox";
            this.RectWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.RectWidthTextBox.TabIndex = 38;
            // 
            // RectLengthTextBox
            // 
            this.RectLengthTextBox.Location = new System.Drawing.Point(57, 303);
            this.RectLengthTextBox.Name = "RectLengthTextBox";
            this.RectLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.RectLengthTextBox.TabIndex = 37;
            // 
            // RectYTextBox
            // 
            this.RectYTextBox.Location = new System.Drawing.Point(57, 278);
            this.RectYTextBox.Name = "RectYTextBox";
            this.RectYTextBox.Size = new System.Drawing.Size(100, 22);
            this.RectYTextBox.TabIndex = 36;
            // 
            // RectXTextBox
            // 
            this.RectXTextBox.Location = new System.Drawing.Point(57, 254);
            this.RectXTextBox.Name = "RectXTextBox";
            this.RectXTextBox.Size = new System.Drawing.Size(100, 22);
            this.RectXTextBox.TabIndex = 35;
            // 
            // RectIDTextBox
            // 
            this.RectIDTextBox.Location = new System.Drawing.Point(57, 229);
            this.RectIDTextBox.Name = "RectIDTextBox";
            this.RectIDTextBox.ReadOnly = true;
            this.RectIDTextBox.Size = new System.Drawing.Size(100, 22);
            this.RectIDTextBox.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 33;
            this.label14.Text = "Width:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 16);
            this.label13.TabIndex = 32;
            this.label13.Text = "Length:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 16);
            this.label12.TabIndex = 31;
            this.label12.Text = "ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "Y:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 16);
            this.label10.TabIndex = 29;
            this.label10.Text = "X:";
            // 
            // RectListBox
            // 
            this.RectListBox.FormattingEnabled = true;
            this.RectListBox.ItemHeight = 16;
            this.RectListBox.Location = new System.Drawing.Point(1, 30);
            this.RectListBox.Name = "RectListBox";
            this.RectListBox.Size = new System.Drawing.Size(363, 116);
            this.RectListBox.TabIndex = 27;
            this.RectListBox.SelectedIndexChanged += new System.EventHandler(this.RectListBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Rectangles";
            // 
            // RectanglesCollisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DelRectButton);
            this.Controls.Add(this.AddRectButton);
            this.Controls.Add(this.RectanglesPanel);
            this.Controls.Add(this.RectWidthTextBox);
            this.Controls.Add(this.RectLengthTextBox);
            this.Controls.Add(this.RectYTextBox);
            this.Controls.Add(this.RectXTextBox);
            this.Controls.Add(this.RectIDTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RectListBox);
            this.Controls.Add(this.label9);
            this.Name = "RectanglesCollisionControl";
            this.Size = new System.Drawing.Size(788, 429);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DelRectButton;
        private System.Windows.Forms.Button AddRectButton;
        private System.Windows.Forms.Panel RectanglesPanel;
        private System.Windows.Forms.TextBox RectWidthTextBox;
        private System.Windows.Forms.TextBox RectLengthTextBox;
        private System.Windows.Forms.TextBox RectYTextBox;
        private System.Windows.Forms.TextBox RectXTextBox;
        private System.Windows.Forms.TextBox RectIDTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox RectListBox;
        private System.Windows.Forms.Label label9;
    }
}
