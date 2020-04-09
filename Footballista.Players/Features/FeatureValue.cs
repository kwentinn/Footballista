using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Features
{
	public class FeatureValue : ValueObject
	{
		public double Value { get; }

		public FeatureValue(int value) : this(Convert.ToDouble(value))
		{
		}
		public FeatureValue(double value)
		{
			Value = value;
		}
	}
}
