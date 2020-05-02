using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.KNNs.Models
{
	[DebuggerDisplay("{IndexValue}")]
	public struct Position
	{
		public int IndexValue { get; }
		public Position(int indexValue)
		{
			IndexValue = indexValue;
		}
	}
}
