using MediatR;

namespace Footballista.Cqrs.Base.Commands
{
    public interface ICommand : IRequest
    {
    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
