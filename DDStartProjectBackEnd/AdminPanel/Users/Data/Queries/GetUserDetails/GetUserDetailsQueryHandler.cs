using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetails>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUserDetailsQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        Task<UserDetails> IRequestHandler<GetUserDetailsQuery, UserDetails>.Handle(GetUserDetailsQuery query, CancellationToken cancellationToken)
        {
            return _usersRepository.GetUserDetailsAsync(query);
        }
    }
}
