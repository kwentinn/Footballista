using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class GoalKeeperGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public GoalKeeperGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Goalkeeping, MaxRange),
				new GenRange(FeatureType.ReactionSpeed, MaxRange),
			});
		}
	}
}