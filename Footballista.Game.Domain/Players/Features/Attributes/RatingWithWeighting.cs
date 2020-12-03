using Footballista.Game.Domain.Players.Features;
using Footballista.Players.Features.Attributes.Weightings;

namespace Footballista.Players.Features.Attributes
{
	public sealed class RatingWithWeighting
    {
        private readonly Rating _rating;
        public Weighting Weighting { get; }

        public WeightingResult WeightingResult => this.Weighting * this._rating.Value;

        public RatingWithWeighting(double weighting, Rating rating)
        {
            this.Weighting = weighting;
            this._rating = rating;
        }
    }
}
