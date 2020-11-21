using Autofac;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;

namespace Footballista.Wasm.Server.AutofacModules
{
	internal class MediatRModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// Mediator itself
			builder
				.RegisterType<Mediator>()
				.As<IMediator>()
				.InstancePerLifetimeScope();


			// request & notification handlers
			builder.Register<ServiceFactory>(context =>
			{
				IComponentContext c = context.Resolve<IComponentContext>();
				return t => c.Resolve(t);
			});


			var assemblies = new Assembly[]
			{
				typeof(Startup).Assembly,
				typeof(Cqrs.Commands.CreateCareerCommand).Assembly
			};

			// finally register our custom code (individually, or via assembly scanning)
			// - requests & handlers as transient, i.e. InstancePerDependency()
			// - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
			// - behaviors as transient, i.e. InstancePerDependency()
			builder
				.RegisterAssemblyTypes(assemblies)
				.Where(t => !t.IsInterface && t.Name.EndsWith("Handler"))
				.AsImplementedInterfaces(); // via assembly scan

			//builder.RegisterType<MyHandler>().AsImplementedInterfaces().InstancePerDependency();          // or individually
		}
	}
}
