using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Domain.Features;
using System;
using System.Diagnostics;

namespace Footballista.Players.PlayerEvolutions
{
	[DebuggerDisplay("{_value}")]
	public class FeatureImprovementRatio : IComparable<FeatureImprovementRatio>
	{
		private readonly double _value;

		public FeatureImprovementRatio(double value)
		{
			_value = Math.Round(value, 2);
		}

		public int CompareTo(FeatureImprovementRatio other) => _value.CompareTo(other._value);

		public Rating ImproveRating(Rating featureRating)
		{
			double newValue = Math.Min(Math.Round(featureRating.Value * (1 + _value), 2), Rating.Max.Value);

			return new Rating(newValue);
		}

		public static FeatureImprovementRatio operator -(FeatureImprovementRatio ratio1, FeatureImprovementRatio ratio2)
			=> new FeatureImprovementRatio(ratio1._value - ratio2._value);
		public static FeatureImprovementRatio operator +(FeatureImprovementRatio ratio1, FeatureImprovementRatio ratio2)
			=> new FeatureImprovementRatio(ratio1._value + ratio2._value);

		public static implicit operator double (FeatureImprovementRatio ratio) => ratio._value;
	}
}
