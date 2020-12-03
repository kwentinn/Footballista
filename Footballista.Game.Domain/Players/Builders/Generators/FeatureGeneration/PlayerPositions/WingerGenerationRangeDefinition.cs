using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	public sealed class WingerGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		internal WingerGenerationRangeDefinition()
		{
			AddBestSkills(FeatureType.Acceleration, FeatureType.TopSpeed, FeatureType.Finishing);
			AddMediumSkills(FeatureType.PassingAccuracy, FeatureType.PassingSpeed, FeatureType.Cross);
			AddBadSkills(FeatureType.Interception, FeatureType.Tackling);
		}
	}
}
