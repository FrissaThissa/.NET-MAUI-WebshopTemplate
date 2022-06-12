using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace WebshopTemplate.Services
{
    public interface IDataService
    {
        public void ExecuteNonQuery(string query);
        public SqlDataReader ExecuteReader(string query);
    }
}
