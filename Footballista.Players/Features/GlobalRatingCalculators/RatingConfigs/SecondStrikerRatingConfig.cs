using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class SecondStrikerRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.SecondStriker;
		public SecondStrikerRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Finishing,
					FeatureType.Power,
					FeatureType.Focus,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Stamina,
					//FeatureType.Morale,
					FeatureType.Agility,
					FeatureType.Composure,
					FeatureType.Vista,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.FightingSpirit,
					FeatureType.PassingAccuracy,
					FeatureType.PassingSpeed,
					FeatureType.TopSpeed,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.Interception,
					FeatureType.Tackling,
					FeatureType.Cross,
					FeatureType.FreeKick,
				}),
			});
		}
	}

}
