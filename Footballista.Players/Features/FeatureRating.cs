using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.BusinessRules;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Rating}")]
	public class FeatureRating : ValueObject, IComparable<FeatureRating>
	{
		public static FeatureRating Min => new FeatureRating(0.01);
		public static FeatureRating Max => new FeatureRating(0.99);

		public double Rating { get; }

		public FeatureRating(double rating)
		{
			CheckRule(new FeatureRatingMustBeWithinRangeRule(rating));
			Rating = Math.Round(rating, 2);
		}

		public int CompareTo(FeatureRating other) => Rating.CompareTo(other.Rating);

		public override string ToString() => $"{Rating:N0}";
		public override int GetHashCode() => Rating.GetHashCode();
	}
}
