using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Game.Domain.Players.Physique
{
	public record BmiRange
	{
		public BmiType BmiType { get; }
		public Range<double> Range { get; }

		public BmiRange(BmiType bmiType, Range<double> range)
		{
			BmiType = bmiType;
			Range = range ?? throw new ArgumentNullException(nameof(range));
		}
	}
}
