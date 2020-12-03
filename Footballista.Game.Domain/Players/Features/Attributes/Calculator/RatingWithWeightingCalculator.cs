using Footballista.Game.Domain.Players.Features;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.Attributes.Calculator
{
	public sealed class RatingWithWeightingCalculator
    {
        private readonly List<RatingWithWeighting> _weightings = new List<RatingWithWeighting>();

        internal RatingWithWeightingCalculator WithRatingWeighting(RatingWithWeighting ratingWeighting)
        {
            this._weightings.Add(ratingWeighting);
            return this;
        }

        public Rating Calculate()
        {
            double result = this._weightings.Sum(w => w.WeightingResult.Value) / this._weightings.Sum(w => w.Weighting);
            return new Rating(result);
        }
    }
}
