using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;
using System.Collections.Generic;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetBlockUserReasonList
{
    public class GetBlockUserReasonListQuery : IRequest<List<BlockUserReason>>
    {
    }
}
