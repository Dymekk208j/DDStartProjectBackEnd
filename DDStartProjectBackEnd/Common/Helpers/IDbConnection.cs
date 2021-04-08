using System.Data.SqlClient;

namespace DDStartProjectBackEnd.Common.Helpers
{
    public interface IDbConnection
    {
        public SqlConnection GetConnection { get; }
    }
}
