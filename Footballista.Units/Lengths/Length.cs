namespace Footballista.Units.Lengths
{
	public abstract class Length : BaseUnit, ILength
	{
		internal Length(double value, SystemOfUnitsType systemOfUnitsType, string abbreviation)
			: base(value, BaseUnitType.Length, systemOfUnitsType, abbreviation)
		{
		}

		public static Meter FromMeters(double meters) => new Meter(meters);
		public static Meter FromCentimeters(double cm) => new Meter(cm / 100d);
	}
}
