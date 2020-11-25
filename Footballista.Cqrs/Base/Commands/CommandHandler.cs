using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Base.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public async Task<Unit> Handle(TCommand command, CancellationToken cancellationToken)
        {
            await HandleAsync(command);
            return Unit.Value;
        }

        public abstract Task HandleAsync(TCommand command);
    }
}
