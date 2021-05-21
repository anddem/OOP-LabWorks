using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;

namespace LabWork_16
{
    class DatabaseAPI
    {
        private SqlConnection _dbConnection;
        private static DatabaseAPI _dbApi { get; set; } = default;

        public static DatabaseAPI GetApiClient(string connectionString)
        {
            if (_dbApi is null) _dbApi = new DatabaseAPI(connectionString);
            return _dbApi;
        }

        private DatabaseAPI(string connectionString) => _dbConnection = new SqlConnection(connectionString);

        public DataSet GetTable(string tableName, int skip = 0, int limit = 50)
        {
            _dbConnection.Open();
            var sqlQuery = new SqlCommand($"SELECT * FROM {tableName} SKIP {skip} LIMIT {limit}");
            var adapter = new SqlDataAdapter("SELECT * FROM WeatherData", _dbConnection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            _dbConnection.Close();
            
            return dataSet;
        }

        public DataSet Query(string query)
        {
            _dbConnection.Open();
            var adapter = new SqlDataAdapter(query, _dbConnection);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            _dbConnection.Close();

            return dataSet;
        }
    }
}
