namespace Footballista.Units.Lengths
{
	public class Foot : Length
	{
		public Foot() : this(0d) { }
		public Foot(double value) : base(value, SystemOfUnitsType.Imperial, "ft") { }
	}
}
