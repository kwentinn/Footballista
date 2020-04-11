using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Year} y.o.")]
	public class AgeInYear : ValueObject
	{
		public int Year { get; }
		public AgeInYear(int year)
		{
			Year = year;
		}
	}
}
