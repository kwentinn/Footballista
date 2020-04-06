using Footballista.Players.Units.Exceptions;

namespace Footballista.Players.Units
{
	public abstract class BaseUnit
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
