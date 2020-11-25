using MediatR;

namespace Footballista.Cqrs.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
