using MediatR;
using System.Threading.Tasks;

namespace Footballista.Cqrs.Base.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        Task<TResponse> Handle(TQuery query);
    }
}
