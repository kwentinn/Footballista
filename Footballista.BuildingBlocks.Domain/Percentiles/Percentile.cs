﻿using Footballista.BuildingBlocks.Domain.KNNs;
using Footballista.BuildingBlocks.Domain.KNNs.Models;
using System;
using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.Percentiles
{
	[DebuggerDisplay("{Value}")]
	public record Percentile : IComparable<Percentile>, IDistanceMeasurable<Percentile>
	{
		public int Value { get; }

		public static Percentile Min => new Percentile(0);
		public static Percentile Max => new Percentile(100);

		public Percentile(int value)
		{
			if (value < 0 || value > 100)
				throw new ArgumentException("Int value must be between 0 and 100.", nameof(value));

			Value = value;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Value);
		}

		public int CompareTo(Percentile other)
		{
			return Value.CompareTo(other.Value);
		}

		public Distance GetDistance(Percentile other)
		{
			return new Distance(Math.Abs(Value - other.Value));
		}

		public static bool operator <(Percentile left, Percentile right)
		{
			return left.CompareTo(right) < 0;
		}
		public static bool operator <=(Percentile left, Percentile right)
		{
			return left.CompareTo(right) <= 0;
		}
		public static bool operator >(Percentile left, Percentile right)
		{
			return left.CompareTo(right) > 0;
		}
		public static bool operator >=(Percentile left, Percentile right)
		{
			return left.CompareTo(right) >= 0;
		}
		public static Percentile operator +(Percentile a, Percentile b)
		{
			return new Percentile(a.Value + b.Value);
		}
		public static Percentile operator -(Percentile a, Percentile b)
		{
			return new Percentile(a.Value - b.Value);
		}
	}
}
