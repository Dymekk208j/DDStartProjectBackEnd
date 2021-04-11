using DDStartProjectBackEnd.AdminPanel.Users.Data.Queries;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<BasicDataResponse<User>> GetUsersListAsync(GetUsersListQuery query);
    }
}
