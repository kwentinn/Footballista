using Autofac;
using Footballista.Wasm.Server.Data;

namespace Footballista.Wasm.Server.Modules
{
	internal class BlazorWasmServerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<PlayersService>().As<IPlayersService>();
		}
	}
}
