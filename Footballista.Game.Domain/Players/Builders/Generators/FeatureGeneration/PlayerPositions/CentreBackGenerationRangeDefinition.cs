using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    public sealed class CentreBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
    {
        internal CentreBackGenerationRangeDefinition()
        {
            AddBestSkills(FeatureType.Interception, FeatureType.Tackling);
            AddMediumSkills(FeatureType.PassingAccuracy, FeatureType.PassingSpeed, FeatureType.Cross);
            AddBadSkills(FeatureType.Acceleration, FeatureType.TopSpeed, FeatureType.Finishing);
        }
    }
}