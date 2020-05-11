using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.BusinessRules;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Value * 100}")]
	public class FeatureRating : ValueObject, IComparable<FeatureRating>
	{
		public static FeatureRating Min => new FeatureRating(0.01);
		public static FeatureRating Max => new FeatureRating(0.99);

		public double Value { get; }

		public FeatureRating(double rating)
		{
			CheckRule(new FeatureRatingMustBeWithinRangeRule(rating));

			Value = Math.Round(rating, 2);
		}

		public int CompareTo(FeatureRating other) => Value.CompareTo(other.Value);

		public override string ToString() => $"{Value:N0}";
		public override int GetHashCode() => Value.GetHashCode();
	}
}
