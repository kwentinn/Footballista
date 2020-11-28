using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.Attributes.Calculator
{
    public sealed class RatingWithWeightingCalculator
    {
        private readonly List<RatingWithWeighting> weightings = new List<RatingWithWeighting>();

        internal RatingWithWeightingCalculator WithRatingWeighting(RatingWithWeighting ratingWeighting)
        {
            this.weightings.Add(ratingWeighting);
            return this;
        }

        public Rating Calculate()
        {
            double result = this.weightings.Sum(w => w.WeightingResult.Value) / this.weightings.Sum(w => w.Weighting);
            return new Rating(result);
        }
    }
}
