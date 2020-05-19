using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using Footballista.Players.Positions;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public class AttackingMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal AttackingMidfieldGenerationRangeDefinition(PlayerPosition position) : base(position)
		{
			generationRanges.AddRange(new GenRange[]
			{
				// top skills
				new GenRange(Feature.Acceleration, MaxRange),
				new GenRange(Feature.Agility, MaxRange),
				new GenRange(Feature.PassingAccuracy, MaxRange),
				
				// medium skills
				new GenRange(Feature.TopSpeed,MediumRange),
				new GenRange(Feature.PassingSpeed, MediumRange),
				new GenRange(Feature.Cross, MediumRange),

				// worst skills
				new GenRange(Feature.Interception, MinRange),
				new GenRange(Feature.Tackling, MinRange),
			});
		}
	}
}