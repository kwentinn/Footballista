using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class DefensiveMidfieldRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.DefensiveMidfield;
		public DefensiveMidfieldRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Interception,
					FeatureType.Power,
					FeatureType.Stamina,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.ReactionSpeed,
					FeatureType.PassingAccuracy,
					FeatureType.FightingSpirit,
					FeatureType.Tackling,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.Morale,
					FeatureType.Composure,
					FeatureType.Vista,
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
