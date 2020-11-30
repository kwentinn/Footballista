using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class SecondStrikerGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public SecondStrikerGenerationRangeDefinition(PlayerPosition position) : base(position)
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