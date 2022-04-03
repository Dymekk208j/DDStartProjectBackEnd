using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.AddBlockReasonIfNotExist
{
    public class AddBlockReasonIfNotExistCommandHandler : IRequestHandler<AddBlockReasonIfNotExistCommand, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public AddBlockReasonIfNotExistCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public async Task<Unit> Handle(AddBlockReasonIfNotExistCommand request, CancellationToken cancellationToken)
        {
            await _usersRepository.AddBlockReasonIfNotExistAsync(request);

            return Unit.Value;
        }
    }
}
