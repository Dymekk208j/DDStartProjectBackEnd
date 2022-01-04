using AgGridApi.Models.Response;
using Dapper;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers;
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

        public async Task<ServerRowsResponse<User>> GetUsersListAsync(GetUsersListQuery query)
        {
            var response = new ServerRowsResponse<User>();

            using var conn = _dbConnection.GetConnection;
            

            var sqlQuery = _sqlHelper.GetAgGridSelectSql(query.Request);

            var parameters = new DynamicParameters();
            parameters.Add("startRow", query.Request.StartRow);
            parameters.Add("endRow", query.Request.EndRow);

            response.RowData = await conn.QueryAsync<User>(sqlQuery, parameters);

            var sqlTotal = _sqlHelper.GetAgGridTotalRowsCountFromSelectQuerySql("GetUsersListAsync", "Id" , query.Request);
            response.RowCount = await conn.QueryFirstAsync<int>(sqlTotal);

            return response;
        }
    }
}
