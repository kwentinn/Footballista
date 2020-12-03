using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.RatingRanges;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Physique;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Builders.Generators.FeatureGeneration;
using Footballista.Players.Builders.Randomisers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration
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
			ReadOnlyCollection<GenRange> positionGenRanges = PlayerPositionGenerationRangeDefinition.GetGenerationRanges(_position);
			ReadOnlyCollection<GenRange> bmiGenRanges = BodyMassIndexGenerationRangeDefinition.Generate(_bmi, _playerAge);

			// plages de génération différentes en fonction de 
			// - la position du joueur
			// - du BMI
			// - [TODO] du pays (à voir plus tard)
			// - [TODO] de l'âge du joueur

			PhysicalFeatureSet set = PhysicalFeatureSet.CreateFeatureSet(_position.PositionCategory);

			Parallel.ForEach(set.PhysicalFeatures, UpdateRating(positionGenRanges, bmiGenRanges));
			return set;
		}

		private Action<PhysicalFeature> UpdateRating
		(
			ReadOnlyCollection<GenRange> positionGenRanges,
			ReadOnlyCollection<GenRange> bmiGenRanges
		)
		{
			return feature =>
			{
				GenRange genRangeFromPosition = positionGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);
				GenRange genRangeFromBmi = bmiGenRanges.FirstOrDefault(c => c.FeatureType == feature.FeatureType);

				bool hasGenRangeFromPosition = genRangeFromPosition != null;
				bool hasGenRangeFromBmi = genRangeFromBmi != null;
				bool hasGenerationRange = hasGenRangeFromBmi && hasGenRangeFromPosition;
				Rating rating;

				if (hasGenerationRange)
				{
					rating = _randomiser.Randomise(genRangeFromBmi.RatingRange.Merge(genRangeFromPosition.RatingRange));
					feature.ChangeRating(rating);
					return;
				}

				if (hasGenRangeFromPosition)
				{
					rating = _randomiser.Randomise(genRangeFromPosition.RatingRange);
					feature.ChangeRating(rating);
					return;
				}

				if (hasGenRangeFromBmi)
				{
					rating = _randomiser.Randomise(genRangeFromBmi.RatingRange);
					feature.ChangeRating(rating);
					return;
				}

				//if (feature.FeatureType == FeatureType.Morale)
				//{
				//	rating = _randomiser.Randomise();
				//}
				//else
				//{
				Range<Rating> range = CalculateRatingRange();

				rating = _randomiser.Randomise(range);
				feature.ChangeRating(rating);
			};
		}
	}
}
