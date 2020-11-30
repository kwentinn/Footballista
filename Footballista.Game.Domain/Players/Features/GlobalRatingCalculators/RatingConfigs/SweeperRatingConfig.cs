using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class SweeperRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.Sweeper;
		public SweeperRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Interception,
					FeatureType.Vista,
					FeatureType.Stamina,
					FeatureType.Tackling,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Power,
					//FeatureType.Morale,
					FeatureType.Composure,
					FeatureType.Focus,
					FeatureType.Cross,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.FightingSpirit,
					FeatureType.PassingAccuracy,
					FeatureType.PassingSpeed,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.Agility,
					FeatureType.FreeKick,
					FeatureType.Finishing,
					FeatureType.TopSpeed,
				}),
			});
		}
	}

}
