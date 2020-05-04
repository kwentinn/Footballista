using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;

namespace Footballista.Players.Builders.Generators
{
	public interface IPhysicalFeatureSetGenerator
	{
		PhysicalFeatureSet Generate();
	}
	public class PhysicalFeatureSetGenerator : IPhysicalFeatureSetGenerator
	{
		private readonly IRandomiser<FeatureRating> _randomiser;

		public PhysicalFeatureSetGenerator(IRandomiser<FeatureRating> randomiser)
		{
			_randomiser = randomiser;
		}

		public PhysicalFeatureSet Generate()
		{
			var set = PhysicalFeatureSet.ForwardFeatureSet;
			foreach (PhysicalFeature feature in set.PhysicalFeatures)
			{
				var minRating = new FeatureRating(.25);
				var maxRating = new FeatureRating(.65);
				var rating = _randomiser.Randomise(minRating, maxRating);

				feature.ChangeValue(rating);
			}
			return set;
		}
	}
}
