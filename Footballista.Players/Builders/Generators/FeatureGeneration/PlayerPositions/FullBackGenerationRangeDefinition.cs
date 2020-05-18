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
				new GenRange(Feature.Interception, MaxRange),
				new GenRange(Feature.Tackling, MaxRange),
				new GenRange(Feature.Stamina, MaxRange),
				new GenRange(Feature.Power, MaxRange),
				
				// medium skills
				new GenRange(Feature.Acceleration, MediumRange),
				new GenRange(Feature.PassingSpeed, MediumRange),
				new GenRange(Feature.Header, MediumRange),

				// bad skills
				new GenRange(Feature.FreeKick, MinRange),
				new GenRange(Feature.PenaltyKick, MinRange),
				new GenRange(Feature.Cross, MinRange),
				new GenRange(Feature.TopSpeed, MinRange),
				new GenRange(Feature.Agility, MinRange),
			});
		}
	}
}