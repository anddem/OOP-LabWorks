
namespace LabWork_16
{
    partial class AddRowForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.minTempBox = new System.Windows.Forms.TextBox();
            this.maxTempBox = new System.Windows.Forms.TextBox();
            this.avgTempBox = new System.Windows.Forms.TextBox();
            this.windSpeedBox = new System.Windows.Forms.TextBox();
            this.pressureBox = new System.Windows.Forms.TextBox();
            this.rainfallBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(312, 32);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // minTempBox
            // 
            this.minTempBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minTempBox.Location = new System.Drawing.Point(12, 50);
            this.minTempBox.Name = "minTempBox";
            this.minTempBox.PlaceholderText = "min t";
            this.minTempBox.Size = new System.Drawing.Size(100, 32);
            this.minTempBox.TabIndex = 1;
            // 
            // maxTempBox
            // 
            this.maxTempBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxTempBox.Location = new System.Drawing.Point(118, 50);
            this.maxTempBox.Name = "maxTempBox";
            this.maxTempBox.PlaceholderText = "max t";
            this.maxTempBox.Size = new System.Drawing.Size(100, 32);
            this.maxTempBox.TabIndex = 2;
            // 
            // avgTempBox
            // 
            this.avgTempBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.avgTempBox.Location = new System.Drawing.Point(224, 50);
            this.avgTempBox.Name = "avgTempBox";
            this.avgTempBox.PlaceholderText = "avg t";
            this.avgTempBox.Size = new System.Drawing.Size(100, 32);
            this.avgTempBox.TabIndex = 3;
            // 
            // windSpeedBox
            // 
            this.windSpeedBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.windSpeedBox.Location = new System.Drawing.Point(12, 88);
            this.windSpeedBox.Name = "windSpeedBox";
            this.windSpeedBox.PlaceholderText = "Ветер";
            this.windSpeedBox.Size = new System.Drawing.Size(100, 32);
            this.windSpeedBox.TabIndex = 4;
            // 
            // pressureBox
            // 
            this.pressureBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pressureBox.Location = new System.Drawing.Point(118, 88);
            this.pressureBox.Name = "pressureBox";
            this.pressureBox.PlaceholderText = "Давление";
            this.pressureBox.Size = new System.Drawing.Size(100, 32);
            this.pressureBox.TabIndex = 5;
            // 
            // rainfallBox
            // 
            this.rainfallBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rainfallBox.Location = new System.Drawing.Point(224, 88);
            this.rainfallBox.Name = "rainfallBox";
            this.rainfallBox.PlaceholderText = "Осадки";
            this.rainfallBox.Size = new System.Drawing.Size(100, 32);
            this.rainfallBox.TabIndex = 6;
            // 
            // acceptButton
            // 
            this.acceptButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptButton.Location = new System.Drawing.Point(12, 126);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(312, 43);
            this.acceptButton.TabIndex = 7;
            this.acceptButton.Text = "Создать запись";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // AddRowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 182);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.rainfallBox);
            this.Controls.Add(this.pressureBox);
            this.Controls.Add(this.windSpeedBox);
            this.Controls.Add(this.avgTempBox);
            this.Controls.Add(this.maxTempBox);
            this.Controls.Add(this.minTempBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AddRowForm";
            this.Text = "Добавление записи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox minTempBox;
        private System.Windows.Forms.TextBox maxTempBox;
        private System.Windows.Forms.TextBox avgTempBox;
        private System.Windows.Forms.TextBox windSpeedBox;
        private System.Windows.Forms.TextBox pressureBox;
        private System.Windows.Forms.TextBox rainfallBox;
        private System.Windows.Forms.Button acceptButton;
    }
}