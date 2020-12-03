using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public sealed class AttackingMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal AttackingMidfieldGenerationRangeDefinition()
		{
			AddBestSkills(FeatureType.Acceleration, FeatureType.Agility, FeatureType.PassingAccuracy);
			AddMediumSkills(FeatureType.TopSpeed, FeatureType.PassingSpeed, FeatureType.Cross);
			AddBadSkills(FeatureType.Interception, FeatureType.Tackling);
		}
	}
}