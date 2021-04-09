using Dapper;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SqlHelper<UsersRepository> _sqlHelper;
        private readonly IDbConnection _dbConnection;

        public UsersRepository(IDbConnection dbConnection)
        {
            _sqlHelper = new SqlHelper<UsersRepository>();
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<User>> GetUsersListAsync()
        {
            using var conn = _dbConnection.GetConnection;
            var query = _sqlHelper.GetSql();

            var result = await conn.QueryAsync<User>(query);

            return result;
        }
    }
}
