using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Players
{
	[DebuggerDisplay("{Year} y.o.")]
	public class Age : ValueObject
	{
		public float Years { get; }

		[IgnoreMember]
		public float Months => Years * 12f;

		[IgnoreMember]
		public float Days => Years * 365f;

		private Age(int year)
		{
			Years = year;
		}

		public static Age FromYears(int years) => new Age(years);
		public static Age FromMonths(int month) => new Age(month / 12);
	}
}
