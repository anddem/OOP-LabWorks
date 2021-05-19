
namespace LabWork_15
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ellipseRadius = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.borderColorPicker = new System.Windows.Forms.PictureBox();
            this.priorityPicker = new System.Windows.Forms.ComboBox();
            this.figuresOnPictureBoxLabel = new System.Windows.Forms.Label();
            this.fillColorPicker = new System.Windows.Forms.PictureBox();
            this.redrawSpeed = new System.Windows.Forms.TrackBar();
            this.speedValueLabel = new System.Windows.Forms.Label();
            this.figureColorPcker = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redrawSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(347, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(441, 426);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLabel.Location = new System.Drawing.Point(12, 88);
            this.errorLabel.MaximumSize = new System.Drawing.Size(329, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 25);
            this.errorLabel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 73);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить шар на холст";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ellipseRadius
            // 
            this.ellipseRadius.Location = new System.Drawing.Point(12, 12);
            this.ellipseRadius.Name = "ellipseRadius";
            this.ellipseRadius.PlaceholderText = "Радиус";
            this.ellipseRadius.Size = new System.Drawing.Size(139, 32);
            this.ellipseRadius.TabIndex = 5;
            this.ellipseRadius.TextChanged += new System.EventHandler(this.TextBoxToInt);
            // 
            // borderColorPicker
            // 
            this.borderColorPicker.BackColor = System.Drawing.SystemColors.Highlight;
            this.borderColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.borderColorPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borderColorPicker.Location = new System.Drawing.Point(12, 241);
            this.borderColorPicker.Name = "borderColorPicker";
            this.borderColorPicker.Size = new System.Drawing.Size(32, 32);
            this.borderColorPicker.TabIndex = 6;
            this.borderColorPicker.TabStop = false;
            this.borderColorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // priorityPicker
            // 
            this.priorityPicker.FormattingEnabled = true;
            this.priorityPicker.Items.AddRange(new object[] {
            "Низкий",
            "Ниже нормального",
            "Нормальный",
            "Выше нормального",
            "Высокий"});
            this.priorityPicker.Location = new System.Drawing.Point(12, 52);
            this.priorityPicker.Name = "priorityPicker";
            this.priorityPicker.Size = new System.Drawing.Size(139, 33);
            this.priorityPicker.TabIndex = 7;
            this.priorityPicker.Text = "Приоритет";
            // 
            // figuresOnPictureBoxLabel
            // 
            this.figuresOnPictureBoxLabel.AutoSize = true;
            this.figuresOnPictureBoxLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.figuresOnPictureBoxLabel.Location = new System.Drawing.Point(12, 304);
            this.figuresOnPictureBoxLabel.Name = "figuresOnPictureBoxLabel";
            this.figuresOnPictureBoxLabel.Size = new System.Drawing.Size(199, 32);
            this.figuresOnPictureBoxLabel.TabIndex = 8;
            this.figuresOnPictureBoxLabel.Text = "Фигур на поле: 0";
            // 
            // fillColorPicker
            // 
            this.fillColorPicker.BackColor = System.Drawing.Color.White;
            this.fillColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fillColorPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fillColorPicker.Location = new System.Drawing.Point(12, 203);
            this.fillColorPicker.Name = "fillColorPicker";
            this.fillColorPicker.Size = new System.Drawing.Size(32, 32);
            this.fillColorPicker.TabIndex = 9;
            this.fillColorPicker.TabStop = false;
            this.fillColorPicker.Click += new System.EventHandler(this.fillColorPicker_Click);
            // 
            // redrawSpeed
            // 
            this.redrawSpeed.LargeChange = 25;
            this.redrawSpeed.Location = new System.Drawing.Point(12, 393);
            this.redrawSpeed.Maximum = 100;
            this.redrawSpeed.Minimum = 1;
            this.redrawSpeed.Name = "redrawSpeed";
            this.redrawSpeed.Size = new System.Drawing.Size(329, 45);
            this.redrawSpeed.SmallChange = 30;
            this.redrawSpeed.TabIndex = 10;
            this.redrawSpeed.Tag = "";
            this.redrawSpeed.Value = 1;
            // 
            // speedValueLabel
            // 
            this.speedValueLabel.AutoSize = true;
            this.speedValueLabel.Location = new System.Drawing.Point(12, 365);
            this.speedValueLabel.MaximumSize = new System.Drawing.Size(329, 0);
            this.speedValueLabel.Name = "speedValueLabel";
            this.speedValueLabel.Size = new System.Drawing.Size(266, 25);
            this.speedValueLabel.TabIndex = 11;
            this.speedValueLabel.Text = "Скорость обновления холста";
            // 
            // figureColorPcker
            // 
            this.figureColorPcker.AutoSize = true;
            this.figureColorPcker.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.figureColorPcker.Location = new System.Drawing.Point(50, 203);
            this.figureColorPcker.Name = "figureColorPcker";
            this.figureColorPcker.Size = new System.Drawing.Size(263, 32);
            this.figureColorPcker.TabIndex = 12;
            this.figureColorPcker.Text = "– выбор цвета фигуры";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "– выбор цвета обводки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(792, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.figureColorPcker);
            this.Controls.Add(this.speedValueLabel);
            this.Controls.Add(this.redrawSpeed);
            this.Controls.Add(this.fillColorPicker);
            this.Controls.Add(this.figuresOnPictureBoxLabel);
            this.Controls.Add(this.priorityPicker);
            this.Controls.Add(this.borderColorPicker);
            this.Controls.Add(this.ellipseRadius);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.canvas);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Лабораторная работа 15. Шарики";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderColorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fillColorPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redrawSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ellipseRadius;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox borderColorPicker;
        private System.Windows.Forms.ComboBox priorityPicker;
        private System.Windows.Forms.Label figuresOnPictureBoxLabel;
        private System.Windows.Forms.PictureBox fillColorPicker;
        private System.Windows.Forms.TrackBar redrawSpeed;
        private System.Windows.Forms.Label speedValueLabel;
        private System.Windows.Forms.Label figureColorPcker;
        private System.Windows.Forms.Label label1;
    }
}

