using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
    public class GoalkeepingAttributes : AbstractPlayerAttributes
    {
        public RatingWeighting Goalkeeping { get; }
        public RatingWeighting ShotPower { get; }
        public RatingWeighting Agility { get; }

        public GoalkeepingAttributes(Rating goalkeeping, Rating shotPower, Rating agility)
        {
            Goalkeeping = new RatingWeighting(5, goalkeeping);
            ShotPower = new RatingWeighting(2, shotPower);
            Agility = new RatingWeighting(2, agility);

            this.MatchingPositions = new List<PlayerPosition>
            {
                PlayerPosition.GoalKeeper
            };
        }

        protected override Rating CalculateRating()
        {
            return new RatingWeightingCalculator()
                .WithRatingWeighting(Goalkeeping)
                .WithRatingWeighting(ShotPower)
                .WithRatingWeighting(Agility)
                .Calculate();
        }
    }
}
