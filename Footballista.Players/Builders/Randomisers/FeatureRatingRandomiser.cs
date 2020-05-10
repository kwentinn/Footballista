using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using System;

namespace Footballista.Players.Builders.Randomisers
{

	public class FeatureRatingRandomiser : GenericRandomiser, IRandomiser<FeatureRating>
	{
		public FeatureRating Randomise() => Randomise(FeatureRating.Min, FeatureRating.Max);

		public FeatureRating Randomise(FeatureRating min, FeatureRating max)
		{
			int minValue = Convert.ToInt32(Math.Round(min.Rating * 100d, 0));
			int maxValue = Convert.ToInt32(Math.Round(max.Rating * 100d, 0));

			double value = Convert.ToDouble(Random.Next(minValue, maxValue)) / 100d;

			return new FeatureRating(value);
		}

		public FeatureRating Randomise(Range<FeatureRating> range)
		{
			return Randomise(range.Min, range.Max);
		}
	}
}
