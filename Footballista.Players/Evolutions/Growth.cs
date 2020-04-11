using Footballista.BuildingBlocks.Domain;
using Footballista.BuildingBlocks.Domain.ValueObjects.Units;
using System.Diagnostics;

namespace Footballista.Players.Evolutions
{
	[DebuggerDisplay("{Age} {Value}")]
	public abstract class Growth<T> : ValueObject
		where T : IUnit
	{
		public AgeInYear Age { get; }
		public T Value { get; }

		public Growth(AgeInYear age, T value)
		{
			Age = age;
			Value = value;
		}
	}
}
