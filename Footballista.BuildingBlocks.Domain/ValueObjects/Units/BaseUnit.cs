namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units
{
	public abstract class BaseUnit : ValueObject
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
