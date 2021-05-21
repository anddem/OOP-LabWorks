
namespace LabWork_16
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.confirmRangeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(0, 59);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(0, 9, 0, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // confirmRangeButton
            // 
            this.confirmRangeButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmRangeButton.Location = new System.Drawing.Point(50, 527);
            this.confirmRangeButton.Name = "confirmRangeButton";
            this.confirmRangeButton.Size = new System.Drawing.Size(568, 35);
            this.confirmRangeButton.TabIndex = 1;
            this.confirmRangeButton.Text = "Узнать среднюю температуру за выбранный период";
            this.confirmRangeButton.UseVisualStyleBackColor = true;
            this.confirmRangeButton.Click += new System.EventHandler(this.confirmRangeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(100, 0);
            this.label1.MaximumSize = new System.Drawing.Size(468, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выбор диапазона осуществляется с помощью нажатия кнопки Shift и нужного дня";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(652, 606);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmRangeButton);
            this.Controls.Add(this.monthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Средняя температура за выбранный период";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button confirmRangeButton;
        private System.Windows.Forms.Label label1;
    }
}