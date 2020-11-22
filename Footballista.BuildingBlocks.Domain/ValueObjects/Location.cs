using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{City}, {Country}")]
	public record Location(City City, Country Country);
}
