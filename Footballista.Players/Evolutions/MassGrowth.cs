using Footballista.Units.Masses;

namespace Footballista.Players.Evolutions
{
	public class MassGrowth : Growth<IMass>
	{
		public MassGrowth(int ageInYear, IMass mass) : this(Age.FromYears(ageInYear), mass) { }
		public MassGrowth(Age age, IMass mass) : base(age, mass) { }

		public Growth<IMass> Cast()
		{
			return this;
		}
	}
}
