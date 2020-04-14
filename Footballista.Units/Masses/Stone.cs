namespace Footballista.Units.Masses
{
	public class Stone : Mass
	{
		public Stone() : this(0) { }
		public Stone(double value) : base(value, SystemOfUnitsType.Imperial, "st")
		{
		}

		public Pound ToPound() => new Pound(Value * 14);
	}
	public class Ounce : Mass
	{
		public Ounce() : this(0) { }
		public Ounce(double value) : base(value, SystemOfUnitsType.Imperial, "oz")
		{
		}

		public Pound ToPound() => new Pound(Value / 16);
	}
}
