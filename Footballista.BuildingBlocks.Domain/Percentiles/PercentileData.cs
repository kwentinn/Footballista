namespace Footballista.BuildingBlocks.Domain.Percentiles
{
	public class PercentileData<T>
	{
		public Percentile Percentile { get; }
		public T Object { get; }

		public PercentileData(Percentile percentile, T @object)
		{
			Percentile = percentile;
			Object = @object;
		}
	}
}
