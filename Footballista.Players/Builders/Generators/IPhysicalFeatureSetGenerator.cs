using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Positions;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface IPhysicalFeatureSetGenerator
	{
		PhysicalFeatureSet Generate(PlayerPosition position, BodyMassIndex bmi, Country country);
	}

	public class PhysicalFeatureSetGenerator : IPhysicalFeatureSetGenerator
	{
		private readonly IRandomiser<FeatureRating> _randomiser;

		private static readonly FeatureRating _minRating = new FeatureRating(.2);
		private static readonly FeatureRating _maxRating = new FeatureRating(.55);

		public PhysicalFeatureSetGenerator(IRandomiser<FeatureRating> randomiser)
		{
			_randomiser = randomiser;
		}

		public PhysicalFeatureSet Generate(PlayerPosition position, BodyMassIndex bmi, Country country)
		{
			PhysicalFeatureSet set = PhysicalFeatureSet.GetFeatureSet(position.PositionCategory);

			Parallel.ForEach(set.PhysicalFeatures, feature =>
			{
				FeatureRating rating;

				if (feature.Equals(PhysicalFeature.Morale))
				{
					rating = _randomiser.Randomise();
				}
				else
				{
					rating = _randomiser.Randomise(_minRating, _maxRating);
				}

				feature.ChangeRating(rating);
			});

			return set;
		}
	}
}
