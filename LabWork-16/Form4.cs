﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LabWork_16
{
    public partial class Form4 : Form
    {
        private SqlDataAdapter _sqlAdapter;
        private DataSet _dataSet;

        public Form4(SqlDataAdapter sqlDataAdapter, DataSet dataSet)
        {
            InitializeComponent();
            _sqlAdapter = sqlDataAdapter;
            _dataSet = dataSet;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var newRow = _dataSet.Tables["WeatherData"].NewRow();

                newRow["Дата"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                newRow["Минимальная температура"] = ParseDouble(minTempBox.Text, "Минимальная температура");
                newRow["Максимальная температура"] = ParseDouble(maxTempBox.Text, "Максимальная температура");
                newRow["Средняя температура"] = ParseDouble(avgTempBox.Text, "Средняя температура");
                newRow["Скорость ветра"] = ParseInt(windSpeedBox.Text, "Ветер");
                newRow["Атмосферное давление"] = ParseDouble(pressureBox.Text, "Давление");
                newRow["Количество осадков"] = ParseInt(rainfallBox.Text, "Осадки");

                _dataSet.Tables["WeatherData"].Rows.Add(newRow);
                _sqlAdapter.Update(_dataSet, "WeatherData");

                this.Close();
            }
            catch (Exception exception)
            {
                Form1.ShowError(exception);
            }
        }
        private double ParseDouble(string text, string field)
        {
            try
            {
                double result = Convert.ToDouble(text);

                return result;
            }
            catch (FormatException)
            {
                throw new Exception($"Неверное значение поля {field}");

            }
        }

        private int ParseInt(string text, string field)
        {
            try
            {
                int result = Convert.ToInt32(text);

                return result;
            }
            catch (FormatException)
            {
                throw new Exception($"Неверное значение поля {field}");

            }
        }
    }
}
