using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<User>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetUsersListQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IEnumerable<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return _usersRepository.GetUsersListAsync();
        }
    }
}
