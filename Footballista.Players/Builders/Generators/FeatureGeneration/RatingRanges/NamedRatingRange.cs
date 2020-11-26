using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;

namespace Footballista.Players.Builders.Generators.FeatureGeneration.RatingRanges
{
    public abstract record NamedRatingRange
    {
        protected readonly string name;
        protected readonly Range<Rating> ratingRange;

        protected NamedRatingRange(string name, Range<Rating> ratingRange)
        {
            this.name = name;
            this.ratingRange = ratingRange;
        }
    }
}
