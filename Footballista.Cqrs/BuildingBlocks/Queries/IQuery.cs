using MediatR;

namespace Footballista.Cqrs.BuildingBlocks.Queries
{
	public interface IQuery<TResponse> : IRequest<TResponse>
	{
	}
}
