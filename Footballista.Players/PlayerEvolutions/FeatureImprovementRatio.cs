using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using System;
using System.Diagnostics;

namespace Footballista.Players.PlayerEvolutions
{
	[DebuggerDisplay("{Value}")]
	public class FeatureImprovementRatio : IComparable<FeatureImprovementRatio>
	{
		public double Value { get; }

		public FeatureImprovementRatio(double value)
		{
			Value = Math.Round(value, 2);
		}

		public int CompareTo(FeatureImprovementRatio other) => Value.CompareTo(other.Value);

		public Rating ImproveRating(Rating featureRating)
		{
			double newValue = Math.Min(Math.Round(featureRating.Value * (1 + Value), 2), Rating.Max.Value);

			return new Rating(newValue);
		}

		public static FeatureImprovementRatio operator -(FeatureImprovementRatio ratio1, FeatureImprovementRatio ratio2)
			=> new FeatureImprovementRatio(ratio1.Value - ratio2.Value);
		public static FeatureImprovementRatio operator +(FeatureImprovementRatio ratio1, FeatureImprovementRatio ratio2)
			=> new FeatureImprovementRatio(ratio1.Value + ratio2.Value);
	}
}
