using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features.BusinessRules;
using System;
using System.Diagnostics;

namespace Footballista.Players.Features
{
	[DebuggerDisplay("{Value * 100}")]
	public class Rating : ValueObject, IComparable<Rating>
	{
		public static Rating Min => new Rating(0.01);
		public static Rating Max => new Rating(0.99);

		public static Rating FromInt(int rating) => new Rating(Convert.ToDouble(rating) / 100d);

		public double Value { get; }

		public Rating(double rating)
		{
			CheckRule(new FeatureRatingMustBeWithinRangeRule(rating));

			Value = Math.Round(rating, 2);
		}

		public int CompareTo(Rating other) => Value.CompareTo(other.Value);

		public override string ToString() => $"{Value:N0}";
		public override int GetHashCode() => Value.GetHashCode();
	}
}
