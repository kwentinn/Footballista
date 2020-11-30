using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class CentreForwardGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public CentreForwardGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Finishing, MaxRange),
				new GenRange(FeatureType.Header, MaxRange),
				new GenRange(FeatureType.Composure, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.Acceleration, MediumRange),
				new GenRange(FeatureType.PassingAccuracy, MediumRange),
				new GenRange(FeatureType.PassingSpeed, MediumRange),
				new GenRange(FeatureType.TopSpeed, MediumRange),

				// bad skills
				new GenRange(FeatureType.Cross, MinRange),
				new GenRange(FeatureType.Interception, MinRange),
				new GenRange(FeatureType.Tackling, MinRange),
			});
		}
	}
}