using DDStartProjectBackEnd.AdminPanel.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersListAsync();
    }
}
