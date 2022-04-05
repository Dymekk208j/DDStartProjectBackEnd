using DDStartProjectBackEnd.AdminPanel.Users.Models;
using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Queries.GetUserDetails
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
