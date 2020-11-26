using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Positions;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
    public class BehaviouralAttributes : AbstractPlayerAttributes
    {
        public RatingWeighting Stress { get; }
        public RatingWeighting Composure { get; }
        public RatingWeighting Frustration { get; }

        public BehaviouralAttributes(Rating stress, Rating composure, Rating frustration)
        {
            this.Stress = new RatingWeighting(1, stress);
            this.Composure = new RatingWeighting(3, composure);
            this.Frustration = new RatingWeighting(1, frustration);
        }

        protected override Rating CalculateRating()
        {
            return new RatingWeightingCalculator()
                .WithRatingWeighting(Stress)
                .WithRatingWeighting(Composure)
                .WithRatingWeighting(Frustration)
                .Calculate();
        }

        public override bool IsMatchForPosition(PlayerPosition position) => true;
    }
}
