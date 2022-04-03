using MediatR;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.AddBlockReasonIfNotExist
{
    public class AddBlockReasonIfNotExistCommand : IRequest
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public AddBlockReasonIfNotExistCommand(string userId, string name)
        {
            Name = name;
            UserId = userId;
        }
    }
}
