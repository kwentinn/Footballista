namespace Footballista.BuildingBlocks.Domain.KNNs.Models
{
	public record KnnResult<T>(Position Position, T Value, Distance Distance);
}
