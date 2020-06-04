using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Footballista.Wasm.Server.AutofacModules
{
	internal class BlazorWasmServerModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			var asm = Assembly.GetExecutingAssembly();
			builder
				.RegisterAssemblyTypes(asm)
				.Where(t => t.Name.EndsWith("Service"))
				.AsImplementedInterfaces();
		}
	}
}
