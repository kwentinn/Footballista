using Footballista.BuildingBlocks.Domain;
using System;

namespace Footballista.Players.Builders.Randomisers
{
	public class IntRandomiser : GenericRandomiser, IRandomiser<int>
	{
		public int Randomise() => Random.Next(0, int.MaxValue);
		public int Randomise(int min, int max) => Random.Next(min, max);
		public int Randomise(Range<int> range) => Randomise(range.Min, range.Max);
	}
}
