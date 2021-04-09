using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries
{
    public class GetUsersListQuery : IRequest<IEnumerable<User>>
    {
    }
}
