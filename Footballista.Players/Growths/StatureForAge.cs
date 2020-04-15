using System.Diagnostics;

namespace Footballista.Players.Growths
{
	[DebuggerDisplay("{Age} - {Stature}")]
	public class StatureForAge
	{
		public Age Age { get; }
		public UnitsNet.Length Stature { get; }

		public StatureForAge(int ageInYears, UnitsNet.Length stature)
		{
			Age = Age.FromYears(ageInYears);
			Stature = stature;
		}
	}
}
