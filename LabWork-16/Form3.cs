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

namespace LabWork_16
{
    public partial class Form3 : Form
    {
        private SqlConnection _connection;

        public Form3(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void confirmRangeButton_Click(object sender, EventArgs e)
        {
            var sqlComamnd =
                new SqlCommand("SELECT AVG(AvgTemperature) FROM WeatherData WHERE Date BETWEEN @start AND @end", _connection);
            sqlComamnd.Parameters.Add(new SqlParameter("@start", monthCalendar1.SelectionStart));
            sqlComamnd.Parameters.Add(new SqlParameter("@end", monthCalendar1.SelectionEnd));

            var result = sqlComamnd.ExecuteScalar();

            var message = $"Период: {monthCalendar1.SelectionStart.ToShortDateString()}-{monthCalendar1.SelectionEnd.ToShortDateString()}\n" +
                          $"Средняя температура: ";
            message += result is DBNull ? $"{0.0}" : $"{result}";

            MessageBox.Show(message, "Результат запроса", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
