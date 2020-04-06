namespace Footballista.Players.Units.Mass
{
	public abstract class MassUnit : BaseUnit
	{
		internal MassUnit(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Mass, systemOfUnitsType, abbreviation)
		{
		}
	}


}
