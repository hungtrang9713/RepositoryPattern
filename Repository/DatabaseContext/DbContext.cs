using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DatabaseContext
{
    class DbContext : IDisposable
    {
        private string _connectionString;
        private SqlConnection _connection;

        public DbContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
        }
        /// <summary>
        /// Trả về connection đang mở
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }


        /// <summary>
        /// Giải phóng connection
        /// </summary>
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
