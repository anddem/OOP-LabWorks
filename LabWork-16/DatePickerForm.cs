using System;
using System.Windows.Forms;

namespace LabWork_16
{
    public partial class DatePickerForm : Form
    {
        private DataGridViewCell _dataGridViewCell;

        public DatePickerForm(DataGridViewCell cell)
        {
            InitializeComponent();
            _dataGridViewCell = cell;
            monthCalendar1.SelectionStart = cell.Value is not DBNull ? (DateTime)cell.Value : DateTime.Now;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            _dataGridViewCell.ReadOnly = false;
            _dataGridViewCell.Value = monthCalendar1.SelectionEnd;
            _dataGridViewCell.ReadOnly = true;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
