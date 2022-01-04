using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, ServerRowsResponse<User>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersListQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<ServerRowsResponse<User>> Handle(GetUsersListQuery query, CancellationToken cancellationToken)
        {
            return _usersRepository.GetUsersListAsync(query);
        }
    }
}
