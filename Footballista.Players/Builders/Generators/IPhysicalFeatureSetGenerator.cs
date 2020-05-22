using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators.FeatureGeneration;
using Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Features;
using Footballista.Players.Physique;
using Footballista.Players.Positions;
using System.Collections.ObjectModel;
using System.Linq;
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
			PlayerPositionGenerationRangeDefinition playerPositionGenRange = PlayerPositionGenerationRangeDefinition.GetFromPosition(position);

			ReadOnlyCollection<GenRange> positionGenRanges = playerPositionGenRange.GetGenerationRangeDefinitions();
			ReadOnlyCollection<GenRange> bmiGenRanges = BodyMassIndexGenerationRangeDefinition.Generate(bmi, playerAge);

			// plages de génération différentes en fonction de 
			// - la position du joueur
			// - du BMI
			// - du pays (à voir plus tard)
			// - [TODO] de l'âge du joueur

			PhysicalFeatureSet set = PhysicalFeatureSet.CreateFeatureSet(position.PositionCategory);

			//Parallel.ForEach(set.PhysicalFeatures, feature =>
			//{
			foreach (PhysicalFeature feature in set.PhysicalFeatures)
			{
				Rating rating;

				GenRange genRangeFromPosition = positionGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);
				GenRange genRangeFromBmi = bmiGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);

				if (genRangeFromBmi != null && genRangeFromPosition != null)
				{
					Range<Rating> range = Range<Rating>.MergeRanges(new Range<Rating>[]
					{
						genRangeFromBmi.RatingRange,
						genRangeFromPosition.RatingRange
					});
					rating = _randomiser.Randomise(range);
				}
				else
				{
					if (genRangeFromPosition != null)
					{
						rating = _randomiser.Randomise(genRangeFromPosition.RatingRange);
					}
					else
					{
						if (feature.FeatureType == FeatureType.Morale)
						{
							rating = _randomiser.Randomise();
						}
						else
						{
							rating = _randomiser.Randomise(_youngPlayerFeatureRatingRange);
						}
					}
				}
				feature.ChangeRating(rating);
			}
			//});
			return set;
		}
	}
}
