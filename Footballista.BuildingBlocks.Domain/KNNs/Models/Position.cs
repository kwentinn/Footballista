using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.KNNs.Models
{
	[DebuggerDisplay("{IndexValue}")]
	public record Position(int IndexValue);
}
