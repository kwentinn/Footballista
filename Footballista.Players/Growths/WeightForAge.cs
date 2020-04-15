namespace Footballista.Players.Growths
{
	public class WeightForAge
	{
		public Age Age { get; }
		public UnitsNet.Mass Mass { get; }

		public WeightForAge(int ageInYears, UnitsNet.Mass mass)
		{
			Age = Age.FromYears(ageInYears);
			Mass = mass;
		}
	}
}
