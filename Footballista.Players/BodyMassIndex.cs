using Footballista.BuildingBlocks.Domain;
using System;
using UnitsNet;

namespace Footballista.Players
{
	public class BodyMassIndex : ValueObject
	{
		public Length Height { get; }
		public Mass Weight { get; }

		public double BMI => Math.Round(Weight.Kilograms / Math.Pow(Height.Meters, 2), 2);

		public BodyMassIndex(Length height, Mass weigth)
		{
			Height = height;
			Weight = weigth;
		}
	}
}
