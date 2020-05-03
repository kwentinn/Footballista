using Footballista.BuildingBlocks.Domain.Percentiles;
using System;

namespace Footballista.Players.Builders.Generators
{
	public interface IPercentileGenerator
	{
		Percentile Generate();
		Percentile Generate(Percentile min, Percentile max);
	}
	public class PercentileGenerator : IPercentileGenerator
	{
		private static Random Random = new Random();
		public Percentile Generate()
		{
			var randomIntValue = Random.Next
			(
				Percentile.Min.Value, 
				Percentile.Max.Value
			);
			return new Percentile(randomIntValue);
		}

		public Percentile Generate(Percentile min, Percentile max)
			=> new Percentile(Random.Next(min.Value, max.Value));
	}
}
