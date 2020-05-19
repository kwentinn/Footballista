﻿using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class GoalKeeperGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public GoalKeeperGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Goalkeeping, MaxRange),
				new GenRange(Feature.ReactionSpeed, MaxRange),
			});
		}
	}
}