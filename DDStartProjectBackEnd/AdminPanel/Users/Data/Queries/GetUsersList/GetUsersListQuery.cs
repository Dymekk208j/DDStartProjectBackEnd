using AgGridApi.Models.Response;
using DDStartProjectBackEnd.AdminPanel.Users.Models;
using DDStartProjectBackEnd.Common.Helpers.Ag_grid.Request;
using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<ServerRowsResponse<User>>
    {
        public ServerRowsRequest Request { get; }

        public GetUsersListQuery(ServerRowsRequest request)
        {
            Request = request;
        }
    }
}
