using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using DDStartProjectBackEnd.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DDStartProjectBackEnd.AdminPanel.Users.Data.Commands.BlockUserCommand
{
    public class BlockUserCommandHandler : IRequestHandler<BlockUserCommand, Unit>
    {
        private readonly IUsersRepository _usersRepository;

        public BlockUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Unit> Handle(BlockUserCommand request, CancellationToken cancellationToken)
        {
            var success = await _usersRepository.BlockUserAsync(request);

            if (!success)
                throw new RecordNotFoundException();

            return Unit.Value;
        }
    }
}
