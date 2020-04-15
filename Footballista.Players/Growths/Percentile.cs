using Footballista.BuildingBlocks.Domain;
using System;
using System.Diagnostics;

namespace Footballista.Players.Growths
{
	[DebuggerDisplay("{Value}")]
	public class Percentile : ValueObject
	{
		public int Value { get; }

		public Percentile(int value)
		{
			if (value < 0 || value > 100) throw new ArgumentException("Int value must be between 0 and 100.", nameof(value));
			Value = value;
		}
	}
}
