using Footballista.Players.Domain.Features;
using Footballista.Players.Features.Attributes.Weightings;

namespace Footballista.Players.Features.Attributes
{
	public sealed class RatingWithWeighting
    {
        private readonly Rating rating;
        public Weighting Weighting { get; }

        public WeightingResult WeightingResult => this.Weighting * this.rating.Value;

        public RatingWithWeighting(double weighting, Rating rating)
        {
            this.Weighting = weighting;
            this.rating = rating;
        }
    }
}
