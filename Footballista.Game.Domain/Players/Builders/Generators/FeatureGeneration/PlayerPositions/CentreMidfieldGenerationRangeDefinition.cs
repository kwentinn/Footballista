using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal sealed class CentreMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public CentreMidfieldGenerationRangeDefinition()
		{
			_generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Interception, MaxRange),
				new GenRange(FeatureType.Tackling, MaxRange),
				new GenRange(FeatureType.PassingSpeed, MaxRange),

				// medium skills
				new GenRange(FeatureType.Acceleration, MediumRange),
				new GenRange(FeatureType.Stamina, MediumRange),
				new GenRange(FeatureType.FreeKick, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),
				new GenRange(FeatureType.Header, MediumRange),
				new GenRange(FeatureType.TopSpeed, MediumRange),

				// bad skills
				new GenRange(FeatureType.PenaltyKick, MinRange),
				new GenRange(FeatureType.Agility, MinRange),
			});

		}
	}
}