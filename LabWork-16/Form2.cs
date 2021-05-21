﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabWork_16
{
    public partial class Form2 : Form
    {
        private DataGridViewCell _dataGridViewCell;

        public Form2(DataGridViewCell cell)
        {
            InitializeComponent();
            _dataGridViewCell = cell;
            monthCalendar1.SelectionStart = cell.Value is not System.DBNull ? (DateTime)cell.Value : DateTime.Now;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            _dataGridViewCell.ReadOnly = false;
            _dataGridViewCell.Value = monthCalendar1.SelectionEnd;
            _dataGridViewCell.ReadOnly = true;
            Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            _dataGridViewCell.Value = e.End;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
