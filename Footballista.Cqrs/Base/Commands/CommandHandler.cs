using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Base.Commands
{
    /// <summary>
    /// Handles commands without any result.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public async Task<Unit> Handle(TCommand command, CancellationToken cancellationToken)
        {
            await HandleAsync(command);
            return Unit.Value;
        }

        public abstract Task HandleAsync(TCommand command);
    }

    /// <summary>
    /// Handles commands with result.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        public async Task<TResult> Handle(TCommand command, CancellationToken cancellationToken)
        {
            return await HandleAsync(command);
        }
        public abstract Task<TResult> HandleAsync(TCommand command);
    }
}
