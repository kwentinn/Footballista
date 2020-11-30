using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class AttackingMidfielderRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.AttackingMidfield;
		public AttackingMidfielderRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>
				{
					FeatureType.Agility,
					FeatureType.Composure,
					FeatureType.Focus,
					FeatureType.Vista
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.ReactionSpeed,
					FeatureType.PassingAccuracy,
					FeatureType.PassingSpeed,
					FeatureType.Cross,
					FeatureType.Stamina,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					FeatureType.FreeKick,
					FeatureType.FightingSpirit,
					FeatureType.Finishing,
					FeatureType.TopSpeed,
				}),
				new RatingWeighting(0.5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Interception,
					FeatureType.Power,
					FeatureType.Tackling,
					//FeatureType.Morale,
				})
			});
		}
	}

}
