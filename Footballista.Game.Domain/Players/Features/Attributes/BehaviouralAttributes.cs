using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Features.Attributes.Calculator;

namespace Footballista.Players.Features.Attributes
{
	public class BehaviouralAttributes : AbstractPlayerAttributes
    {
        private readonly RatingWithWeighting _stress;
        private readonly RatingWithWeighting _composure;
        private readonly RatingWithWeighting _frustration;

        public BehaviouralAttributes(Rating stress, Rating composure, Rating frustration)
        {
            this._stress = new RatingWithWeighting(1, stress);
            this._composure = new RatingWithWeighting(3, composure);
            this._frustration = new RatingWithWeighting(1, frustration);
        }

        protected override Rating CalculateRating()
        {
            return new RatingWithWeightingCalculator()
                .WithRatingWeighting(_stress)
                .WithRatingWeighting(_composure)
                .WithRatingWeighting(_frustration)
                .Calculate();
        }

        public override bool IsMatchForPosition(PlayerPosition position) => true;
    }
}
