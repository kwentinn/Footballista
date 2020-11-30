using Footballista.Game.Domain.Players.Positions;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Players.Features.GlobalRatingCalculators.RatingConfigs.Base
{
	public abstract class PlayerRatingConfigBase
	{
		public abstract PlayerPosition PlayerPosition { get; }

		public List<RatingWeighting> RatingWeightings = new List<RatingWeighting>();

		//public double WeightingsSum => RatingWeightings.Sum(rw => rw.Weighting);
	}
}
