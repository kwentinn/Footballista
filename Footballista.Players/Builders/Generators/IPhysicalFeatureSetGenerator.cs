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
		private readonly IRandomiser<Rating> _randomiser;

		private static Range<Rating> _youngPlayerFeatureRatingRange 
			=> new Range<Rating>(new Rating(.2), new Rating(.55));

		private static Range<Rating> _standardPlayerFeatureRatingRange 
			=> new Range<Rating>(new Rating(.35), new Rating(.85));
		private static Range<Rating> _specialPlayerFeatureRatingRange 
			=> new Range<Rating>(new Rating(.5), new Rating(.99));

		public PhysicalFeatureSetGenerator(IRandomiser<Rating> randomiser)
		{
			_randomiser = randomiser;
		}

		public PhysicalFeatureSet Generate(PlayerPosition position, BodyMassIndex bmi, Country country, PersonAge playerAge)
		{
			PhysicalFeatureSet set = PhysicalFeatureSet.GetFeatureSet(position.PositionCategory);

			// plages de génération différentes en fonction de 
			// - la position du joueur
			// - du BMI
			// - du pays (à voir plus tard)
			// - de l'âge du joueur

			Parallel.ForEach(set.PhysicalFeatures, feature =>
			{
				Rating rating;

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
