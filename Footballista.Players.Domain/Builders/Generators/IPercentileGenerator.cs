using Footballista.BuildingBlocks.Domain.Percentiles;
using Footballista.Players.Builders.Randomisers;
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
		private readonly IRandomiser<int> _intRandomiser;

		public PercentileGenerator(IRandomiser<int> intRandomiser)
		{
			this._intRandomiser = intRandomiser;
		}
		public Percentile Generate()
		{
			var randomIntValue = _intRandomiser.Randomise
			(
				Percentile.Min.Value, 
				Percentile.Max.Value
			);
			return new Percentile(randomIntValue);
		}

		public Percentile Generate(Percentile min, Percentile max)
			=> new Percentile(_intRandomiser.Randomise(min.Value, max.Value));
	}
}
