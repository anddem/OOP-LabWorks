using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace LabWork_16
{
    public partial class Form3 : Form
    {
        private SqlConnection _connection;
        private DataSet _dataSet;

        public Form3(SqlConnection connection, DataSet dataSet)
        {
            InitializeComponent();
            _connection = connection;
            _dataSet = dataSet;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void confirmRangeButton_Click(object sender, EventArgs e)
        {
            FindAvgTemperature();
            FindMinMaxDays();
        }

        private void FindMinMaxDays()
        {
            var minMax = from data in _dataSet.Tables["WeatherData"]?.AsEnumerable()
                         where (DateTime)data["Дата"] >= monthCalendar1.SelectionStart && (DateTime)data["Дата"] <= monthCalendar1.SelectionEnd
                         orderby data["Средняя температура"]
                         select data;

            var min = string.Join("", minMax.Take(1).AsEnumerable()
                .Select(t => $"{t["Дата"].ToString().Substring(0, 10)} | {t["Средняя температура"]}"));
            var max = string.Join("", minMax.TakeLast(1).AsEnumerable()
                .Select(t => $"{t["Дата"].ToString().Substring(0, 10)} | {t["Средняя температура"]}"));

            var message =
                $"Период: {monthCalendar1.SelectionStart.ToShortDateString()}-{monthCalendar1.SelectionEnd.ToShortDateString()}\n" +
                $"Самый холодный день: {min}\n" +
                $"Самый тёплый день: {max}";

            MessageBox.Show(message, "Результаты запроса");
        }

        void FindAvgTemperature()
        {
            var sqlCommand =
                new SqlCommand("SELECT AVG(AvgTemperature) FROM WeatherData WHERE Date BETWEEN @start AND @end", _connection);
            sqlCommand.Parameters.Add(new SqlParameter("@start", monthCalendar1.SelectionStart));
            sqlCommand.Parameters.Add(new SqlParameter("@end", monthCalendar1.SelectionEnd));

            var result = sqlCommand.ExecuteScalar();

            var message = $"Период: {monthCalendar1.SelectionStart.ToShortDateString()}-{monthCalendar1.SelectionEnd.ToShortDateString()}\n" +
                          $"Средняя температура: ";
            message += result is DBNull ? $"{0.0}" : $"{result}";

            MessageBox.Show(message, "Результат запроса", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
