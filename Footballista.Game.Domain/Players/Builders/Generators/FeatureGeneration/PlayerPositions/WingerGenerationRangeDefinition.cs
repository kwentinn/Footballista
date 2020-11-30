using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public class WingerGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal WingerGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Acceleration, MaxRange),
				new GenRange(FeatureType.TopSpeed, MaxRange),
				new GenRange(FeatureType.Finishing, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.PassingAccuracy, MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),

				// bad skills
				new GenRange(FeatureType.Interception, MinRange),
				new GenRange(FeatureType.Tackling, MinRange),
			});
		}
	}
}
