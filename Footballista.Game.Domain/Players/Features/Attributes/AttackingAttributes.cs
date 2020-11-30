using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Features.Attributes.Calculator;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
	public class AttackingAttributes : AbstractPlayerAttributes
    {
        public RatingWithWeighting Accuracy { get; }
        public RatingWithWeighting Positionning { get; }
        public RatingWithWeighting Power { get; }
        public RatingWithWeighting Agility { get; }
        public RatingWithWeighting Header { get; }
        public RatingWithWeighting Speed { get; }

        public AttackingAttributes()
        {
            this.MatchingPositions = new List<PlayerPosition>
            {
                PlayerPosition.AttackingMidfield,
                PlayerPosition.SecondStriker,
                PlayerPosition.Winger,
                PlayerPosition.CentreForward,
            };
        }

        public AttackingAttributes(Rating accuracy, Rating positionning, Rating power, Rating agility, Rating header, Rating speed)
        {
            this.Accuracy = new RatingWithWeighting(1, accuracy);
            this.Positionning = new RatingWithWeighting(1, positionning);
            this.Power = new RatingWithWeighting(1, power);
            this.Agility = new RatingWithWeighting(1, agility);
            this.Header = new RatingWithWeighting(1, header);
            this.Speed = new RatingWithWeighting(1, speed);
        }

        protected override Rating CalculateRating()
        {
            return new RatingWithWeightingCalculator()
                .WithRatingWeighting(Accuracy)
                .WithRatingWeighting(Positionning)
                .WithRatingWeighting(Power)
                .WithRatingWeighting(Agility)
                .WithRatingWeighting(Header)
                .WithRatingWeighting(Speed)
                .Calculate();
        }
    }
}
