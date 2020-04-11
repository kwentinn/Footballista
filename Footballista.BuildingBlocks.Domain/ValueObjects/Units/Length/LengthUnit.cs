namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length
{
	public abstract class LengthUnit : BaseUnit, ILengthUnit
	{
		internal LengthUnit(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Length, systemOfUnitsType, abbreviation)
		{
		}
	}
}
