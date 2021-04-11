using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, BasicDataResponse<User>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersListQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<BasicDataResponse<User>> Handle(GetUsersListQuery query, CancellationToken cancellationToken)
        {
            return _usersRepository.GetUsersListAsync(query);
        }
    }
}
