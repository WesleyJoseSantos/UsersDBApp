using System.Configuration;
using System.Data.SqlClient;
using UsersDBApi.Domain.Database;
using System.Data;

namespace UsersDBApi.Infra.Database
{
    public class Connection : IConnection
    {
        public IDbConnection Get(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
