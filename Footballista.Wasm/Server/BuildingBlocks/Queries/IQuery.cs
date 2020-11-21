using MediatR;

namespace Footballista.Wasm.Server.BuildingBlocks.Queries
{
	public interface IQuery<TResponse> : IRequest<TResponse>
	{
	}
}
