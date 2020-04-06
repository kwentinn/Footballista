namespace Footballista.Players.Units.Mass
{
	public class Pound : MassUnit
	{
		public Pound() : this(0) { }
		public Pound(double value) : base(value, SystemOfUnitsType.Imperial, "lb")
		{
		}

		public Stone ToStone() => new Stone(Value / 14);
	}
}
