using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DDStartProjectBackEnd.Common.Helpers
{
    public class DbConnection : IDbConnection
    {
        private readonly IConfiguration Configuration;

        public DbConnection(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlConnection GetConnection
        {
            get
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            }
        }
    }
}
