using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    public class AttackingMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal AttackingMidfieldGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Acceleration, MaxRange),
				new GenRange(FeatureType.Agility, MaxRange),
				new GenRange(FeatureType.PassingAccuracy, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.TopSpeed,MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),

				// worst skills
				new GenRange(FeatureType.Interception, MinRange),
				new GenRange(FeatureType.Tackling, MinRange),
			});
		}
	}
}