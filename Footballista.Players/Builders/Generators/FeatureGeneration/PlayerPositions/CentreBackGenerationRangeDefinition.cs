﻿using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public class CentreBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal CentreBackGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Interception, MaxRange),
				new GenRange(FeatureType.Tackling, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.PassingAccuracy, MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),

				// bad skills
				new GenRange(FeatureType.Acceleration, MinRange),
				new GenRange(FeatureType.TopSpeed,MinRange),
				new GenRange(FeatureType.Finishing, MinRange),
			});
		}
	}
}