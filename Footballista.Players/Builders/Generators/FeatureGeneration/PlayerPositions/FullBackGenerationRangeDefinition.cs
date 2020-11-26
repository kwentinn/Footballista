using Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal class FullBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public FullBackGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Interception, MaxRange),
				new GenRange(FeatureType.Tackling, MaxRange),
				new GenRange(FeatureType.Stamina, MaxRange),
				new GenRange(FeatureType.Power, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.Acceleration, MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.Header, MediumRange),

				// bad skills
				new GenRange(FeatureType.FreeKick, MinRange),
				new GenRange(FeatureType.PenaltyKick, MinRange),
				new GenRange(FeatureType.Cross, MinRange),
				new GenRange(FeatureType.TopSpeed, MinRange),
				new GenRange(FeatureType.Agility, MinRange),
			});
		}
	}
}