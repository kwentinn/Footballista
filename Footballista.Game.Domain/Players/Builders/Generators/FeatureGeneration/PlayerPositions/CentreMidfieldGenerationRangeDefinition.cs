using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal sealed class CentreMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
    {
        public CentreMidfieldGenerationRangeDefinition()
        {
            AddBestSkills(
                FeatureType.Interception,
                FeatureType.Tackling,
                FeatureType.PassingSpeed);

            AddMediumSkills(
                FeatureType.Acceleration,
                FeatureType.Stamina,
                FeatureType.FreeKick,
                FeatureType.Cross,
                FeatureType.Header,
                FeatureType.TopSpeed);

            AddBadSkills(
                FeatureType.PenaltyKick,
                FeatureType.Agility);
        }
    }
}