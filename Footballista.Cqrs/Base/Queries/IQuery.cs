using MediatR;

namespace Footballista.Cqrs.Base.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
