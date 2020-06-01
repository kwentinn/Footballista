using Autofac;
using Footballista.Wasm.Server.Data.Mappers;

namespace Footballista.Wasm.Server.Modules
{
	internal class MappersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<PlayerMapper>().As<IMapper<Players.Player, Shared.Data.Players.Player>>();

			//var asm = System.Reflection.Assembly.GetExecutingAssembly();

			//builder.RegisterAssemblyTypes(asm)
			//	   .Where(t => t.Name.EndsWith("Mapper"))
			//	   .AsImplementedInterfaces();
		}
	}
}
