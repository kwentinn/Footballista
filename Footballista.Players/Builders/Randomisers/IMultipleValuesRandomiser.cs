using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IMultipleValuesRandomiser<T>
		where T : IComparable<T>
	{
		T[] GetRandomisedValues(Range<T> intRange, int numberOfItemsToGenerate, bool allowIdenticalValues = false);
	}
}
