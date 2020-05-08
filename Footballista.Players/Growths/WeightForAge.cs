namespace Footballista.Players.Growths
{
	public class WeightForAge
	{
		public PersonAge Age { get; }
		public UnitsNet.Mass Mass { get; }

		public WeightForAge(int ageInYears, UnitsNet.Mass mass)
		{
			Age = PersonAge.FromYears(ageInYears);
			Mass = mass;
		}
	}
}
