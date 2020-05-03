using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.BusinessRules;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Rating:P2}")]
	public class FeatureRating : ValueObject
	{
		public double Rating { get; }

		public FeatureRating(double rating)
		{
			CheckRule(new FeatureRatingMustBeWithinRangeRule(rating));

			Rating = Math.Round(rating, 3);
		}
	}
}
