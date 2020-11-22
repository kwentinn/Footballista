using Footballista.Wasm.Client.NewCareer.Data;
using Microsoft.AspNetCore.Components;

namespace Footballista.Wasm.Client.NewCareer.ManagerInfo
{
	public class ManagerInfoComponentBase : ComponentBase
	{
		[Parameter]
		public ManagerData Manager { get; set; }
	}
}
