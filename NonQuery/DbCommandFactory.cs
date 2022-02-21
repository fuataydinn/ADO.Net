using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonQuery
{
   public static class DbCommandFactory
    {
        public static SqlCommand Create(SqlConnection connection)
        {
            return new SqlCommand()
            {
                Connection = connection
            };
        }
    }
}
