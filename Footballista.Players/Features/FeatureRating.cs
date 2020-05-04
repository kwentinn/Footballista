using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.BusinessRules;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Rating:P2}")]
	public class FeatureRating : ValueObject
	{
		public static FeatureRating Min => new FeatureRating(0);
		public static FeatureRating Max => new FeatureRating(1);

		public double Rating { get; }

		public FeatureRating(double rating)
		{
			CheckRule(new FeatureRatingMustBeWithinRangeRule(rating));
			Rating = Math.Round(rating, 2);
		}

		public override string ToString() => $"{Rating:N0}";
		public override int GetHashCode() => Rating.GetHashCode();
	}
}
