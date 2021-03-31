using System.Data.SqlClient;

namespace DDStartProjectBackEnd.Auth.Data
{
    public interface IDbConnection
    {
        public SqlConnection GetConnection { get; }
    }
}
