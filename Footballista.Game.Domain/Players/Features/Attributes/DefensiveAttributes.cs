using Footballista.Game.Domain.Players.Features;
using Footballista.Game.Domain.Players.Positions;
using Footballista.Players.Features.Attributes.Base;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Features.Attributes
{
	public class DefensiveAttributes : AbstractPlayerAttributes
    {
        public Rating Positionning { get; }
        public Rating Denfence { get; }
        public Rating Power { get; }
        public Rating Agility { get; }
        public Rating Header { get; }
        public Rating Passing { get; }

        public DefensiveAttributes()
        {
            this.MatchingPositions = new List<PlayerPosition>
            {
                PlayerPosition.FullBack,
                PlayerPosition.WingBack,
                PlayerPosition.Sweeper,
                PlayerPosition.DefensiveMidfield,
                PlayerPosition.CentreMidfield
            };
        }

        protected override Rating CalculateRating()
        {
            throw new NotImplementedException();
        }
    }
}
