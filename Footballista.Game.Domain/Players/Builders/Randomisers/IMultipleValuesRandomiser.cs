using Footballista.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;

namespace Footballista.Players.Builders.Randomisers
{
	public interface IMultipleValuesRandomiser<T>
		where T : IComparable<T>
	{
		T[] GetRandomisedValues(Range<T> intRange, int numberOfItemsToGenerate, bool allowIdenticalValues = false);
        IEnumerable<T> RandomiseDistinctValues(Range<T> range, int numberOfItemsToGenerate);
    }
}
