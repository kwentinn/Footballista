using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.RatingRanges
{
    public record PlayerStatus : NamedRatingRange
    {
        public static PlayerStatus Superstar => new PlayerStatus(nameof(Superstar), new Range<Rating>(.9, .99));
        public static PlayerStatus Star => new PlayerStatus(nameof(Star), new Range<Rating>(.8, .89));
        public static PlayerStatus VeryTalented => new PlayerStatus(nameof(VeryTalented), new Range<Rating>(.7, .79));
        public static PlayerStatus Talented => new PlayerStatus(nameof(Talented), new Range<Rating>(.6, .69));
        public static PlayerStatus Average => new PlayerStatus(nameof(Average), new Range<Rating>(.5, .59));
        public static PlayerStatus Mediocre => new PlayerStatus(nameof(Mediocre), new Range<Rating>(.3, .49));
        public static PlayerStatus Bad => new PlayerStatus(nameof(Bad), new Range<Rating>(.1, .29));

        private static List<PlayerStatus> playerStatuses = new List<PlayerStatus>
        {
            Superstar, Star, VeryTalented, Talented, Average, Mediocre, Bad
        };

        public PlayerStatus(string name, Range<Rating> ratingRange) : base(name, ratingRange) { }

        public static Range<Rating> GetRatingForStatus(PlayerStatus status)
        {
            return playerStatuses.FirstOrDefault(s => s == status).ratingRange;
        }
    }
}
