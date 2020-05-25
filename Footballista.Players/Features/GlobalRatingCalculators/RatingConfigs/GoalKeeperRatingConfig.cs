using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class GoalKeeperRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.GoalKeeper;
		public GoalKeeperRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Goalkeeping,
					FeatureType.Power,
					FeatureType.Agility,
					FeatureType.Focus,
					FeatureType.Composure,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(2, new List<FeatureType>
				{
					FeatureType.PassingAccuracy,
					FeatureType.FightingSpirit,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.Morale,
					FeatureType.PassingSpeed,
					FeatureType.Cross,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.Stamina,
					FeatureType.FreeKick,
				}),
			});
		}
	}

}
