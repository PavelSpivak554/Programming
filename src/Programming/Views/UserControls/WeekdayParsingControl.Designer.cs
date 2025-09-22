namespace Programming.Views.UserControls
{
    partial class WeekdayParsingControl
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
            this.ParsingTextBox2 = new System.Windows.Forms.TextBox();
            this.ParsingLabel = new System.Windows.Forms.Label();
            this.ParseButton = new System.Windows.Forms.Button();
            this.ParsingTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ParsingTextBox2
            // 
            this.ParsingTextBox2.Location = new System.Drawing.Point(9, 72);
            this.ParsingTextBox2.Name = "ParsingTextBox2";
            this.ParsingTextBox2.ReadOnly = true;
            this.ParsingTextBox2.Size = new System.Drawing.Size(248, 22);
            this.ParsingTextBox2.TabIndex = 10;
            // 
            // ParsingLabel
            // 
            this.ParsingLabel.AutoSize = true;
            this.ParsingLabel.Location = new System.Drawing.Point(12, 10);
            this.ParsingLabel.Name = "ParsingLabel";
            this.ParsingLabel.Size = new System.Drawing.Size(144, 16);
            this.ParsingLabel.TabIndex = 9;
            this.ParsingLabel.Text = "Type value for parsing:";
            // 
            // ParseButton
            // 
            this.ParseButton.Location = new System.Drawing.Point(263, 31);
            this.ParseButton.Name = "ParseButton";
            this.ParseButton.Size = new System.Drawing.Size(75, 23);
            this.ParseButton.TabIndex = 8;
            this.ParseButton.Text = "Parse";
            this.ParseButton.UseVisualStyleBackColor = true;
            this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
            // 
            // ParsingTextBox
            // 
            this.ParsingTextBox.Location = new System.Drawing.Point(11, 32);
            this.ParsingTextBox.Name = "ParsingTextBox";
            this.ParsingTextBox.Size = new System.Drawing.Size(246, 22);
            this.ParsingTextBox.TabIndex = 7;
            // 
            // WeekdayParsingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParsingTextBox2);
            this.Controls.Add(this.ParsingLabel);
            this.Controls.Add(this.ParseButton);
            this.Controls.Add(this.ParsingTextBox);
            this.Name = "WeekdayParsingControl";
            this.Size = new System.Drawing.Size(346, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ParsingTextBox2;
        private System.Windows.Forms.Label ParsingLabel;
        private System.Windows.Forms.Button ParseButton;
        private System.Windows.Forms.TextBox ParsingTextBox;
    }
}
