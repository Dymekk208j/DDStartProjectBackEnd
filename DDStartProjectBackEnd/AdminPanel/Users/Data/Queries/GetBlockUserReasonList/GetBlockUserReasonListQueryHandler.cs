using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetBlockUserReasonList
{
    public class GetBlockUserReasonListQueryHandler : IRequestHandler<GetBlockUserReasonListQuery, List<BlockUserReason>>
    {
        private readonly IUsersRepository _usersRepository;

        public GetBlockUserReasonListQueryHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<List<BlockUserReason>> Handle(GetBlockUserReasonListQuery request, CancellationToken cancellationToken)
        {
            return _usersRepository.GetBlockUserReasonListAsync();
        }
    }
}
