namespace Footballista.Units.Masses
{
	public abstract class Mass : BaseUnit, IMass
	{
		internal Mass(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Mass, systemOfUnitsType, abbreviation)
		{
		}

		public static Kilogram FromKilograms(double kg) => new Kilogram(kg);
		public static Pound FromPounds(double lbs) => new Pound(lbs);

	}
}
