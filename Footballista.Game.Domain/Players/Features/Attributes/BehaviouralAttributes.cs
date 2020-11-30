using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Features.Attributes.Calculator;

namespace Footballista.Players.Features.Attributes
{
	public class BehaviouralAttributes : AbstractPlayerAttributes
    {
        private readonly RatingWithWeighting stress;
        private readonly RatingWithWeighting composure;
        private readonly RatingWithWeighting frustration;

        public BehaviouralAttributes(Rating stress, Rating composure, Rating frustration)
        {
            this.stress = new RatingWithWeighting(1, stress);
            this.composure = new RatingWithWeighting(3, composure);
            this.frustration = new RatingWithWeighting(1, frustration);
        }

        protected override Rating CalculateRating()
        {
            return new RatingWithWeightingCalculator()
                .WithRatingWeighting(stress)
                .WithRatingWeighting(composure)
                .WithRatingWeighting(frustration)
                .Calculate();
        }

        public override bool IsMatchForPosition(PlayerPosition position) => true;
    }
}
