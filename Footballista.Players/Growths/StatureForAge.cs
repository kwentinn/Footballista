using System.Diagnostics;

namespace Footballista.Players.Growths
{
	[DebuggerDisplay("{Age} - {Stature}")]
	public class StatureForAge
	{
		public PersonAge Age { get; }
		public UnitsNet.Length Stature { get; }

		public StatureForAge(int ageInYears, UnitsNet.Length stature)
		{
			Age = PersonAge.FromYears(ageInYears);
			Stature = stature;
		}
	}
}
