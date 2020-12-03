using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal sealed class GoalKeeperGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public GoalKeeperGenerationRangeDefinition()
		{
			_generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Goalkeeping, MaxRange),
				new GenRange(FeatureType.ReactionSpeed, MaxRange),
			});
		}
	}
}