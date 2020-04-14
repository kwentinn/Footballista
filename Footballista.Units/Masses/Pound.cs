namespace Footballista.Units.Masses
{
	public class Pound : Mass
	{
		public Pound() : this(0) { }
		public Pound(double value) : base(value, SystemOfUnitsType.Imperial, "lb")
		{
		}

		public Stone ToStone() => new Stone(Value / 14);
	}
}
