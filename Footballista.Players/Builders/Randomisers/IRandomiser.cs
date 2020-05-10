using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IRandomiser<T>
		where T : IComparable<T>
	{
		T Randomise();
		T Randomise(T min, T max);
		T Randomise(Range<T> range);
	}
}
