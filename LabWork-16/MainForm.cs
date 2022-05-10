using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LabWork_16
{
    public partial class MainForm : Form
    {
        private const string _SqlConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\csFIles\OOP-LabWorks\LabWork-16\Database1.mdf;Integrated Security=True"; //Строка подключения к БД
        private DataSet _dataSet = null;
        private SqlConnection _sqlConnection;
        private SqlCommandBuilder _sqlCommandBuilder = null;
        private SqlDataAdapter _sqlDataAdapter = null;

        private bool _userAddNewRow = false;

        private DatePickerForm _form2 = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(_SqlConnectionString);
            _sqlConnection.Open();

            LoadData();
        }

        #region Получение данных из базы
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

        private void updateView_Click(object sender, EventArgs e) => ReloadData();
        #endregion

        #region Добавление данных в базу
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

        private void addRow_Click(object sender, EventArgs e) => new AddRowForm(_sqlDataAdapter, _dataSet, ReloadData).Show();

        private void AddRow(DataGridViewRow row)
        {
            try
            {
                var newRow = _dataSet.Tables["WeatherData"]?.NewRow();
                var lastRow = dataGridView1.Rows[row.Index];

                FillDataSetRow(newRow, lastRow);

                _dataSet.Tables["WeatherData"]?.Rows.Add(newRow);
                _dataSet.Tables["WeatherData"]?.Rows.RemoveAt(_dataSet.Tables["WeatherData"].Rows.Count - 1);
                dataGridView1.Rows.RemoveAt(dataGridView1.RowCount - 2);
                dataGridView1.Rows[row.Index - 1].Cells[^1].Value = "Удалить";

                _sqlDataAdapter.Update(_dataSet, "WeatherData");

                _userAddNewRow = false;
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }
        #endregion

        /// <summary>
        /// Удаление строки из DataSet и базы данных
        /// </summary>
        /// <param name="row">Удаляемая строка</param>
        private void DeleteRow(DataGridViewRow row)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление строки",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            
            dataGridView1.Rows.RemoveAt(row.Index);
            _dataSet.Tables["WeatherData"]?.Rows[row.Index].Delete();

            _sqlDataAdapter.Update(_dataSet, "WeatherData");
            
        }

        /// <summary>
        /// Заполнение строки DataRow информацией из строки в DataGrid
        /// </summary>
        /// <param name="editableRow">Обновляемая строка</param>
        /// <param name="sourceRow">Строка-источник</param>
        private void FillDataSetRow(DataRow editableRow, DataGridViewRow sourceRow)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                switch (column.Name)
                {
                    case "Действие":
                        continue;
                    case "Дата":
                        editableRow["Дата"] = sourceRow.Cells["Дата"].Value is not System.DBNull
                            ? sourceRow.Cells["Дата"].Value
                            : DateTime.Now.Date;
                        break;
                    default:
                        editableRow[column.Name] = sourceRow.Cells[column.Name].Value;
                        break;
                }
            }
        }

        /// <summary>
        /// Обновление данных в активной строке
        /// </summary>
        /// <param name="dataGridEditRow">Обновляемая строка</param>
        private void UpdateRow(DataGridViewRow dataGridEditRow)
        
        {
            try
            {
                var dataSetEditRow = _dataSet.Tables["WeatherData"]?.Rows[dataGridEditRow.Index];

                FillDataSetRow(dataSetEditRow, dataGridEditRow);

                _sqlDataAdapter.Update(_dataSet, "WeatherData");
                dataGridEditRow.Cells[^1].Value = "Удалить";
            }
            catch (Exception e)
            {
                ShowError(e);
            }
        }

        /// <summary>
        /// Выбор действия относительно указанного в ячейке
        /// </summary>
        /// <param name="e"></param>
        private void SelectCellAction(DataGridViewCellEventArgs e)
        {
            var action = dataGridView1[e.ColumnIndex, e.RowIndex].FormattedValue;
            var row = dataGridView1.Rows[e.RowIndex];

            switch (action as string)
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

        /// <summary>
        /// Показ календаря для выбора значения при редактировании строки с датой
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ShowDatePicker(int rowIndex)
        {
            try
            {
                var dateCell = dataGridView1[0, rowIndex];
                _form2?.Close();
                _form2 = new DatePickerForm(dateCell);
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
                if (e.ColumnIndex == 7) SelectCellAction(e);
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) ShowDatePicker(e.RowIndex);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_userAddNewRow) return;

            var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            var editRow = dataGridView1.Rows[rowIndex];

            dataGridView1[7, rowIndex] = new DataGridViewLinkCell();
            editRow.Cells["Действие"].Value = "Обновить";
        }

        private void queryButton1_Click(object sender, EventArgs e) => new AnalyzeDateRangeForm(_sqlConnection, _dataSet).Show();
        
        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            try
            {
                _dataSet.Tables["WeatherData"]?.Clear();

                var sql = "SELECT Date as [Дата]," +
                        "MaxTemperature as [Максимальная температура], " +
                        "MinTemperature as [Минимальная температура], " +
                        "AvgTemperature as [Средняя температура], " +
                        "AtmPressure as [Атмосферное давление], " +
                        "WindSpeed as [Скорость ветра], " +
                        "Rainfall as [Количество осадков], " +
                        $"'Удалить' as [Действие] FROM WeatherData WHERE Date = '{dateTimePicker1.Value:yyyy-MM-dd}'";

                var adapter = new SqlDataAdapter(sql, _sqlConnection);

                adapter.Fill(_dataSet, "WeatherData");

                if (dataGridView1.RowCount == 1)
                    MessageBox.Show("По запросу не найдено ни одной записи", "Поиск по дате", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                    dataGridViewRow.Cells[^1] = new DataGridViewLinkCell();
            }
            catch (Exception exp)
            {
                ShowError(exp);
            }
        }

        /// <summary>
        /// Обработка неверного ввода в ячейки DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            var message = "";
            if ((e.Context & DataGridViewDataErrorContexts.CurrentCellChange) != 0)
                message += "Ошибка изменения данных\n";
            if ((e.Context & DataGridViewDataErrorContexts.Commit) != 0)
                message += "Не удалось сохранить значение в активной ячейке\n";
            if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                message += $"В активной ячейке должно быть значение {dataGridView1.CurrentCell.ValueType}\n";
            if ((e.Context & DataGridViewDataErrorContexts.LeaveControl) != 0)
                message += "Очистите активную ячейку или измените значение";

            ShowError(new Exception(message));
        }

        /// <summary>
        /// Вывод сообщений об ошибке
        /// </summary>
        /// <param name="e"></param>
        public static void ShowError(Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
