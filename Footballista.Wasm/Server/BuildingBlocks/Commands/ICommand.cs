using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.BuildingBlocks.Commands
{
	public interface ICommand : IRequest
	{
	}

	public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
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
