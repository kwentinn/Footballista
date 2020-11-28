using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;

namespace Footballista.Players.Domain.Builders.Generators.FeatureGeneration.RatingRanges
{
	public abstract record NamedRatingRange
	{
		protected readonly string Name;
		protected readonly Range<Rating> RatingRange;

		protected NamedRatingRange(string name, Range<Rating> ratingRange)
		{
			this.Name = name;
			this.RatingRange = ratingRange;
		}
	}
}
