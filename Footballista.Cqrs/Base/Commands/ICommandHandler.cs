using MediatR;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Base.Commands
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
