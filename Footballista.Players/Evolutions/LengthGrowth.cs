using Footballista.Units.Lengths;

namespace Footballista.Players.Evolutions
{

	public class LengthGrowth : Growth<ILength>
	{
		public LengthGrowth(int ageInYear, ILength length) : this(Age.FromYears(ageInYear), length) { }
		public LengthGrowth(Age age, ILength length) : base(age, length) { }
	}
}
