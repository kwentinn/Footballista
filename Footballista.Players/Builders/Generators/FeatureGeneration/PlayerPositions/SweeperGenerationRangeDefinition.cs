using Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal class SweeperGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public SweeperGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
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