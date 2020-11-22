using System.Diagnostics;

namespace Footballista.BuildingBlocks.Domain.ValueObjects
{
	[DebuggerDisplay("{Name}")]
	public record City(string Name);
}