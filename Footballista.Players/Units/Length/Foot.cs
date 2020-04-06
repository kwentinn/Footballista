namespace Footballista.Players.Units.Length
{
	public class Foot : LengthUnit
	{
		public Foot() : this(0d) { }
		public Foot(double value) : base(value, SystemOfUnitsType.Imperial, "ft") { }
	}
}
