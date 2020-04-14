using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Units
{
	[DebuggerDisplay("{Value}{Abbreviation} ({BaseUnitType}, {SystemOfUnitsType})")]
	public abstract class BaseUnit : ValueObject, IUnit
	{
		public double Value { get; internal set; }

		public string Abbreviation { get; }

		public BaseUnitType BaseUnitType { get; }
		public SystemOfUnitsType SystemOfUnitsType { get; }

		internal BaseUnit(double value, BaseUnitType baseUnitType, SystemOfUnitsType systemOfUnitsType, string abbreviation)
		{
			Value = value;
			BaseUnitType = baseUnitType;
			SystemOfUnitsType = systemOfUnitsType;
			Abbreviation = abbreviation;
		}

		public override string ToString()
		{
			return $"{Value:D2} {Abbreviation}";
		}
	}
}
