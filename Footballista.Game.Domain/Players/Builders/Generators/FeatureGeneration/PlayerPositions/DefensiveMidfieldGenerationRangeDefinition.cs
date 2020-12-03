using Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions.Base;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.PlayerPositions
{
    internal sealed class DefensiveMidfieldGenerationRangeDefinition : PlayerPositionGenerationRangeDefinition
    {
        public DefensiveMidfieldGenerationRangeDefinition()
        {
            AddBestSkills(
                FeatureType.Interception,
                FeatureType.Tackling,
                FeatureType.PassingSpeed,
                FeatureType.Stamina);

            AddMediumSkills(
                FeatureType.Acceleration,
                FeatureType.Cross,
                FeatureType.Header);

            AddBadSkills(
                FeatureType.PenaltyKick,
                FeatureType.TopSpeed,
                FeatureType.Agility);
        }
    }
}