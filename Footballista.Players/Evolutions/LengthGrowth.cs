using Footballista.BuildingBlocks.Domain.ValueObjects.Units.Length;

namespace Footballista.Players.Evolutions
{

	public class LengthGrowth : Growth<ILengthUnit>
	{
		public LengthGrowth(int ageInYear, ILengthUnit length) : this(new AgeInYear(ageInYear), length) { }
		public LengthGrowth(AgeInYear age, ILengthUnit length) : base(age, length) { }
	}
}
