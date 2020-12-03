using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
	internal sealed class CentreForwardGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
	{
		public CentreForwardGenerationRangeDefinition()
		{
			AddBestSkills(FeatureType.Finishing, FeatureType.Header, FeatureType.Composure);
			AddMediumSkills(FeatureType.Acceleration, FeatureType.PassingAccuracy, FeatureType.PassingSpeed, FeatureType.TopSpeed);
			AddBadSkills(FeatureType.Cross, FeatureType.Interception, FeatureType.Tackling);
		}
	}
}