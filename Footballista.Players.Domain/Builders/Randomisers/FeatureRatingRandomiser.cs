using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;
using System;

namespace Footballista.Players.Builders.Randomisers
{

	public class FeatureRatingRandomiser : IRandomiser<Rating>
	{
		private readonly IRandomiser<int> _intRandomiser;

		public FeatureRatingRandomiser(IRandomiser<int> intRandomiser)
		{
			_intRandomiser = intRandomiser;
		}
		
		public Rating Randomise() => Randomise(Rating.Min, Rating.Max);

		public Rating Randomise(Rating min, Rating max)
		{
			int minValue = Convert.ToInt32(Math.Round(min.Value * 100d, 0));
			int maxValue = Convert.ToInt32(Math.Round(max.Value * 100d, 0));

			int rnd = _intRandomiser.Randomise(minValue, maxValue);
			double value = Convert.ToDouble(rnd) / 100d;

			return new Rating(value);
		}

		public Rating Randomise(Range<Rating> range)
		{
			return Randomise(range.Lower, range.Upper);
		}
	}
}
