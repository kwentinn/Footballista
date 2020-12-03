using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal sealed class WideMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
    {
        public WideMidfieldGenerationRangeDefinition()
        {
            AddBadSkills(FeatureType.Acceleration, FeatureType.TopSpeed, FeatureType.Finishing);
            AddMediumSkills(FeatureType.PassingAccuracy, FeatureType.PassingSpeed, FeatureType.Cross);
            AddBestSkills(FeatureType.Interception, FeatureType.Tackling);
        }
    }
}