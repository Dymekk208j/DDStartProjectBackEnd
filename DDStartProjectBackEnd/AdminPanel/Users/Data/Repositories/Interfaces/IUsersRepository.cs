using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<ServerRowsResponse<User>> GetUsersListAsync(GetUsersListQuery query);
        Task<UserDetails> GetUserDetailsAsync(GetUserDetailsQuery query);
    }
}
