using MediatR;
using System.Threading.Tasks;

namespace Footballista.Cqrs.BuildingBlocks.Commands
{
	public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
	{
		Task HandleAsync(TCommand command);
	}
}
