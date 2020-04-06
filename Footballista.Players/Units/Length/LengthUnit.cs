namespace Footballista.Players.Units.Length
{
	public abstract class LengthUnit : BaseUnit
	{
		internal LengthUnit(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Length, systemOfUnitsType, abbreviation)
		{
		}
	}


}
