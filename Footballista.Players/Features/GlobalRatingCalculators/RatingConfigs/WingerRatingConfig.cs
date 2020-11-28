using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class WingerRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.Winger;
		public WingerRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.TopSpeed,
					FeatureType.Acceleration,
					FeatureType.Agility,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Finishing,
					FeatureType.PassingAccuracy,
					//FeatureType.Morale,
					FeatureType.Composure,
					FeatureType.ReactionSpeed,
					FeatureType.Stamina,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.Power,
					FeatureType.Cross,
					FeatureType.PassingSpeed,
					FeatureType.Vista,
					FeatureType.Header,
					FeatureType.Focus,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.FreeKick,
					FeatureType.FightingSpirit,
					FeatureType.Tackling,
					FeatureType.Interception,
				}),
			});
		}
	}

}
