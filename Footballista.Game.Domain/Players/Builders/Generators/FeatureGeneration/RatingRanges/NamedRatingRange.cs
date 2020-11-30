using Footballista.BuildingBlocks.Domain;
using Footballista.Game.Domain.Players.Features;

namespace Footballista.Game.Domain.Players.Builders.Generators.FeatureGeneration.RatingRanges
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
