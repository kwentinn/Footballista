using Footballista.BuildingBlocks.Domain;
using Footballista.Units;
using System.Diagnostics;

namespace Footballista.Players.Evolutions
{
	[DebuggerDisplay("{Age} {Value}")]
	public abstract class Growth<T> : ValueObject
		where T : IUnit
	{
		public Age Age { get; }
		public T Value { get; }

		public Growth(Age age, T value)
		{
			Age = age;
			Value = value;
		}
	}
}
