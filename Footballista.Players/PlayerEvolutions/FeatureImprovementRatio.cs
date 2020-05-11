using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Features;
using System;
using System.Diagnostics;

namespace Footballista.Players.PlayerEvolutions
{
	[DebuggerDisplay("{Value}")]
	public class FeatureImprovementRatio : ValueObject, IComparable<FeatureImprovementRatio>
	{
		public double Value { get; }

		public FeatureImprovementRatio(double value)
		{
			Value = Math.Round(value, 2);
		}

		public int CompareTo(FeatureImprovementRatio other) => Value.CompareTo(other.Value);

		public FeatureRating ImproveRating(FeatureRating featureRating)
		{
			double newValue = Math.Min(Math.Round(featureRating.Value * (1 + Value), 2), FeatureRating.Max.Value);

			return new FeatureRating(newValue);
		}
	}
}
