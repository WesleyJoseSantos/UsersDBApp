using System.Data;

namespace UsersDBApi.Domain.Database
{
    public interface IConnection
    {
        IDbConnection Get(string name);
    }
}
