using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class CentreMidfieldRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.CentreMidfield;
		public CentreMidfieldRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Interception,
					FeatureType.Stamina,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Power,
					FeatureType.ReactionSpeed,
					FeatureType.PassingAccuracy,
					FeatureType.FightingSpirit,
					FeatureType.Vista,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.Morale,
					FeatureType.Composure,
					FeatureType.Tackling,
					FeatureType.Focus,
					FeatureType.PassingSpeed,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.Agility,
					FeatureType.Cross,
					FeatureType.FreeKick,
					FeatureType.PenaltyKick,
					FeatureType.Finishing,
					FeatureType.TopSpeed,
				}),
			});
		}
	}

}
