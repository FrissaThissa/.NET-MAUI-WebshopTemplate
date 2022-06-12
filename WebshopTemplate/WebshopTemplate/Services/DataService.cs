using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Services
{
    public class DataService : IDataService
    {
        private readonly string connectionstring = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=WebshopTemplate;Integrated Security=SSPI;";
        private  SqlConnection _connection;

        private bool OpenConnection()
        {
            if (_connection == null)
                _connection = new SqlConnection(connectionstring);
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
            if (_connection.State != System.Data.ConnectionState.Open)
                return false;
            return true;
        }

        public void ExecuteNonQuery(string query)
        {
            if (!OpenConnection())
                return;

            throw new NotImplementedException();
        }

        public SqlDataReader ExecuteReader(string query)
        {
            if (!OpenConnection())
                return null;

            SqlCommand cmd = new SqlCommand(query, _connection);
            return cmd.ExecuteReader();
        }
    }
}
