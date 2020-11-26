using Footballista.Players.Features.Attributes.Base;
using Footballista.Players.Positions;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
    public class AttackingAttributes : AbstractPlayerAttributes
    {
        public Rating Accuracy { get; }
        public Rating Positionning { get; }
        public Rating Power { get; }
        public Rating Agility { get; }
        public Rating Header { get; }
        public Rating Speed { get; }

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

        protected override Rating CalculateRating()
        {
            throw new System.NotImplementedException();
        }
    }
}
