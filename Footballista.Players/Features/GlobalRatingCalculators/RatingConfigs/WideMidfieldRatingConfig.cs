using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class WideMidfieldRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.WideMidfield;
		public WideMidfieldRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Vista,
					FeatureType.TopSpeed,
					FeatureType.Cross,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Stamina,
					//FeatureType.Morale,
					FeatureType.Agility,
					FeatureType.Composure,
					FeatureType.Focus,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.Power,
					FeatureType.Finishing,
					FeatureType.PassingAccuracy,
					FeatureType.PassingSpeed,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.FreeKick,
					FeatureType.FightingSpirit,
					FeatureType.Interception,
					FeatureType.Tackling,
				}),
			});
		}
	}

}
