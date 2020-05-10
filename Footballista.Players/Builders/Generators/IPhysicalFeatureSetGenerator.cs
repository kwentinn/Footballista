using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Physique;
using Footballista.Players.Positions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Footballista.Players.Builders.Generators
{
	public interface IPhysicalFeatureSetGenerator
	{
		PhysicalFeatureSet Generate(PlayerPosition position, BodyMassIndex bmi, Country country, PersonAge playerAge);
	}

	public class PhysicalFeatureSetGenerator : IPhysicalFeatureSetGenerator
	{
		private readonly IRandomiser<FeatureRating> _randomiser;

		private static Range<FeatureRating> _youngPlayerFeatureRatingRange 
			=> new Range<FeatureRating>(new FeatureRating(.2), new FeatureRating(.55));

		private static Range<FeatureRating> _standardPlayerFeatureRatingRange 
			=> new Range<FeatureRating>(new FeatureRating(.35), new FeatureRating(.85));
		private static Range<FeatureRating> _specialPlayerFeatureRatingRange 
			=> new Range<FeatureRating>(new FeatureRating(.5), new FeatureRating(.99));

		public PhysicalFeatureSetGenerator(IRandomiser<FeatureRating> randomiser)
		{
			_randomiser = randomiser;
		}

		public PhysicalFeatureSet Generate(PlayerPosition position, BodyMassIndex bmi, Country country, PersonAge playerAge)
		{
			PhysicalFeatureSet set = PhysicalFeatureSet.GetFeatureSet(position.PositionCategory);

			Parallel.ForEach(set.PhysicalFeatures, feature =>
			{
				FeatureRating rating;

				if (feature == PhysicalFeature.Morale)
				{
					rating = _randomiser.Randomise();
				}
				else
				{
					rating = _randomiser.Randomise(_youngPlayerFeatureRatingRange);
				}

				feature.ChangeRating(rating);
			});

			return set;
		}
	}

	//public class BodyMassIndexFeatureSetGenerator
	//{
	//	public ReadOnlyCollection<PhysicalFeatureSet> Generate(BodyMassIndex bmi, PersonAge age)
	//	{
	//		// higher BMI means more power, but less acceleration
	//		//PhysicalFeature.Power
			
	//		// taller players have better heading capabilities
	//		//PhysicalFeature.TopSpeed
	//	}
	//}
}
