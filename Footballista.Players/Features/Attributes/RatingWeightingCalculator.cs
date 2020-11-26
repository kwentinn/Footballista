using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.Attributes
{
    public sealed class RatingWeightingCalculator
    {
        private readonly List<RatingWeighting> weightings = new List<RatingWeighting>();
        internal RatingWeightingCalculator WithRatingWeighting(RatingWeighting ratingWeighting)
        {
            this.weightings.Add(ratingWeighting);
            return this;
        }
        public Rating Calculate()
        {
            double result = this.weightings.Sum(w => w.WeightedValue) / this.weightings.Sum(w => w.Weighting);
            return new Rating(result);
        }
    }
}
