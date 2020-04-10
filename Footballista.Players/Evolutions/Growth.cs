using Footballista.BuildingBlocks.Domain;
using Footballista.Players.Units;
using Footballista.Players.Units.Mass;

namespace Footballista.Players.Evolutions
{
	public abstract class Growth<T> : ValueObject
		where T : BaseUnit
	{
		public AgeInYear Age { get; }
		public T Value { get; }

		public Growth(AgeInYear age, T value)
		{
			Age = age;
			Value = value;
		}
	}

	public class KilogramGrowth : Growth<Kilogram>
	{
		public KilogramGrowth(AgeInYear age, Kilogram value) : base(age, value)
		{
		}
	}
}
