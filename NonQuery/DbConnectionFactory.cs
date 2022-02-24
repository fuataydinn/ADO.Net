using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonQuery
{
    // Bağlantı fabrikası
    public static class DbConnectionFactory
    {
        private const string ConnectionString = "Server=.; Database=Northwind; Integrated Security=true;";

        public static SqlConnection Create()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
