using Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal class DefensiveMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public DefensiveMidfieldGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			GenerationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(FeatureType.Interception, MaxRange),
				new GenRange(FeatureType.Tackling, MaxRange),
				new GenRange(FeatureType.PassingSpeed, MaxRange),
				new GenRange(FeatureType.Stamina, MaxRange),
				
				// medium skills
				new GenRange(FeatureType.Acceleration, MediumRange),
				new GenRange(FeatureType.Cross, MediumRange),
				new GenRange(FeatureType.Header, MediumRange),

				// bad skills
				new GenRange(FeatureType.PenaltyKick, MinRange),
				new GenRange(FeatureType.TopSpeed, MinRange),
				new GenRange(FeatureType.Agility, MinRange),
			});
		}
	}
}