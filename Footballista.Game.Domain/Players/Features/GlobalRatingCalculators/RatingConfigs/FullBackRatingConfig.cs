using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class FullBackRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.FullBack;
		public FullBackRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Header,
					FeatureType.Interception,
					FeatureType.Power,
					FeatureType.Tackling,
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
					FeatureType.Focus,
					FeatureType.PassingAccuracy,
					FeatureType.PassingSpeed,
					FeatureType.Cross,
					FeatureType.Acceleration,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.FreeKick,
					FeatureType.FightingSpirit,
					FeatureType.Finishing,
					FeatureType.TopSpeed,
				}),
			});
		}
	}

}
