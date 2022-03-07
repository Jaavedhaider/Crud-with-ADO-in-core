using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crud_with_ADO_in_core.Models
{
    public class DbConnection
    {
        public SqlConnection connection;
        public DbConnection()
        {
            connection = new SqlConnection(DbConfig.ConnectionStr);
        }
    }
}
