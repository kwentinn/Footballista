using Footballista.Players.Features;
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
				new GenRange(Feature.Interception, MaxRange),
				new GenRange(Feature.Tackling, MaxRange),
				
				// medium skills
				new GenRange(Feature.PassingAccuracy, MediumRange),
				new GenRange(Feature.PassingSpeed, MediumRange),
				new GenRange(Feature.Cross, MediumRange),

				// bad skills
				new GenRange(Feature.Acceleration, MinRange),
				new GenRange(Feature.TopSpeed,MinRange),
				new GenRange(Feature.Finishing, MinRange),
			});
		}
	}
}