using Autofac;
using Footballista.Wasm.Server.Services.Mappers;

namespace Footballista.Wasm.Server.AutofacModules
{
	internal class MappersModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var asm = System.Reflection.Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(asm)
				   .Where(t => t.Name.EndsWith("Mapper"))
				   .AsImplementedInterfaces();
		}
	}
}
