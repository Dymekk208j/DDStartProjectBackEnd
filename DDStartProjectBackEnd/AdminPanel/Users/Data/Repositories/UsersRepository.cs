using Dapper;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid;
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

        public async Task<BasicDataResponse<User>> GetUsersListAsync(GetUsersListQuery query)
        {
            var response = new BasicDataResponse<User>();

            using var conn = _dbConnection.GetConnection;
            var sqlQuery = _sqlHelper.GetSql();
            var parameters = new DynamicParameters();
            parameters.Add("startRow", query.StartRow);
            parameters.Add("endRow", query.EndRow);

            response.RowData = await conn.QueryAsync<User>(sqlQuery, parameters);
            response.TotalRows = await conn.QueryFirstAsync<int>(_sqlHelper.GetSql("GetUsersTotals"));

            return response;
        }
    }
}
