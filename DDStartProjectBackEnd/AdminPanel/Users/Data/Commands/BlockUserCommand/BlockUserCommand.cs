using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand
{
    public class BlockUserCommand : IRequest
    {
        public string Id { get; set; }

        public string Reason { get; set; }

        public BlockUserCommand(string id, string reason)
        {
            Id = id;
            Reason = reason;
        }
    }
}
