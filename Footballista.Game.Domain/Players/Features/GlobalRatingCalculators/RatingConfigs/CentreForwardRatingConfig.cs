using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs
{
	public class CentreForwardRatingConfig : PlayerRatingConfigBase
	{
		public override PlayerPosition PlayerPosition => PlayerPosition.CentreForward;
		public CentreForwardRatingConfig()
		{
			RatingWeightings.AddRange(new RatingWeighting[]
			{
				new RatingWeighting(5, new List<FeatureType>{
					FeatureType.Finishing,
					FeatureType.Header,
					FeatureType.Power,
					FeatureType.Composure,
					FeatureType.ReactionSpeed,
				}),
				new RatingWeighting(3, new List<FeatureType>
				{
					FeatureType.Agility,
					FeatureType.FightingSpirit,
					FeatureType.Acceleration,
					FeatureType.Focus,
					FeatureType.PenaltyKick,
				}),
				new RatingWeighting(1, new List<FeatureType>
				{
					//FeatureType.Morale,
					FeatureType.Stamina,
					FeatureType.TopSpeed,
					FeatureType.Vista,
				}),
				new RatingWeighting(0.5, new List<FeatureType>
				{
					FeatureType.PassingSpeed,
					FeatureType.FreeKick,
					FeatureType.PassingAccuracy,
					FeatureType.Cross,
					FeatureType.Interception,
					FeatureType.Tackling,
				}),
			});
		}
	}

}
