using Footballista.BuildingBlocks.Domain;

namespace Footballista.Players
{
	public class AgeInYear : ValueObject
	{
		public int Year { get; }

		public AgeInYear(int year)
		{
			Year = year;
		}
	}
}
