
namespace LabWork_16
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.updateView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.queryButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.queryButton2 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRow,
            this.toolStripSeparator2,
            this.updateView,
            this.toolStripSeparator1,
            this.deleteButton,
            this.toolStripSeparator3,
            this.queryButton1,
            this.toolStripSeparator4,
            this.queryButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1264, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addRow
            // 
            this.addRow.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addRow.Image = ((System.Drawing.Image)(resources.GetObject("addRow.Image")));
            this.addRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(116, 29);
            this.addRow.Text = "Добавить";
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // updateView
            // 
            this.updateView.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateView.Image = ((System.Drawing.Image)(resources.GetObject("updateView.Image")));
            this.updateView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateView.Name = "updateView";
            this.updateView.Size = new System.Drawing.Size(118, 29);
            this.updateView.Text = "Обновить";
            this.updateView.Click += new System.EventHandler(this.updateView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(102, 29);
            this.deleteButton.Text = "Удалить";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // queryButton1
            // 
            this.queryButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.queryButton1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.queryButton1.Image = ((System.Drawing.Image)(resources.GetObject("queryButton1.Image")));
            this.queryButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryButton1.Name = "queryButton1";
            this.queryButton1.Size = new System.Drawing.Size(298, 29);
            this.queryButton1.Text = "Средняя температура за период";
            this.queryButton1.Click += new System.EventHandler(this.queryButton1_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // queryButton2
            // 
            this.queryButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.queryButton2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.queryButton2.Image = ((System.Drawing.Image)(resources.GetObject("queryButton2.Image")));
            this.queryButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.queryButton2.Name = "queryButton2";
            this.queryButton2.Size = new System.Drawing.Size(331, 29);
            this.queryButton2.Text = "Тёплые и холодные дни по месяцам";
            this.queryButton2.Click += new System.EventHandler(this.queryButton2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1264, 649);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Лабораторная работа 16. БД с температурой";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton updateView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton addRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton queryButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton queryButton2;
    }
}

