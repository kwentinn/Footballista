using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public class WingerGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal WingerGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Acceleration, MaxRange),
				new GenRange(Feature.TopSpeed, MaxRange),
				new GenRange(Feature.Finishing, MaxRange),
				
				// medium skills
				new GenRange(Feature.PassingAccuracy, MediumRange),
				new GenRange(Feature.PassingSpeed, MediumRange),
				new GenRange(Feature.Cross, MediumRange),

				// bad skills
				new GenRange(Feature.Interception, MinRange),
				new GenRange(Feature.Tackling, MinRange),
			});
		}
	}
}
