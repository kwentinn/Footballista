using System.Threading;
using System.Threading.Tasks;

namespace Footballista.Wasm.Server.BuildingBlocks.Queries
{
	public abstract class QueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
		where TQuery : IQuery<TResponse>
	{
		public abstract Task<TResponse> Handle(TQuery query);

		public Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken)
		{
			return Handle(query);
		}
	}
}
