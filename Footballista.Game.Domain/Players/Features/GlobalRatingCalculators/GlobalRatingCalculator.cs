using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.GlobalRatingCalculators
{
	public class GlobalRatingCalculator
	{
		private readonly List<PlayerRatingConfigBase> _playerRatingWeightings = new List<PlayerRatingConfigBase>()
		{
			new RatingConfigs.AttackingMidfielderRatingConfig(),
			new RatingConfigs.CentreBackRatingConfig(),
			new RatingConfigs.CentreForwardRatingConfig(),
			new RatingConfigs.CentreMidfieldRatingConfig(),
			new RatingConfigs.DefensiveMidfieldRatingConfig(),
			new RatingConfigs.FullBackRatingConfig(),
			new RatingConfigs.GoalKeeperRatingConfig(),
			new RatingConfigs.SecondStrikerRatingConfig(),
			new RatingConfigs.SweeperRatingConfig(),
			new RatingConfigs.WideMidfieldRatingConfig(),
			new RatingConfigs.WingBackRatingConfig(),
			new RatingConfigs.WingerRatingConfig(),
		};

		public Rating Calculate(PlayerPosition position, PhysicalFeatureSet featureSet)
		{
			Ensure.IsNotNull(position);
			Ensure.IsNotNull(featureSet);

			// récupération de la config de rating
			PlayerRatingConfigBase config = _playerRatingWeightings
				.FirstOrDefault(prw => prw.PlayerPosition == position);
			if (config is null)
			{
				throw new InvalidOperationException("Cannot find corresponding rating calculator");
			}

			double weightedRatingsSum = 0d;
			double weightingsSum = config.RatingWeightings.Sum(rw => rw.Weighting);

			foreach (RatingWeighting rw in config.RatingWeightings)
			{
				List<PhysicalFeature> features = featureSet.PhysicalFeatures
					.Where(fs => rw.FeatureTypes.Any(ft => ft == fs.FeatureType))
					.ToList();
				if (features.Any())
				{
					weightedRatingsSum += features.Sum(f => f.Rating.Value * rw.Weighting) / features.Count;
				}
			}

			return new Rating(weightedRatingsSum / weightingsSum);
		}
	}
}
