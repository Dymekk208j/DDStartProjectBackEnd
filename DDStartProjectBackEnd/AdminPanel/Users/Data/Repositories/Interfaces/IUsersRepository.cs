using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.AddBlockReasonIfNotExist;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUserDetails;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<ServerRowsResponse<User>> GetUsersListAsync(GetUsersListQuery query);
        Task<UserDetails> GetUserDetailsAsync(GetUserDetailsQuery query);
        Task<bool> BlockUserAsync(BlockUserCommand request);
        Task AddBlockReasonIfNotExistAsync(AddBlockReasonIfNotExistCommand request);
        Task<List<BlockUserReason>> GetBlockUserReasonListAsync();
    }
}
