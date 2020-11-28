using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Features.Attributes.Calculator;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
	public class GoalkeepingAttributes : AbstractPlayerAttributes
    {
        public RatingWithWeighting Goalkeeping { get; }
        public RatingWithWeighting ShotPower { get; }
        public RatingWithWeighting Agility { get; }

        public GoalkeepingAttributes(Rating goalkeeping, Rating shotPower, Rating agility)
        {
            Goalkeeping = new RatingWithWeighting(5, goalkeeping);
            ShotPower = new RatingWithWeighting(2, shotPower);
            Agility = new RatingWithWeighting(2, agility);

            this.MatchingPositions = new List<PlayerPosition>
            {
                PlayerPosition.GoalKeeper
            };
        }

        protected override Rating CalculateRating()
        {
            return new RatingWithWeightingCalculator()
                .WithRatingWeighting(Goalkeeping)
                .WithRatingWeighting(ShotPower)
                .WithRatingWeighting(Agility)
                .Calculate();
        }
    }
}
