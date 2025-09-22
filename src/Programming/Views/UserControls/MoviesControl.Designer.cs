namespace Programming.Views.UserControls
{
    partial class MoviesControl
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
            this.MovieRatingTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MovieGenreTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateMovieButton = new System.Windows.Forms.Button();
            this.FindMovieButton = new System.Windows.Forms.Button();
            this.MovieYearTextBox = new System.Windows.Forms.TextBox();
            this.MovieDurationTextBox = new System.Windows.Forms.TextBox();
            this.MovieNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MovieListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // MovieRatingTextBox
            // 
            this.MovieRatingTextBox.Location = new System.Drawing.Point(147, 195);
            this.MovieRatingTextBox.Name = "MovieRatingTextBox";
            this.MovieRatingTextBox.Size = new System.Drawing.Size(100, 22);
            this.MovieRatingTextBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Rating:";
            // 
            // MovieGenreTextBox
            // 
            this.MovieGenreTextBox.Location = new System.Drawing.Point(147, 151);
            this.MovieGenreTextBox.Name = "MovieGenreTextBox";
            this.MovieGenreTextBox.Size = new System.Drawing.Size(100, 22);
            this.MovieGenreTextBox.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Genre:";
            // 
            // CreateMovieButton
            // 
            this.CreateMovieButton.Location = new System.Drawing.Point(147, 221);
            this.CreateMovieButton.Name = "CreateMovieButton";
            this.CreateMovieButton.Size = new System.Drawing.Size(75, 23);
            this.CreateMovieButton.TabIndex = 21;
            this.CreateMovieButton.Text = "Create";
            this.CreateMovieButton.UseVisualStyleBackColor = true;
            this.CreateMovieButton.Click += new System.EventHandler(this.CreateMovieButton_Click);
            // 
            // FindMovieButton
            // 
            this.FindMovieButton.Location = new System.Drawing.Point(228, 221);
            this.FindMovieButton.Name = "FindMovieButton";
            this.FindMovieButton.Size = new System.Drawing.Size(75, 23);
            this.FindMovieButton.TabIndex = 20;
            this.FindMovieButton.Text = "Find";
            this.FindMovieButton.UseVisualStyleBackColor = true;
            this.FindMovieButton.Click += new System.EventHandler(this.FindMovieButton_Click);
            // 
            // MovieYearTextBox
            // 
            this.MovieYearTextBox.Location = new System.Drawing.Point(147, 107);
            this.MovieYearTextBox.Name = "MovieYearTextBox";
            this.MovieYearTextBox.Size = new System.Drawing.Size(100, 22);
            this.MovieYearTextBox.TabIndex = 19;
            // 
            // MovieDurationTextBox
            // 
            this.MovieDurationTextBox.Location = new System.Drawing.Point(147, 63);
            this.MovieDurationTextBox.Name = "MovieDurationTextBox";
            this.MovieDurationTextBox.Size = new System.Drawing.Size(100, 22);
            this.MovieDurationTextBox.TabIndex = 18;
            // 
            // MovieNameTextBox
            // 
            this.MovieNameTextBox.Location = new System.Drawing.Point(147, 19);
            this.MovieNameTextBox.Name = "MovieNameTextBox";
            this.MovieNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.MovieNameTextBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Duration:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name";
            // 
            // MovieListBox
            // 
            this.MovieListBox.FormattingEnabled = true;
            this.MovieListBox.ItemHeight = 16;
            this.MovieListBox.Items.AddRange(new object[] {
            "Movie 1",
            "Movie 2",
            "Movie 3",
            "Movie 4",
            "Movie 5"});
            this.MovieListBox.Location = new System.Drawing.Point(3, 3);
            this.MovieListBox.Name = "MovieListBox";
            this.MovieListBox.Size = new System.Drawing.Size(120, 212);
            this.MovieListBox.TabIndex = 13;
            this.MovieListBox.SelectedIndexChanged += new System.EventHandler(this.MovieListBox_SelectedIndexChanged);
            // 
            // MoviesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MovieRatingTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MovieGenreTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CreateMovieButton);
            this.Controls.Add(this.FindMovieButton);
            this.Controls.Add(this.MovieYearTextBox);
            this.Controls.Add(this.MovieDurationTextBox);
            this.Controls.Add(this.MovieNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MovieListBox);
            this.Name = "MoviesControl";
            this.Size = new System.Drawing.Size(308, 249);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MovieRatingTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MovieGenreTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateMovieButton;
        private System.Windows.Forms.Button FindMovieButton;
        private System.Windows.Forms.TextBox MovieYearTextBox;
        private System.Windows.Forms.TextBox MovieDurationTextBox;
        private System.Windows.Forms.TextBox MovieNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox MovieListBox;
    }
}
