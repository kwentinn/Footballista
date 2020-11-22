using Autofac;

namespace Footballista.BlazorServer.Modules
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
