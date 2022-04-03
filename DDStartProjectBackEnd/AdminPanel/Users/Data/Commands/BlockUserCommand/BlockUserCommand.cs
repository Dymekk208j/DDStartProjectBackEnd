using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand
{
    public class BlockUserCommand : IRequest
    {
        public string Id { get; set; }
        public string Reason { get; set; }
    }
}
