namespace Footballista.Players.Infrastracture
{
	internal sealed class AgeValue
	{
		public int Age { get; }
		public double Value { get; }
		public AgeValue(int age, double value)
		{
			Age = age;
			Value = value;
		}
	}
}
