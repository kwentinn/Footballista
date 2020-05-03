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
}
