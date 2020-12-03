using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal sealed class FullBackGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
    {
        public FullBackGenerationRangeDefinition()
        {
            AddBestSkills(
                FeatureType.Interception,
                FeatureType.Tackling,
                FeatureType.Stamina,
                FeatureType.Power);

            AddMediumSkills(
                FeatureType.Acceleration,
                FeatureType.PassingSpeed,
                FeatureType.Header);

            AddBadSkills(
                FeatureType.FreeKick,
                FeatureType.PenaltyKick,
                FeatureType.Cross,
                FeatureType.TopSpeed,
                FeatureType.Agility);
        }
    }
}