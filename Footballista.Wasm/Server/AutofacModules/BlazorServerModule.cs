using Autofac;
using Footballista.Wasm.Server.Services;

namespace Footballista.Wasm.Server.AutofacModules
{
	internal class BlazorWasmServerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<PlayersService>().As<IPlayersService>();
		}
	}
}
