using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class WingBackRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.WingBack;
		public WingBackRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.TopSpeed,
					FeatureType.Acceleration,
					FeatureType.Power,
					FeatureType.Tackling,
					FeatureType.Agility,
					FeatureType.Stamina,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Cross,
					FeatureType.PassingAccuracy,
					//FeatureType.Morale,
					FeatureType.Composure,
					FeatureType.Interception,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.PassingSpeed,
					FeatureType.Vista,
					FeatureType.Header,
					FeatureType.Focus,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.FreeKick,
					FeatureType.FightingSpirit,
					FeatureType.Finishing,
				}),
			});
		}
	}

}
