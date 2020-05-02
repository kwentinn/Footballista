using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.KNNs.Models
{
	[DebuggerDisplay("{Value}")]
	public struct Distance
	{
		public int Value { get; }
		public Distance(int value)
		{
			Value = value;
		}
	}
	[DebuggerDisplay("{Value}")]
	public struct Distance<T>
	{
		public T Value { get; }
		public Distance(T value)
		{
			Value = value;
		}
	}
}
