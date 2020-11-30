using Footballista.Game.Domain.Players.Features;
using System.Collections.Generic;

namespace Footballista.Players.Features.GlobalRatingCalculators
{
	public class RatingWeighting
	{
		public double Weighting { get; }
		public List<FeatureType> FeatureTypes { get; }

		public RatingWeighting(double weighting, List<FeatureType> featureTypes)
		{
			Weighting = weighting;
			FeatureTypes = featureTypes;
		}
	}

}
