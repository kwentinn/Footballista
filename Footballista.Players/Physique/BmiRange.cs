﻿using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Domain.Physique
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
