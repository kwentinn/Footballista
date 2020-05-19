using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class CentreMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public CentreMidfieldGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Interception, MaxRange),
				new GenRange(Feature.Tackling, MaxRange),
				new GenRange(Feature.PassingSpeed, MaxRange),
				
				// medium skills
				new GenRange(Feature.Acceleration, MediumRange),
				new GenRange(Feature.Stamina, MediumRange),
				new GenRange(Feature.FreeKick, MediumRange),
				new GenRange(Feature.Cross, MediumRange),
				new GenRange(Feature.Header, MediumRange),
				new GenRange(Feature.TopSpeed, MediumRange),

				// bad skills
				new GenRange(Feature.PenaltyKick, MinRange),
				new GenRange(Feature.Agility, MinRange),
			});

		}
	}
}