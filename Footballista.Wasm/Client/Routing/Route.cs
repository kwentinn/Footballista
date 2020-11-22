using System.Collections.Generic;

namespace Footballista.Wasm.Client.Routing
{
	public record Route(string Url, string Name, IEnumerable<Route> Children = null)
	{
	}
}
