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
    public partial class Form1 : Form
    {
        private string _sqlConnectionString =
            @"Data Source=ANDREYLENOVO;Initial Catalog=LabWork;Integrated Security=True";
        private DatabaseAPI _api = null;
        private DataSet _dataSet = null;
        private SqlConnection _sqlConnection;
        private SqlCommandBuilder _sqlCommandBuilder = null;
        private SqlDataAdapter _sqlDataAdapter = null;
        private bool _userAddNewRow = false;
        private Form2 _form2 = null;
        private Form3 _form3 = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                _sqlDataAdapter = new SqlDataAdapter(@"SELECT Date as [Дата],
                                                    MaxTemperature as [Максимальная температура],
                                                    MinTemperature as [Минимальная температура],
                                                    AvgTemperature as [Средняя температура],
                                                    AtmPressure as [Атмосферное давление],
                                                    WindSpeed as [Скорость ветра],
                                                    Rainfall as [Количество осадков],
                                                    'Удалить' as [Действие] FROM WeatherData", _sqlConnection);

                _sqlCommandBuilder = new SqlCommandBuilder(_sqlDataAdapter);

                _sqlCommandBuilder.GetInsertCommand();
                _sqlCommandBuilder.GetUpdateCommand();
                _sqlCommandBuilder.GetDeleteCommand();

                _dataSet = new DataSet();

                _sqlDataAdapter.Fill(_dataSet, "WeatherData");

                dataGridView1.DataSource = _dataSet.Tables["WeatherData"];
                dataGridView1.Columns["Дата"].DefaultCellStyle.Format = "dd.MM.yyyy";

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[7, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        private static void ShowError(Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(_sqlConnectionString);
            _sqlConnection.Open();

            LoadData();
        }

        private void updateView_Click(object sender, EventArgs e) => ReloadData();

        private void ReloadData()
        {
            try
            {
                _dataSet.Tables["WeatherData"].Clear();

                _sqlDataAdapter.Fill(_dataSet, "WeatherData");

                dataGridView1.DataSource = _dataSet.Tables["WeatherData"];

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[7, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (_userAddNewRow) return;
                _userAddNewRow = true;
                int lastRow = dataGridView1.RowCount - 2;
                var newRow = dataGridView1.Rows[lastRow];
                dataGridView1[7, lastRow] = new DataGridViewLinkCell();
                newRow.Cells["Действие"].Value = "Добавить";
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }

        }

        private void addRow_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteRow(DataGridViewRow row)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление строки", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int rowIndex = row.Index;
                dataGridView1.Rows.RemoveAt(rowIndex); // Корректировка из-за строки с заголовками
                _dataSet.Tables["WeatherData"].Rows[rowIndex].Delete();

                _sqlDataAdapter.Update(_dataSet, "WeatherData");
            }
        }

        private void AddRow(DataGridViewRow row)
        {
            try
            {
                int newRowIndex = row.Index;
                var newRow = _dataSet.Tables["WeatherData"].NewRow();
                var lastRow = dataGridView1.Rows[newRowIndex];

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name == "Действие") continue;
                    if (column.Name == "Дата")
                        newRow["Дата"] = lastRow.Cells["Дата"].Value is not System.DBNull
                            ? lastRow.Cells["Дата"].Value
                            : DateTime.Now.Date;
                    else
                        newRow[column.Name] = lastRow.Cells[column.Name].Value;
                }

                _dataSet.Tables["WeatherData"].Rows.Add(newRow);
                _dataSet.Tables["WeatherData"].Rows.RemoveAt(_dataSet.Tables["WeatherData"].Rows.Count - 1);
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 2);
                dataGridView1.Rows[newRowIndex-1].Cells[^1].Value = "Удалить";

                _sqlDataAdapter.Update(_dataSet, "WeatherData");

                _userAddNewRow = false;
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void UpdateRow(DataGridViewRow dataGridEditRow)
        {
            try
            {
                var dataSetEditRow = _dataSet.Tables["WeatherData"].Rows[dataGridEditRow.Index];
                
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Name == "Действие") continue;
                    if (column.Name == "Дата")
                        dataSetEditRow["Дата"] = dataGridEditRow.Cells["Дата"].Value is not System.DBNull
                            ? dataGridEditRow.Cells["Дата"].Value
                            : DateTime.Now.Date;
                    else
                        dataSetEditRow[column.Name] = dataGridEditRow.Cells[column.Name].Value;
                }

                _sqlDataAdapter.Update(_dataSet, "WeatherData");
                dataGridEditRow.Cells[^1].Value = "Удалить";
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        private void SelectCellAction(DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            var row = dataGridView1.Rows[cell.RowIndex];
            switch (cell.FormattedValue)
            {
                case "Удалить":
                    DeleteRow(row);
                    break;
                case "Добавить":
                    AddRow(row);
                    break;
                case "Обновить":
                    UpdateRow(row);
                    break;
            }
            ReloadData();
        }

        private void ShowDatePicker(int rowIndex)
        {
            try
            {
                var dateCell = dataGridView1[0, rowIndex];
                _form2?.Close();
                _form2 = new Form2(dateCell);
                _form2.Show();
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 7:
                        SelectCellAction(e);
                        break;
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                ShowDatePicker(e.RowIndex);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_userAddNewRow) return;

            var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            var editRow = dataGridView1.Rows[rowIndex];

            dataGridView1[7, rowIndex] = new DataGridViewLinkCell();
            editRow.Cells["Действие"].Value = "Обновить";
        }

        private void queryButton1_Click(object sender, EventArgs e)
        {
            if (_form3 is null) _form3 = new Form3(_sqlConnection, _dataSet);
            _form3.Show();
        }

        private void queryButton2_Click(object sender, EventArgs e)
        {
            var groups = (from data in _dataSet.Tables["WeatherData"].AsEnumerable()
                group data by data["Дата"].ToString().Substring(3, 7));
            var mins = (from g in groups
                select g);

            var msg = string.Join(", ", mins);
            MessageBox.Show(msg, "asd");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _dataSet.Tables["WeatherData"].Clear();

                var sql = "SELECT Date as [Дата]," +
                        "MaxTemperature as [Максимальная температура], " +
                        "MinTemperature as [Минимальная температура], " +
                        "AvgTemperature as [Средняя температура], " +
                        "AtmPressure as [Атмосферное давление], " +
                        "WindSpeed as [Скорость ветра], " +
                        "Rainfall as [Количество осадков], " +
                        $"'Удалить' as [Действие] FROM WeatherData WHERE Date = {dateTimePicker1.Value.Date}";

                var adapter = new SqlDataAdapter(sql, _sqlConnection);

                adapter.Fill(_dataSet, "WeatherData");

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[7, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception exp)
            {
                ShowError(exp);
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            try
            {
                _dataSet.Tables["WeatherData"].Clear();

                var sql = "SELECT Date as [Дата]," +
                        "MaxTemperature as [Максимальная температура], " +
                        "MinTemperature as [Минимальная температура], " +
                        "AvgTemperature as [Средняя температура], " +
                        "AtmPressure as [Атмосферное давление], " +
                        "WindSpeed as [Скорость ветра], " +
                        "Rainfall as [Количество осадков], " +
                        $"'Удалить' as [Действие] FROM WeatherData WHERE Date = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}'";

                var adapter = new SqlDataAdapter(sql, _sqlConnection);

                adapter.Fill(_dataSet, "WeatherData");

                if (dataGridView1.RowCount == 1) MessageBox.Show("По запросу не найдено ни одной записи", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1[7, i] = new DataGridViewLinkCell();
                }
            }
            catch (Exception exp)
            {
                ShowError(exp);
            }
        }
    }
}
