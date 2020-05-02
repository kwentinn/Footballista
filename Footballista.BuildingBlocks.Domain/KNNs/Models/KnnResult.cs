namespace Footballista.BuildingBlocks.Domain.KNNs.Models
{
	public class KnnResult<T>
	{
		public Position Position { get; }
		public Distance Distance { get; }
		public T Value { get; }

		public KnnResult(Position position, T value, Distance distance)
		{
			Position = position;
			Value = value;
			Distance = distance;
		}
	}
}
