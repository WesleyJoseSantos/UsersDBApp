using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;

namespace UsersDBApi.Infra.Database
{
    public class Connection
    {
        static public DbConnection Get(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
