using Footballista.BuildingBlocks.Domain;
using System.Diagnostics;

namespace Footballista.Players.Evolutions
{
	[DebuggerDisplay("{Value}")]
	public class Percentile : ValueObject
	{
		public int Value { get; }
		public Percentile(int value)
		{
			Value = value;
		}
	}
}
