using Footballista.BuildingBlocks.Domain.KNNs.Models;

namespace Footballista.BuildingBlocks.Domain.KNNs
{
	public interface IDistanceMeasurable<T>
	{
		Distance GetDistance(T other);
	}
}
