using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class CentreForwardGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public CentreForwardGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Finishing, MaxRange),
				new GenRange(Feature.Header, MaxRange),
				new GenRange(Feature.Composure, MaxRange),
				
				// medium skills
				new GenRange(Feature.Acceleration, MediumRange),
				new GenRange(Feature.PassingAccuracy, MediumRange),
				new GenRange(Feature.PassingSpeed, MediumRange),
				new GenRange(Feature.TopSpeed, MediumRange),

				// bad skills
				new GenRange(Feature.Cross, MinRange),
				new GenRange(Feature.Interception, MinRange),
				new GenRange(Feature.Tackling, MinRange),
			});
		}
	}
}