using AgGridApi.Models.Response;
using Dapper;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.AddBlockReasonIfNotExist;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUserDetails;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Exceptions;
using DDStartProjectBackEnd.Common.Extensions;
using DDStartProjectBackEnd.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public async Task AddBlockReasonIfNotExistAsync(AddBlockReasonIfNotExistCommand request)
        {
            using var conn = _dbConnection.GetConnection;
            var sqlQuery = _sqlHelper.GetSql();

            var parameters = new DynamicParameters();
            parameters.AddCreationBaseData(request.UserId);
            parameters.Add("Name", request.Name);

            try
            {
                var affectedRows = await conn.ExecuteAsync(sqlQuery, parameters);
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    int ErrorCode = ((SqlException)ex).Number;
                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            throw new RecordDuplicationException();
                    }
                }
                throw;
            }
        }

        public async Task<bool> BlockUserAsync(BlockUserCommand request)
        {
            using var conn = _dbConnection.GetConnection;
            var sqlQuery = _sqlHelper.GetSql();

            var parameters = new DynamicParameters();
            parameters.Add("id", request.Id);
            parameters.Add("reason", request.Reason);

            var affectedRows = await conn.ExecuteAsync(sqlQuery, parameters);

            return affectedRows > 0;
        }

        public async Task<UserDetails> GetUserDetailsAsync(GetUserDetailsQuery query)
        {
            using var conn = _dbConnection.GetConnection;
            var sqlQuery = _sqlHelper.GetSql();

            var parameters = new DynamicParameters();
            parameters.Add("id", query.Id);

            var response = await conn.QueryFirstAsync<UserDetails>(sqlQuery, parameters);

            return response;
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

            var sqlTotal = _sqlHelper.GetAgGridTotalRowsCountFromSelectQuerySql("GetUsersListAsync", "Id", query.Request);
            response.RowCount = await conn.QueryFirstAsync<int>(sqlTotal);

            return response;
        }

        public async Task<List<BlockUserReason>> GetBlockUserReasonListAsync()
        {
            using var conn = _dbConnection.GetConnection;
            var sqlQuery = _sqlHelper.GetSql();

            var sqlResponse = await conn.QueryAsync<BlockUserReason>(sqlQuery);

            return sqlResponse.AsList();
        }
    }
}
