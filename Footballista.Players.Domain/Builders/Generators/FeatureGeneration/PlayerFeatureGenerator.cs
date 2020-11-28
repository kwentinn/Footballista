using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Players.Builders.Generators.FeatureGeneration;
using Footballista.Players.Builders.Randomisers;
using Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Domain.Builders.Generators.FeatureGeneration.RatingRanges;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Physique;
using Footballista.Players.Domain.Positions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration
{
	public class PlayerFeatureGenerator
	{
		private PlayerPosition _position;
		private BodyMassIndex _bmi;
		private Country _country;
		private PersonAge _playerAge;
		private PlayerStatus _playerStatus;

		private readonly IRandomiser<Rating> _randomiser;

		public PlayerFeatureGenerator(IRandomiser<Rating> randomiser)
		{
			_randomiser = randomiser;
		}

		public PlayerFeatureGenerator ForPosition(PlayerPosition position)
		{
			_position = position;
			return this;
		}
		public PlayerFeatureGenerator ForBmi(BodyMassIndex bmi)
		{
			_bmi = bmi;
			return this;
		}
		public PlayerFeatureGenerator ForCountry(Country country)
		{
			_country = country;
			return this;
		}
		public PlayerFeatureGenerator ForPersonAge(PersonAge playerAge)
		{
			_playerAge = playerAge;
			return this;
		}
		public PlayerFeatureGenerator ForPlayerStatus(PlayerStatus playerStatus)
		{
			_playerStatus = playerStatus;
			return this;
		}

		private Range<Rating> CalculateRatingRange()
		{
			Range<Rating> rating = PlayerStatus.GetRatingRangeForStatus(_playerStatus ?? PlayerStatus.Average);

			Range<Rating> weightedRating = AgeRange.GetRatingRangeForAge(_playerAge);

			double lower = Math.Max(0.01, rating.Lower.Value * weightedRating.Lower.Value);

			double upper = Math.Min(0.99, rating.Upper.Value * weightedRating.Upper.Value);

			return new Range<Rating>(lower, upper);
		}

		public PhysicalFeatureSet Generate()
		{
			PlayerPositionGenerationRangeDefinition playerPositionGenRange =
				PlayerPositionGenerationRangeDefinition.GetFromPosition(_position);

			ReadOnlyCollection<GenRange> positionGenRanges = playerPositionGenRange.GetGenerationRangeDefinitions();
			ReadOnlyCollection<GenRange> bmiGenRanges = BodyMassIndexGenerationRangeDefinition.Generate(_bmi, _playerAge);

			// plages de génération différentes en fonction de 
			// - la position du joueur
			// - du BMI
			// - [TODO] du pays (à voir plus tard)
			// - [TODO] de l'âge du joueur

			PhysicalFeatureSet set = PhysicalFeatureSet.CreateFeatureSet(_position.PositionCategory);

			Parallel.ForEach(set.PhysicalFeatures, feature =>
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
						//if (feature.FeatureType == FeatureType.Morale)
						//{
						//	rating = _randomiser.Randomise();
						//}
						//else
						//{
						Range<Rating> range = CalculateRatingRange();
						rating = _randomiser.Randomise(range);
						//}
					}
				}
				feature.ChangeRating(rating);
			});
			return set;
		}
	}
}
