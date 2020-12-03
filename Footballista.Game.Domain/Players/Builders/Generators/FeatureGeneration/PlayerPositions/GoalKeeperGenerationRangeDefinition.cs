using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal sealed class GoalKeeperGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public GoalKeeperGenerationRangeDefinition()
		{
			AddBestSkills(FeatureType.Goalkeeping, FeatureType.ReactionSpeed);
		}
	}
}