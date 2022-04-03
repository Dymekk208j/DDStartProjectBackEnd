using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUsersList
{
    public class GetUserDetailsQuery : IRequest<UserDetails>
    {
        public string Id { get; }

        public GetUserDetailsQuery(string id)
        {
            Id = id;
        }
    }
}
