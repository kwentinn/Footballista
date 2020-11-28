using Footballista.Players.Domain.Features;
using Footballista.Players.Domain.Positions;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.Attributes.Base
{
	public abstract class AbstractPlayerAttributes
    {
        protected List<PlayerPosition> MatchingPositions;
        public Rating Rating => CalculateRating();

        protected abstract Rating CalculateRating();

        public virtual bool IsMatchForPosition(PlayerPosition position) 
            => this.MatchingPositions.Any(mp => position == mp);
    }
}
