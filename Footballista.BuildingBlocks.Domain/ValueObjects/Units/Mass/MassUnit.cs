namespace Footballista.BuildingBlocks.Domain.ValueObjects.Units.Mass
{
	public abstract class MassUnit : BaseUnit, IMassUnit
	{
		internal MassUnit(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Mass, systemOfUnitsType, abbreviation)
		{
		}
	}
}
