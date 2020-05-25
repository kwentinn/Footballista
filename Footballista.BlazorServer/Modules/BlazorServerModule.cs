using Autofac;

namespace Footballista.BlazorServer.Modules
{
	internal class BlazorServerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{ 
			builder.RegisterType<Footballista.BlazorServer.Data.PlayersService>();
		}
	}
}
