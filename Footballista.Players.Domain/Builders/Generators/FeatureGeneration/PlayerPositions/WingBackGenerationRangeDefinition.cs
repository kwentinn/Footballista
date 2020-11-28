﻿using Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class WingBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public WingBackGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// bad skills
				new GenRange(FeatureType.Acceleration, MinRange),
				new GenRange(FeatureType.TopSpeed,MinRange),
				new GenRange(FeatureType.Finishing, MinRange),
				
				// medium skills
				new GenRange(FeatureType.PassingAccuracy, MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),

				// top skills
				new GenRange(FeatureType.Interception, MaxRange),
				new GenRange(FeatureType.Tackling, MaxRange),
			});

		}
	}
}