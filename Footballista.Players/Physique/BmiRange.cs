using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Physique
{
	public class BmiRange : ValueObject
	{
		public BmiType BmiType { get; }
		public Range<double> Range { get; }

		public BmiRange(BmiType bmiType, Range<double> range)
		{
			BmiType = bmiType;
			Range = range ?? throw new ArgumentNullException(nameof(range));
		}

		public bool IsInRange(double value)
			=> value >= Range.Min && value <= Range.Max;
	}
}
