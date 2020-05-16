using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using System;

namespace Footballista.Players.Builders.Randomisers
{

	public class FeatureRatingRandomiser : GenericRandomiser, IRandomiser<Rating>
	{
		public Rating Randomise() => Randomise(Rating.Min, Rating.Max);

		public Rating Randomise(Rating min, Rating max)
		{
			int minValue = Convert.ToInt32(Math.Round(min.Value * 100d, 0));
			int maxValue = Convert.ToInt32(Math.Round(max.Value * 100d, 0));

			double value = Convert.ToDouble(Random.Next(minValue, maxValue)) / 100d;

			return new Rating(value);
		}

		public Rating Randomise(Range<Rating> range)
		{
			return Randomise(range.Lower, range.Upper);
		}
	}
}
